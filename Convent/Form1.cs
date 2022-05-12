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
            table.Columns.Add("2-я система", typeof(string));
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 217;

            button1.Enabled = false;
            button2.Enabled = false;

            textBox2.Enabled = false;

            label3.Visible = false;
            label4.Visible = false;
        }

        private bool isBinaryTextBox() {
            if (textBox1.Text.Contains('2') || textBox1.Text.Contains('3') || textBox1.Text.Contains('4') || textBox1.Text.Contains('5')
                           || textBox1.Text.Contains('6') || textBox1.Text.Contains('7') || textBox1.Text.Contains('8') || textBox1.Text.Contains('9'))
                return false;
            else
                return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
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
                if (isBinaryTextBox())
                {
                    if (n < 536870912 && n > -536870912)
                    {
                        button1.Enabled = true;
                        label4.Visible = false;
                    }
                    else
                        button1.Enabled = false;
                    if (n < 11111111111111111111111111111.11 && n >= 0)
                    {
                        button2.Enabled = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        button2.Enabled = false;
                        label4.Visible = true;
                    }


                }
                else
                {
                    if (n < 536870912 && n > -536870912)
                    {
                        button1.Enabled = true;
                        button2.Enabled = false;
                        label4.Visible = false;
                    }
                    else
                        label4.Visible = true;
                }
            }
            else
            {
                label3.Visible = true;
                button2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            String s = textBox1.Text;
            String[] parts = new String[2];
            if (s.Contains(','))
            {
                int n = s.IndexOf(',');
                if (n == 0)
                {
                    parts[0] = "0";
                    parts[1] = s.Replace(",", "");
                }
                else if (n == s.Length-1)
                {
                    parts[0] = s.Replace(",", "");
                    parts[1] = "0";
                }
                else
                {
                    s = s.Replace(',', ' ');
                    parts = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            else
                parts = new String[] { s, "0" };
            MessageBox.Show(parts[0] + " - "+parts[1]);

            //Целые части
            int i = 0;
            int left; double right;
            int znak;
            String first;
            String resRight = "", resLeft = "";
            int.TryParse(parts[0], out left);
            if (left < 0)
            {
                first = "1";
                left = -left;
            }
            else
                first = "0";

            while (left != 0)
            {
                znak = left % 2;
                resLeft += znak.ToString();
                left = left / 2;
                i++;
            }
            resLeft += first;
            resLeft = new String(resLeft.ToCharArray().Reverse().ToArray());
            MessageBox.Show("This = " + resLeft);
            
             //Дробные части
             double.TryParse("0,"+parts[1], out right);
             for (int j = -1; j > -3; j--)
             {
                 right *= 2;
                if (right > 1)
                {
                    resRight += "1";
                    right -= 1;
                }
                else
                    resRight += "0";
             }
             MessageBox.Show("This = " + (resLeft+","+resRight));
             double c;
             double.TryParse(textBox1.Text, out c);
             table.Rows.Add(c, (resLeft+","+resRight));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double test, n = 0;
            String[] words = new string[2];
            double.TryParse(textBox1.Text, out test);
            String s = test.ToString();
            if (s.Contains(','))
            {
                s = s.Replace(',', ' ');
                words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
                words = new String[] { s, "0" };

            //Целые части
            int i = words[0].Length - 1;
            while (i >= 0)
            {
                n += ((int)words[0][i] - 48) * Math.Pow(2, words[0].Length - i - 1);
                i--;
            }

            //Дробные части
            i = 0;
            while (i+1 <= words[1].Length)
            {
                n += ((int)words[1][i] - 48) * Math.Pow(2, -1*(i+1));
                i++;
            }
            textBox2.Text = n.ToString();
            double c;
            double.TryParse(textBox1.Text, out c);
            table.Rows.Add(c, n);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            table.Clear();
            dataGridView1.Refresh();
        }
    }
}
