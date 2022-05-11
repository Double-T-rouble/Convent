using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convent
{
    public partial class Form1 : Form
    {
        public static DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("10-я система", typeof(int));
            table.Columns.Add("2-я система", typeof(int));
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 160;
            dataGridView1.Columns[1].Width = 197;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Manual Mform = new Manual();
            Mform.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AboutProg APform = new AboutProg();
            APform.Show();
        }
    }
}
