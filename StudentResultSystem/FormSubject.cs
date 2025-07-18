



using System;
using System.Linq;
using System.Windows.Forms;
using StudentResultSystem.Data;
using StudentResultSystem.Models;

namespace StudentResultSystem
{
    public partial class FormSubject : Form
    {
        private readonly AppDbContext _context;
        private readonly int _resultId;
        private readonly int _studentId;

        public FormSubject(AppDbContext context, int resultId, int studentId)
        {
            InitializeComponent();
            _context = context;
            _resultId = resultId;
            _studentId = studentId;

            // Student ID TextBox me show karna
            txtStudentId.Text = _studentId.ToString();
            txtStudentId.ReadOnly = true; // Optional: User ko edit na karne dena
        }

        private void btnSaveSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
                {
                    MessageBox.Show("Please enter subject name.");
                    return;
                }

                if (!int.TryParse(txtMarksObtained.Text, out int marksObtained) ||
                    !int.TryParse(txtMaxMarks.Text, out int maxMarks))
                {
                    MessageBox.Show("Please enter valid marks.");
                    return;
                }

                if (marksObtained > maxMarks)
                {
                    MessageBox.Show("Marks Obtained cannot be greater than Maximum Marks.");
                    return;
                }

                double percentage = (double)marksObtained / maxMarks * 100;
                string grade = GetGrade(percentage);

                var subject = new ResultSubject
                {
                    StudentId = _studentId,
                    SubjectName = txtSubjectName.Text.Trim(),
                    MarksObtained = marksObtained,
                    MaximumMarks = maxMarks,
                    Grade = grade
                };

                _context.ResultSubjects.Add(subject);
                _context.SaveChanges();

                MessageBox.Show("Subject saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n" + ex.InnerException?.Message);
            }
        }

        private string GetGrade(double percentage)
        {
            if (percentage >= 90) return "A+";
            else if (percentage >= 80) return "A";
            else if (percentage >= 70) return "B";
            else if (percentage >= 60) return "C";
            else if (percentage >= 50) return "D";
            else return "F";
        }

        private void FormSubject_Load(object sender, EventArgs e)
        {
            // You can add any other logic you need when the form loads
        }

        //private void btnOpenResultForm_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Result form open hoga yahan.");
        //}
        private void btnOpenResultForm_Click(object sender, EventArgs e)
        {
            if (_studentId <= 0)
            {
                MessageBox.Show("Invalid student ID.");
                return;
            }

            var resultForm = new FormResult(_context, _studentId); // pass context and studentId
            resultForm.ShowDialog();
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            // If needed
        }
    }
}
