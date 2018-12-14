using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database.PlotGraph". При необходимости она может быть перемещена или удалена.
            this.plotGraphTableAdapter.Fill(this.database.PlotGraph);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                plotGraphBindingSource.EndEdit();
                plotGraphTableAdapter.Update(database.PlotGraph);
                MessageBox.Show("Your data has been successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            chart1.Series["Values"].XValueMember = "X";
            chart1.Series["Values"].YValueMembers = "Y";
            chart1.DataSource = database.PlotGraph;
            chart1.DataBind();
        }
    }
}
