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

namespace Student_Manager.Forms
{
    public partial class MainForm : Form
    {
        //box with students and tools to manage them
        private readonly StudentRepository _repository = new StudentRepository();
        //where exactly save 'students.txt' on the disk - defines absolute path
        private readonly string _filePath = Path.Combine(Application.StartupPath, "students.txt");
        public MainForm()
        {
            InitializeComponent();
            SetupGrid();
            LoadClasses();
        }
        private void SetupGrid()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "First Name", DataPropertyName = "FirstName" });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Last Name", DataPropertyName = "LastName" });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Class", DataPropertyName = "ClassName" });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Age", DataPropertyName = "Age" });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Present", DataPropertyName = "Present" });
        }
        private void LoadClasses()
        {
            cmbFilterClass.Items.Clear();
            cmbFilterClass.Items.Add("All");
            cmbFilterClass.Items.Add("1A");
            cmbFilterClass.Items.Add("1B");
            cmbFilterClass.Items.Add("2A");
            cmbFilterClass.Items.Add("2B");
            cmbFilterClass.Items.Add("3A");
            cmbFilterClass.Items.Add("3B");
            cmbFilterClass.SelectedIndex = 0;
        }

        private void RefreshGrid()
        {
            var filtered = _repository.FilterStudents(txtSearch.Text, cmbFilterClass.Text);
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = filtered;

            lblTotal.Text = $"Total: {_repository.GetTotalStudent()}";
            lblAverageAge.Text = $"Average age: {_repository.GetAverageAge()}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (StudentForm form = new StudentForm())
            {
                if (form.ShowDialog() == DialogResult.OK || form.StudentResult != null)
                {
                    if (!_repository.AddStudent(form.StudentResult))
                    {
                        MessageBox.Show("Student with the same first and last name already exists.");
                        return;
                    }
                    RefreshGrid();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null || !(dgvStudents.CurrentRow?.DataBoundItem is Student selected))
                return;

            int index = _repository.GetAll().FindIndex(s =>
                s.FirstName == selected.FirstName &&
                s.LastName == selected.LastName &&
                s.ClassName == selected.ClassName &&
                s.Age == selected.Age);

            using (StudentForm form = new StudentForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK && form.StudentResult != null)
                {
                    _repository.UpdateStudent(index, form.StudentResult);
                    RefreshGrid();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            int rowIndex = dgvStudents.CurrentRow.Index;
            var visibleList = _repository.FilterStudents(txtSearch.Text, cmbFilterClass.Text);
            if (rowIndex < 0 || rowIndex > visibleList.Count) return;

            var student = visibleList[rowIndex];
            var realIndex = _repository.GetAll().FindIndex(s =>
                s.FirstName == student.FirstName &&
                s.LastName == student.LastName &&
                s.ClassName == student.ClassName &&
                s.Age == student.Age &&
                s.Present == student.Present);

            if (realIndex >= 0)
            {
                _repository.DeleteStudent(realIndex);
                RefreshGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _repository.SaveStudentsToFile(_filePath);
            MessageBox.Show("Saved");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _repository.LoadStudentFromFile(_filePath);
            RefreshGrid();
            MessageBox.Show("Loaded");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterClass.SelectedIndex = 0;
            RefreshGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //RefreshGrid();
        }

        private void cmbFilterClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshGrid();
        }
    }
}