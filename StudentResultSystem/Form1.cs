

using Microsoft.EntityFrameworkCore;
using StudentResultSystem.Data;
using StudentResultSystem.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StudentResultSystem
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;

        public Form1(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = _context.Students.ToList();
            dgvStudents.DataSource = students;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        //private void LoadStudents()
        //{
        //    var students = _context.Students.ToList();
        //    dgvStudents.DataSource = students;

        //    // Add Edit/Delete buttons only once
        //    if (!dgvStudents.Columns.Contains("Edit"))
        //    {
        //        DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
        //        {
        //            Name = "Edit",
        //            Text = "Edit",
        //            UseColumnTextForButtonValue = true
        //        };
        //        dgvStudents.Columns.Add(editButton);
        //    }

        //    if (!dgvStudents.Columns.Contains("Delete"))
        //    {
        //        DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
        //        {
        //            Name = "Delete",
        //            Text = "Delete",
        //            UseColumnTextForButtonValue = true
        //        };
        //        dgvStudents.Columns.Add(deleteButton);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string roll = txtRoll.Text.Trim();
            string studentClass = txtClass.Text.Trim();
            string section = txtSection.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(roll))
            {
                MessageBox.Show("Please enter both Name and Roll Number.");
                return;
            }

            var existingStudent = _context.Students.FirstOrDefault(s => s.RollNumber == roll);
            if (existingStudent != null)
            {
                MessageBox.Show("Student with this Roll Number already exists.");
                return;
            }

            Student student = new Student
            {
                Name = name,
                RollNumber = roll,
                Class = studentClass,
                Section = section
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            MessageBox.Show("Student saved successfully!");
            ClearInputs();
            LoadStudents();
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtRoll.Clear();
            txtClass.Clear();
            txtSection.Clear();
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int studentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["Id"].Value);

                if (dgvStudents.Columns[e.ColumnIndex].Name == "Edit")
                {
                    var student = _context.Students.Find(studentId);
                    if (student != null)
                    {
                        txtName.Text = student.Name;
                        txtRoll.Text = student.RollNumber;
                        txtClass.Text = student.Class;
                        txtSection.Text = student.Section;

                        // Delete and re-insert as update for simplicity
                        _context.Students.Remove(student);
                        _context.SaveChanges();
                        LoadStudents();
                    }
                }
                else if (dgvStudents.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var student = _context.Students.Find(studentId);
                    if (student != null)
                    {
                        var confirm = MessageBox.Show("Are you sure to delete this student?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirm == DialogResult.Yes)
                        {
                            _context.Students.Remove(student);
                            _context.SaveChanges();
                            LoadStudents();
                        }
                    }
                }
            }
        }

        private void btnOpenSubjectForm_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int selectedStudentId = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["Id"].Value);

                // resultId is 0 for new entries (or adjust as needed)
                int resultId = 0;

                FormSubject subjectForm = new FormSubject(_context, resultId, selectedStudentId);
                subjectForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a student to add subjects.");
            }

        }
        //private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        int selectedStudentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["Id"].Value);
        //        var subjectForm = new FormSubject(_context, selectedStudentId, 0); // or use a valid resultId if you have it
        //        subjectForm.ShowDialog();
        //    }
        //}
        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedStudentId = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["Id"].Value);
                var subjectForm = new FormSubject(_context, 0,selectedStudentId); // resultId agar aage chahiye toh use kro
                subjectForm.ShowDialog();
            }
        }


        // Optional label/text events
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void txtSection_TextChanged(object sender, EventArgs e) { }
    }
}
