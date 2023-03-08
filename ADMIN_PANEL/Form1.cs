using ADMIN_PANEL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN_PANEL
{
    public partial class Form1 : Form
    {
        student e = new student();
        studentlogiclayer std = new studentlogiclayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            student s = new student();
            studentlogiclayer std = new studentlogiclayer();
            s.name = textBox1.Text;
            s.contact = textBox2.Text;
            s.dob = dateTimePicker1.Value;

            int i = std.insert(s);

            if (i != 0 || i != -1)
            {

                dataGridView1.DataSource = std.getallStudent();
                MessageBox.Show("Data Successfully Inserted");
            }
            else
            {
                MessageBox.Show("Data Not Successfully Inserted");

            }





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = std.getallStudent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            student s = new student();

            if (checkBox1.Checked)
            {
                s = std.getstudent(Convert.ToInt32(textBox5.Text));
                if (s != null)
                {

                    textBox4.Text = s.name;
                    dateTimePicker2.Value = s.dob;

                    textBox3.Text = s.contact;
                }
                else
                {
                    MessageBox.Show("No record  found......");
                }


            }
        }
    }
}