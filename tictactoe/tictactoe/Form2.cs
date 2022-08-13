using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tictactoe
{
    public partial class Form2 : Form
    {

        
        public static string label;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ob = new Form1();
            ob.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button3_Click(object sender, EventArgs e)
        {
     


            this.Hide();
            Form3 ob3 = new Form3();
            ob3.Show();

        }


        private void Form2_Load(object sender, EventArgs e)
        {

            label = label1.Text;

            if (Form1.status==0)
            {
                label = "Remis!";
            }
            else if (Form1.status==1)
            {
                label = "Gracz " + gameform.name + " wygrał!";
            }
            else
            {
                label = "Gracz " + gameform.name2 + " wygrał!";
            }
        }

        
    }
}
