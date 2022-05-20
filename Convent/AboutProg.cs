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
    public partial class AboutProg : Form
    {
        public AboutProg()
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
            label6.ForeColor = Color.FromArgb(220, 221, 222);
            label7.ForeColor = Color.FromArgb(220, 221, 222);
        }
        public void toLight()
        {
            BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
