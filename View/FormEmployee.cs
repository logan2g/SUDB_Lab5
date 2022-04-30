using System.Windows.Forms;
using System;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;

namespace View
{
    public partial class FormEmployee : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        private readonly IEmployeeLogic _logic;

        public FormEmployee(IEmployeeLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new EmployeeBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxSurcharge.Text = view.Surchashrge.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            if (string.IsNullOrEmpty(textBoxSurcharge.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Surchashrge = Convert.ToInt32(textBoxSurcharge.Text)
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
    }
}
