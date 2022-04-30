using System.Windows.Forms;
using System;
using Contracts.BusinessLogicContracts;
using Contracts.BindingModels;

namespace View
{
    public partial class FormPost : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        private readonly IPostLogic _logic;

        public FormPost(IPostLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormPost_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new PostBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.PostName;
                        textBoxSalary.Text = view.Salary.ToString();
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
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSalary.Text))
            {
                MessageBox.Show("Заполните оклад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new PostBindingModel
                {
                    Id = id,
                    PostName = textBoxName.Text,
                    Salary = Convert.ToInt32(textBoxSalary.Text)
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
