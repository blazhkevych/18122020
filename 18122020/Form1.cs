using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace _18122020
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();
            students.AddRange(new Student[] {
                new Student{Name="Petro",Age= 10 },
                new Student{Name="Ivan",Age= 100 },
                new Student{Name="Stepan",Age= 50 },
                new Student{Name="Ira",Age= 60 },            
            });
            listBox3.DataSource = students;
            listBox3.DisplayMember = "Name";
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Виберіть студента");
                return;
            }
            // textBox1.Text = comboBox1.Text;

            // textBox1.Text = (string)comboBox1.SelectedItem;
            // textBox1.Text = ""+ comboBox1.SelectedIndex;

            if (comboBox1.SelectedItem is Student st)
            {
                int pos = comboBox1.SelectedIndex;
                comboBox1.Items.RemoveAt(pos);
                st.Age += 2;
                comboBox1.Items.Insert(pos,st);
                comboBox1.SelectedIndex = pos;
               // comboBox1.Focus();
            }
          //  comboBox1.Refresh();
        }

        private void buttonAddCB_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Ira");
            comboBox1.Items.Add(123456);
            comboBox1.Items.Add(new Student {Name= "Piter Pen", Age=16 });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           textBox1.Text = ""+comboBox1.SelectedItem;
           // textBox1.Text = comboBox1.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = true;
            if (e.KeyChar == 13)
            {
                buttonSelect_Click(sender, e);
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           // label1.Text = textBox1.Text;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char c = e.KeyChar;
            if (!Char.IsDigit(c) && !(c==8))
            {               
                e.Handled = true;
            }
        }

        private void buttonAddLB_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Ira");
            listBox1.Items.Add(123456);
            listBox1.Items.Add(new Student { Name = "Piter Pen", Age = 16 });

            
          //  listBox1.Items.AddRange(new object[] {"dwsaef","wefwe" });
            listBox1.Items.AddRange(  Enumerable.Range(0, 11).Select(i=>""+i).ToArray());
          

            ;
        }

        private void buttonSHOW_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {  
                listBox2.Items.Clear();
                //listBox2.Items.Add(listBox1.SelectedIndex);
                //listBox2.Items.Add(listBox1.SelectedItem);
                //listBox2.Items.AddRange(listBox1
                //    .SelectedItems
                //    .Cast<object>()
                //    .ToArray());

                listBox2.Items.AddRange(listBox1
                    .SelectedIndices
                    .Cast<object>()
                    .ToArray());

            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //while (listBox1.SelectedItem != null) 
            //    listBox1.Items.Remove(listBox1.SelectedItem);

           var indexDEl= listBox1
                .SelectedIndices
                .Cast<int>()
                .Reverse()
                .ToList();

            foreach (int item in indexDEl)
               listBox1.Items.RemoveAt(item);
         
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  listBox3.Items.Add(new Student { Name = "Maks", Age = 60 });
            students.Add(new Student { Name = "Maks", Age = 60 });
         
            listBox3.DataSource = null;
            listBox3.DataSource = students;
            listBox3.DisplayMember = "Name";
        }
    }   
}
