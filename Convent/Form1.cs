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
            table.Columns.Add("10-я система", typeof(double));
            table.Columns.Add("2-я система", typeof(double));
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 160;
            dataGridView1.Columns[1].Width = 197;

            button1.Enabled = false;
            button2.Enabled = false;

            textBox2.Enabled = false;

            label3.Visible = false;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double n;
            if (double.TryParse(textBox1.Text, out n))
            {
                label3.Visible = false;
                if (textBox1.Text.Contains('2') || textBox1.Text.Contains('3') || textBox1.Text.Contains('4') || textBox1.Text.Contains('5')
                    || textBox1.Text.Contains('6') || textBox1.Text.Contains('7') || textBox1.Text.Contains('8') || textBox1.Text.Contains('9'))
                {
                    button2.Enabled = true;
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            else
            {
                label3.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
