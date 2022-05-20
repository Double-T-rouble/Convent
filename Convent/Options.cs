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
    public partial class Options : Form
    {
        public Options()
        {

            InitializeComponent();
        }

        public void toDark()
        {
            BackColor = Color.FromArgb(54, 57, 63);
            label1.ForeColor = Color.FromArgb(220, 221, 222);
            label2.ForeColor = Color.FromArgb(220, 221, 222);
            label3.ForeColor = Color.FromArgb(220, 221, 222);
            label4.ForeColor = Color.FromArgb(220, 221, 222);
            label5.ForeColor = Color.FromArgb(220, 221, 222);
            radioButton1.ForeColor = Color.FromArgb(220, 221, 222);
            radioButton2.ForeColor = Color.FromArgb(220, 221, 222);
            checkBox1.ForeColor = Color.FromArgb(220, 221, 222);
            textBox1.BackColor = Color.FromArgb(64, 68, 75);
            textBox1.ForeColor = Color.FromArgb(220, 221, 222);
            textBox2.BackColor = Color.FromArgb(64, 68, 75);
            textBox2.ForeColor = Color.FromArgb(220, 221, 222);
            textBox3.BackColor = Color.FromArgb(64, 68, 75);
            textBox3.ForeColor = Color.FromArgb(220, 221, 222);
            textBox4.BackColor = Color.FromArgb(64, 68, 75);
            textBox4.ForeColor = Color.FromArgb(220, 221, 222);
            button1.BackColor = Color.FromArgb(64, 68, 75);
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 68, 75);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.FromArgb(220, 221, 222);
            button2.BackColor = Color.FromArgb(64, 68, 75);
            button2.FlatAppearance.BorderColor = Color.FromArgb(64, 68, 75);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(220, 221, 222);

        }
        public void toLight()
        {
            BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            checkBox1.ForeColor = Color.Black;
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.Black;
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.Black;
            textBox3.BackColor = Color.White;
            textBox3.ForeColor = Color.Black;
            textBox4.BackColor = Color.White;
            textBox4.ForeColor = Color.Black;
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
        }

        public void readConf() 
        {
            String[] conf = File.ReadAllLines("config.txt");
            if (conf[0] == ",") 
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false ;
            }   
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }


            if (conf[1] == "+")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;

            textBox1.Text = conf[2];
            textBox2.Text = conf[3];
            textBox3.Text = conf[4];
            textBox4.Text = conf[5];

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] content = new string[6];

            if (radioButton1.Checked == true)
                content[0] = ",";
            else
                content[0] = ".";

            if (checkBox1.Checked == true)
                content[1] = "+";
            else
                content[1] = "-";
            content[2] = textBox1.Text;
            content[3] = textBox2.Text;
            content[4] = textBox3.Text;
            content[5] = textBox4.Text;
            File.WriteAllLines("config.txt", content);
            MessageBox.Show("Сохранения будут применены после перезагрузки приложения.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            checkBox1.Checked = true;
            textBox1.Text = "Это не число";
            textBox2.Text = "Неправильный формат";
            textBox3.Text = "Уверены, что хотите выйти?";
            textBox4.Text = "Восстановить удалённые данные будет невозможно, всё равно удалить ?";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
