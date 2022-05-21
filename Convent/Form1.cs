using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Convent
{
    public partial class Form1 : Form
    {
        public static DataTable table = new DataTable();
        public Form1()
        {
            
            InitializeComponent();
            button1.BackColor = Color.FromArgb(224, 224, 224);
            button1.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button1.FlatStyle = FlatStyle.Flat;
            button2.BackColor = Color.FromArgb(224, 224, 224);
            button2.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button2.FlatStyle = FlatStyle.Flat;
        }

        string[] quotes = new string[4];
        bool floatPoint;
        bool autosave;

        //public void ChangeFloatPoint() 
        //{
        //    floatPoint = true;
        //    foreach (DataRow row in table.Rows) 
        //    {
        //        row[0] = Convert.ToString(row[0]).Replace(",", ".");
        //        row[1] = Convert.ToString(row[1]).Replace(",", ".");
        //    }
        //    table.WriteXml("autosave.xml");
        //    dataGridView1.Refresh();
        //}
        //public void ChangeFloatComma()
        //{
        //    floatPoint = false;
        //    foreach (DataRow row in table.Rows) 
        //    {
        //        row[0] = Convert.ToString(row[0]).Replace(".", ",");
        //        row[1] = Convert.ToString(row[1]).Replace(".", ",");
        //    }
        //    table.WriteXml("autosave.xml");
        //    dataGridView1.Refresh();
        //}
        Options Oform;
        private void CheckConfig() 
        {
            try
            {
                String[] configs = File.ReadAllLines("config.txt");
                if (configs[0] == ",")
                    floatPoint = false;
                else if (configs[0] == ".")
                    floatPoint = true;
                else
                    throw new Exception();

                if (configs[1] == "+")
                    autosave = true;
                else if (configs[1] == "-")
                    autosave = false;
                else
                    throw new Exception();

                if (configs.Length < 6)
                    throw new Exception();

                quotes[0] = configs[2];
                quotes[1] = configs[3];
                quotes[2] = configs[4];
                quotes[3] = configs[5];
            }
            catch (Exception e)
            {
                File.WriteAllText("config.txt", ",\n+\nЭто не число\nНеправильный формат\nУверены, что хотите выйти ?\nВосстановить удалённые данные будет невозможно, всё равно удалить ?\n");
                CheckConfig();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table.TableName = "history";
            notifyIcon1.BalloonTipTitle = "\"Я буду недалеко\"";
            notifyIcon1.BalloonTipText = "Приложение свёрнуто.\nДважды нажмите на иконку, чтобы открыть";
            notifyIcon1.Text = "Convent";

            table.Columns.Add("10-я система", typeof(string));
            table.Columns.Add("2-я система", typeof(string));
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 217;
            dataGridView1.EnableHeadersVisualStyles = false;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Visible = false;
            textBox2.Enabled = false;

            label3.Visible = false;
            label4.Visible = false;
            CheckConfig();
            label3.Text = quotes[0];
            label4.Text = quotes[1];
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

        Manual Mform;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Mform = new Manual();
            if(BackColor==Color.FromArgb(54, 57, 63))
            {
                Mform.BackColor = Color.FromArgb(54, 57, 63);
                Mform.toDark();
            }
            else
            {
                Mform.BackColor = Color.White;
                Mform.toLight();
            }
            Mform.Show();
        }
        AboutProg APform;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            APform = new AboutProg();
            if (BackColor == Color.FromArgb(54, 57, 63))
            {
                APform.BackColor = Color.FromArgb(54, 57, 63);
                APform.toDark();
            }
            else
            {
                APform.BackColor = Color.White;
                APform.toLight();
            }
            APform.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double n;
            string redacted = textBox1.Text;
            if (floatPoint == true)
                redacted = textBox1.Text.Replace(".", ",");
            if (double.TryParse(redacted, out n))
            {
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
                    {
                        button1.Enabled = false;
                        label4.Visible = true;
                    }
                }
                label3.Visible = false;
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
            String s;
            if (floatPoint == true)
                s = textBox1.Text.Replace(".", ",");
            else
                s = textBox1.Text;

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
             if (floatPoint == true)
                textBox2.Text = resLeft + "." + resRight;
             else
                textBox2.Text = resLeft + "," + resRight;
            table.Rows.Add(textBox1.Text, (textBox2.Text));
            table.WriteXml("autosave.xml");
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Trim();
            String s;
            if (floatPoint == true)
                s = textBox1.Text.Replace(".", ",");
            else
                s = textBox1.Text;
            String[] parts = new String[2];
            int mod = 1;
            double m = 0;
            if (s.Contains(','))
            {
                int n = s.IndexOf(',');
                if (n == 0)
                {
                    parts[0] = "0";
                    parts[1] = s.Replace(",", "");
                }
                else if (n == s.Length - 1)
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
            if (s[0] == '1')
                mod = -1;

            //Целые части
            int i = parts[0].Length - 1;
            while (i > 0)
            {
                m += ((int)parts[0][i] - 48) * Math.Pow(2, parts[0].Length - i - 1);
                i--;
            }

            //Дробные части
            i = 0;
            while (i+1 <= parts[1].Length)
            {
                m += ((int)parts[1][i] - 48) * Math.Pow(2, -1*(i+1));
                i++;
            }
            m *= mod;
            if (floatPoint == true) { }
                textBox2.Text = m.ToString().Replace(",",".");

            table.Rows.Add(m, textBox1.Text);
            if (autosave==true)
                table.WriteXml("autosave.xml");
            button3.Visible = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                quotes[3],
                "Удалить историю",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
                );
            if (res == DialogResult.Yes) 
            {
                table.Clear();
                dataGridView1.Refresh();
            }
            if (autosave == true)
                table.WriteXml("autosave.xml");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
                notifyIcon1.Visible = false;
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(quotes[2], "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) { }
            else { e.Cancel = true; }
        }

        private void to2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
                button1_Click(sender, e);
        }

        private void to10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
                button2_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Текстовый файл|*.txt|XML файл|*.xml";
            saveFileDialog1.Title = "Сохранить историю";


            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            // сохраняем текст в файл
            switch (saveFileDialog1.FilterIndex)
            {
                case 2:
                    table.WriteXml(filename);
                    break;

                case 1:
                    string myTableAsString =
                    String.Join(Environment.NewLine, table.Rows.Cast<DataRow>().
                    Select(r => r.ItemArray).ToArray().
                    Select(x => String.Join("\t", x.Cast<string>())));

                    System.IO.File.WriteAllText(filename, myTableAsString);
                    break;

            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e) {}

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        private void таблицуИсторииToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "XML файл|*.xml";
            openFileDialog1.Title = "Открыть историю";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            table.ReadXml(filename);
            
        }

        private void файлДляПереводаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовый файл|*.txt";
            openFileDialog1.Title = "Открыть файл для перевод";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            String[] nums = File.ReadAllLines(filename);
            foreach (string element in nums) 
            {
                textBox1.Text = element;
                if (button1.Enabled == true)
                    button1_Click(sender, e);
            }
            textBox1.Text = ""; textBox2.Text = ""; label3.Visible = false; label4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(Mform != null) 
            {
                Mform.BackColor = Color.FromArgb(54, 57, 63);
                Mform.toDark();
            }
            if (APform != null)
            {
                APform.BackColor = Color.FromArgb(54, 57, 63);
                APform.toDark();
            }
            if (Oform != null)
            {
                Oform.BackColor = Color.FromArgb(54, 57, 63);
                Oform.toDark();
            }
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(64, 68, 75);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(220, 221, 222);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 68, 75);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(220, 221, 222);
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 68, 75);
            BackColor = Color.FromArgb(54, 57, 63);
            textBox1.BackColor = Color.FromArgb(64, 68, 75); 
            textBox2.BackColor = Color.FromArgb(64, 68, 75);
            textBox1.ForeColor = Color.FromArgb(220, 221, 222);
            textBox2.ForeColor = Color.FromArgb(220, 221, 222);
            label1.ForeColor = Color.FromArgb(220, 221, 222);
            label2.ForeColor = Color.FromArgb(220, 221, 222);
            button1.BackColor = Color.FromArgb(64, 68, 75);
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 68, 75);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(220, 221, 222);
            button2.BackColor = Color.FromArgb(64, 68, 75);
            button2.FlatAppearance.BorderColor = Color.FromArgb(64, 68, 75);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(220, 221, 222);
            button3.BackColor = Color.FromArgb(64, 68, 75);
            button3.FlatAppearance.BorderColor = Color.FromArgb(64, 68, 75);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.FromArgb(220, 221, 222);
            toolStrip1.BackColor = Color.FromArgb(54, 57, 63);
            toolStripSplitButton1.ForeColor = Color.White;
            ToolStripMenuItem1.BackColor = Color.FromArgb(64, 68, 75);
            ToolStripMenuItem1.ForeColor = Color.FromArgb(220, 221, 222);
            ToolStripMenuItem2.BackColor = Color.FromArgb(64, 68, 75);
            ToolStripMenuItem2.ForeColor = Color.FromArgb(220, 221, 222);
            toolStripButton2.ForeColor = Color.FromArgb(220, 221, 222);
            toolStripButton3.ForeColor = Color.FromArgb(220, 221, 222);
            toolStripButton4.ForeColor = Color.FromArgb(220, 221, 222);
            toolStripButton1.ForeColor = Color.FromArgb(220, 221, 222);
            White.Visible = false;
            Black.Visible = true;
        }

        private void Black_Click(object sender, EventArgs e)
        {
            if (Mform != null)
            {
                Mform.BackColor = Color.White;
                Mform.toLight();
            }
            if (APform != null)
            {
                APform.BackColor = Color.White;
                APform.toLight();
            }
            if (Oform != null)
            {
                Oform.BackColor = Color.White;
                Oform.toLight();
            }
            dataGridView1.DefaultCellStyle.BackColor= Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.White;
            BackColor = Color.White;
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;
            textBox2.ForeColor = Color.Black;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            button1.BackColor = Color.FromArgb(224, 224, 224);
            button1.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.FromArgb(224, 224, 224);
            button1.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.FromArgb(224, 224, 224);
            button2.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.FromArgb(224, 224, 224);
            button3.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Black;
            toolStrip1.BackColor = Color.White;
            toolStripSplitButton1.ForeColor = Color.Black;
            ToolStripMenuItem1.BackColor = Color.White;
            ToolStripMenuItem1.ForeColor = Color.Black;
            ToolStripMenuItem2.BackColor = Color.White;
            ToolStripMenuItem2.ForeColor = Color.Black;
            toolStripButton2.ForeColor = Color.Black;
            toolStripButton3.ForeColor = Color.Black;
            toolStripButton4.ForeColor = Color.Black;
            Black.Visible = false;
            White.Visible = true;
            toolStripButton1.ForeColor = Color.Black;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Oform = new Options();
            Oform.readConf();
            if (BackColor == Color.FromArgb(54, 57, 63))
            {
                Oform.BackColor = Color.FromArgb(54, 57, 63);
                Oform.toDark();
            }
            else
            {
                Oform.BackColor = Color.White;
            }
            Oform.Show();
        }
    }
}
