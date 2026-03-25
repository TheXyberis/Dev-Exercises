using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_Manager;
using System.Windows.Forms;

namespace Student_Manager.Forms
{
    public partial class StudentForm : Form
    {
        public Student StudentResult { get; private set; }
        public StudentForm()
        {
            InitializeComponent();

            comboBoxCLass.Items.Clear();
            comboBoxCLass.Items.AddRange(new object[] { "1A", "1B", "2A", "2B", "3A", "3B" });

            nudAge.Minimum = 6;
            nudAge.Maximum = 21;

            cbPresent.Checked = true;
        }

        //overloaded constructor
        public StudentForm(Student student) : this() //calls the default constructor first
        {
            textBoxFirstName.Text = student.FirstName; //assigning values
            textBoxLastName.Text = student.LastName;
            comboBoxCLass.Text = student.ClassName;
            nudAge.Value = student.Age;
            cbPresent.Checked = student.Present;
        }

        public bool ValidateStudentForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text)) return false;
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text)) return false;
            if (string.IsNullOrWhiteSpace(comboBoxCLass.Text)) return false;
            if (nudAge.Value < 6 || nudAge.Value > 21) return false;
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentForm())
            {
                MessageBox.Show("Please complete all fields. Age must be from 6 to 21.");
                return;
            }

            StudentResult = new Student
            {
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                ClassName = comboBoxCLass.Text.Trim(),
                Age = (int)nudAge.Value,
                Present = cbPresent.Checked
            };

            DialogResult = DialogResult.OK;
            Close(); //close the student form
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
