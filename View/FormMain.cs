using System;
using System.Windows.Forms;
using Unity;
using Contracts.BusinessLogicContracts;

namespace View
{
    public partial class FormMain : Form
    {
        private readonly IFullEmplInfoLogic _logic;

        public FormMain(IFullEmplInfoLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void работникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployees>();
            form.ShowDialog();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPosts>();
            form.ShowDialog();
        }

        private void отделыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormDepartments>();
            form.ShowDialog();
        }

        private void назначенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormAssignments>();
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read();
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
