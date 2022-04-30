using System.Windows.Forms;
using System;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;

namespace View
{
    public partial class FormDepartment : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        private readonly IDepartmentLogic _logic;

        public FormDepartment(IDepartmentLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new DepartmentBindingModel
                {
                    Id = id,
                    DepartmentName = textBoxName.Text
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

        private void FormDepartment_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new DepartmentBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.DepartmentName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
