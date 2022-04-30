using System.Windows.Forms;
using System;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;

namespace View
{
    public partial class FormAssignment : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        private readonly IDepartmentLogic _logicDep;

        private readonly IEmployeeLogic _logicEmpl;

        private readonly IPostLogic _logicPost;

        private readonly IAssignmentLogic _logicAssign;

        public FormAssignment(IDepartmentLogic logicDep, IEmployeeLogic logicEmpl, IPostLogic logicPost, IAssignmentLogic logicAssign)
        {
            InitializeComponent();
            _logicDep = logicDep;
            _logicEmpl = logicEmpl;
            _logicPost = logicPost;
            _logicAssign = logicAssign;
        }

        private void LoadData()
        {
            try
            {
                var listEmpl = _logicEmpl.Read(null);
                if (listEmpl != null)
                {
                    comboBoxEmployee.DisplayMember = "Name";
                    comboBoxEmployee.ValueMember = "Id";
                    comboBoxEmployee.DataSource = listEmpl;
                    comboBoxEmployee.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список отделов");
                }
                var listDeps = _logicDep.Read(null);
                if (listDeps != null)
                {
                    comboBoxDepartment.DisplayMember = "DepartmentName";
                    comboBoxDepartment.ValueMember = "Id";
                    comboBoxDepartment.DataSource = listDeps;
                    comboBoxDepartment.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список работников");
                }
                var listpost = _logicPost.Read(null);
                if (listpost != null)
                {
                    comboBoxPost.DisplayMember = "PostName";
                    comboBoxPost.ValueMember = "Id";
                    comboBoxPost.DataSource = listpost;
                    comboBoxPost.SelectedItem = null;
                }
                else
                {
                    throw new Exception("Не удалось загрузить список должностей");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAssignment_Load(object sender, EventArgs e)
        {
            LoadData();
            if (id.HasValue)
            {
                try
                {
                    var view = _logicAssign.Read(new AssignmentBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        comboBoxEmployee.SelectedValue = view.EmployeeId;
                        comboBoxDepartment.SelectedValue = view.DepartmentId;
                        comboBoxPost.SelectedValue = view.PostId;
                        dateTimePickerHiring.Value = view.HiringDate;
                        dateTimePickerDismiss.Value = view.DismissDate;
                        comboBoxEmployee.Enabled = false;
                        comboBoxDepartment.Enabled = false;
                        comboBoxPost.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите отдел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDepartment.SelectedValue == null)
            {
                MessageBox.Show("Выберите работника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPost.SelectedValue == null)
            {
                MessageBox.Show("Выберите должность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePickerHiring.Value.Date >= dateTimePickerDismiss.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicAssign.CreateOrUpdate(new AssignmentBindingModel
                {
                    Id = id,
                    DepartmentId = Convert.ToInt32(comboBoxDepartment.SelectedValue),
                    EmployeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue),
                    PostId = Convert.ToInt32(comboBoxPost.SelectedValue),
                    HiringDate = dateTimePickerHiring.Value,
                    DismissDate = dateTimePickerDismiss.Value
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
