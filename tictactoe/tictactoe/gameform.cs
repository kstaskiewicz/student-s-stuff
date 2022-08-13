using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class gameform : Form
    {
        public static string name, name2;
        public gameform()
        {
            InitializeComponent();
        }

       public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " " && textBox2.Text != " ")
            {
                name = textBox1.Text;
                name2 = textBox2.Text;
                this.Hide();
                Form1 ob = new Form1();
                ob.Show();
            }
        }
    }
}
