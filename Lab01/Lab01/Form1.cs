using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testScript;

namespace Lab01
{
   
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string studentId=textBoxStudentId.Text;
            int studentNumber;
            bool isNumeric = int.TryParse(studentId, out studentNumber);
            string studentName = textBoxStudentName.Text;
            string studentSurname = textBoxStudentSurname.Text;
            string box = textBox4.Text;
            string student;
            int number = 0;
            int letter = 0;
            int score;
            //Console.WriteLine(studentNumber + studentName+studentSurname+number+letter);
            testClass test = new testClass();
 
            //if (studentId.Trim() == "") return;
            //if (studentName.Trim() == "") return;
            //if (studentSurname.Trim() == "") return;
            if (studentId.Length != 8) MessageBox.Show("Your number must involve 8 digits!!");
            else
            {
              
                foreach (char c in box)
                {
                    if (char.IsLetter(c))
                    {
                        letter++;
                    }
                    else if (char.IsDigit(c))
                    {
                        number++;
                    }

                }

                score = test.testFunc(studentNumber, studentName, studentSurname, box, number, letter);
                student = "Student number: " + studentId + Environment.NewLine + "First name: " + studentName + Environment.NewLine + "Last name: " + studentSurname + Environment.NewLine + "Quantity of letter of text: " + letter.ToString() + Environment.NewLine + "Quantity of number of text: "
                + number.ToString() + Environment.NewLine + "Student score: " + score.ToString();

                textBoxOutput.Text = student;
              
            }

        }

        private void textBoxStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // ignore non-numeric characters
            }
        }

        private void textBoxStudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }

        }

        private void textBoxStudentSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true; // ignore non-alphanumeric characters
            }
            
        }

    }
}
