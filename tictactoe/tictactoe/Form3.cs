using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form3 : Form
    {

        public static string listview, items;
        public static string name1, name2;
       

        public Form3()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gameform.name) || string.IsNullOrEmpty(gameform.name2) || string.IsNullOrEmpty(Form2.label))
                return;


            ListViewItem item = new ListViewItem(gameform.name);

                    item.SubItems.Add(gameform.name2);
                    item.SubItems.Add(Form2.label);

                    ListView2.Items.Add(item);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListView2.Items.Count >= 0)
                ListView2.Items.Remove(ListView2.SelectedItems[0]);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            gameform ob = new gameform();
            ob.Show();
            return;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            {

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt ", ValidateNames = true })
                {

                    

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))



                            foreach (ListViewItem item in ListView2.Items)
                            {
                                await tw.WriteLineAsync(item.SubItems[0].Text + "\t" + item.SubItems[1].Text + "\t" + item.SubItems[2].Text);
                            }

                        MessageBox.Show("Pomyślnie zapisałeś wynik rozgrywek.");

                    }

                }

            }
        }

        public void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
    }
}
