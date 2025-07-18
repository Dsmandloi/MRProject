

//using System;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Windows.Forms;
//using StudentResultSystem.Models;
//using StudentResultSystem.Data;
//using Microsoft.EntityFrameworkCore;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using System.IO;
//using System.Net.Http;
//using System.Net.Http.Json;

//namespace StudentResultSystem
//{
//    public partial class FormResult : Form
//    {
//        private readonly AppDbContext _context;
//        private int _studentId;

//        public FormResult(AppDbContext context, int studentId)
//        {
//            InitializeComponent();
//            _context = context;
//            _studentId = studentId;
//            txtStudentId.Text = _studentId.ToString();
//        }

//        private void FormResult_Load(object sender, EventArgs e)
//        {
//            LoadResultHistory();
//            dgvResultHistory.CellClick += dgvResultHistory_CellClick;
//        }

//        //private async void btnGenerateResult_Click(object sender, EventArgs e)
//        //{
//        //    if (_studentId == 0)
//        //    {
//        //        MessageBox.Show("Student ID is missing.");
//        //        return;
//        //    }

//        //    try
//        //    {
//        //        var subjects = _context.ResultSubjects
//        //            .Where(s => s.StudentId == _studentId)
//        //            .Select(s => new
//        //            {
//        //                s.SubjectName,
//        //                s.MarksObtained,
//        //                s.MaximumMarks
//        //            }).ToList();

//        //        if (subjects.Count == 0)
//        //        {
//        //            MessageBox.Show("No subjects found for this student.");
//        //            return;
//        //        }

//        //        var subjectList = subjects.Select(s => new
//        //        {
//        //            SubjectName = s.SubjectName,
//        //            MarksObtained = Convert.ToInt32(s.MarksObtained),
//        //            MaximumMarks = Convert.ToInt32(s.MaximumMarks)
//        //        }).ToList();

//        //        var request = new
//        //        {
//        //            StudentId = _studentId,
//        //            Subjects = subjectList
//        //        };

//        //        using (var client = new HttpClient())
//        //        {
//        //            string apiUrl = "https://localhost:7282/api/result/generate"; // 🔁 Update if different
//        //            var response = await client.PostAsJsonAsync(apiUrl, request);

//        //            if (response.IsSuccessStatusCode)
//        //            {
//        //                var result = await response.Content.ReadFromJsonAsync<GeneratedResultDto>();

//        //                // Fill the fields
//        //                txtTotalMarks.Text = result.TotalMaximumMarks.ToString();
//        //                txtMarksObtained.Text = result.TotalMarksObtained.ToString();
//        //                txtPercentage.Text = result.Percentage.ToString("F2");
//        //                txtGrade.Text = result.Grade;
//        //                txtStatus.Text = result.Status;
//        //                rtbComments.Rtf = result.Comments;
//        //            }
//        //            else
//        //            {
//        //                string error = await response.Content.ReadAsStringAsync();
//        //                MessageBox.Show("Error generating result:\n" + error);
//        //            }
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        MessageBox.Show("Error generating result:\n" + ex.Message);
//        //    }
//        //}
//        private async void btnGenerateResult_Click(object sender, EventArgs e)
//        {
//            if (_studentId == 0)
//            {
//                MessageBox.Show("Student ID is missing.");
//                return;
//            }

//            try
//            {
//                var subjects = _context.ResultSubjects
//                    .Where(s => s.StudentId == _studentId)
//                    .Select(s => new
//                    {
//                        s.SubjectName,
//                        s.MarksObtained,
//                        s.MaximumMarks
//                    }).ToList();

//                if (subjects.Count == 0)
//                {
//                    MessageBox.Show("No subjects found for this student.");
//                    return;
//                }

//                //var subjectList = subjects.Select(s => new
//                //{
//                //    SubjectName = s.SubjectName,
//                //    MarksObtained = Convert.ToDouble(s.MarksObtained),
//                //    MaximumMarks = Convert.ToDouble(s.MaximumMarks)
//                //}).ToList();
//                //var subjectList = subjects.Select(s => new
//                //{
//                //    SubjectName = s.SubjectName,
//                //    MarksObtained = Convert.ToInt32(s.MarksObtained),
//                //    MaximumMarks = Convert.ToInt32(s.MaximumMarks)
//                //}).ToList();
//                //var subjectList = subjects.Select(s => new
//                //{
//                //    SubjectName = s.SubjectName,
//                //    MarksObtained = Math.Round(Convert.ToDecimal(s.MarksObtained), 2),
//                //    MaximumMarks = Math.Round(Convert.ToDecimal(s.MaximumMarks), 2)
//                //}).ToList();

//                var subjectList = subjects.Select(s => new
//                {
//                    SubjectName = s.SubjectName,
//                    MarksObtained = (decimal)s.MarksObtained,
//                    MaximumMarks = (decimal)s.MaximumMarks
//                }).ToList();







//                var request = new
//                {
//                    StudentId = _studentId,
//                    Subjects = subjectList
//                };

//                using (var client = new HttpClient())
//                {
//                    string apiUrl = "https://localhost:7282/api/result/generate"; // 🔁 Replace if different
//                    var response = await client.PostAsJsonAsync(apiUrl, request);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        var result = await response.Content.ReadFromJsonAsync<GeneratedResultDto>();

//                        // Fill UI fields
//                        txtTotalMarks.Text = result.TotalMaximumMarks.ToString();
//                        txtMarksObtained.Text = result.TotalMarksObtained.ToString();
//                        txtPercentage.Text = result.Percentage.ToString("F2");
//                        txtGrade.Text = result.Grade;
//                        txtStatus.Text = result.Status;
//                        rtbComments.Rtf = result.Comments;
//                    }
//                    else
//                    {
//                        string error = await response.Content.ReadAsStringAsync();
//                        MessageBox.Show("Error generating result:\n" + error);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error generating result:\n" + ex.Message);
//            }
//        }



//        //private void btnSaveResult_Click(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        var result = new Result
//        //        {
//        //            StudentId = _studentId,
//        //            TotalMaximumMarks = double.Parse(txtTotalMarks.Text),
//        //            TotalMarksObtained = double.Parse(txtObtainedMarks.Text),
//        //            Percentage = double.TryParse(txtPercentage.Text, out var p) ? p : 0,
//        //            Grade = txtGrade.Text,
//        //            Status = txtStatus.Text,
//        //            Comments = rtbComments.Rtf,
//        //            CreatedAt = DateTime.Now
//        //        };

//        //        _context.Results.Add(result);
//        //        _context.SaveChanges();

//        //        var subjects = _context.ResultSubjects
//        //            .Where(s => s.StudentId == _studentId && s.ResultId == null)
//        //            .ToList();

//        //        foreach (var sub in subjects)
//        //            sub.ResultId = result.Id;

//        //        _context.SaveChanges();

//        //        MessageBox.Show("Result saved successfully.");
//        //        LoadResultHistory();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        MessageBox.Show($"Error: {ex.Message}\n{ex.InnerException?.Message}");
//        //    }
//        //}

//        private void btnExportPdf_Click(object sender, EventArgs e)
//        {
//            var student = _context.Students.Find(_studentId);
//            var subjects = _context.ResultSubjects
//                .Where(s => s.StudentId == _studentId)
//                .ToList();

//            using (var dlg = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = $"Result_{_studentId}.pdf" })
//            {
//                if (dlg.ShowDialog() == DialogResult.OK)
//                {
//                    using (var fs = new FileStream(dlg.FileName, FileMode.Create))
//                    using (var doc = new Document())
//                    {
//                        PdfWriter.GetInstance(doc, fs);
//                        doc.Open();

//                        // Title
//                        //var titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
//                        var titleFont = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);

//                        var title = new Paragraph("Student Result", titleFont) { Alignment = Element.ALIGN_CENTER };
//                        doc.Add(title);
//                        doc.Add(new Paragraph(" "));

//                        // Student info
//                        doc.Add(new Paragraph($"Name: {student.Name}"));
//                        doc.Add(new Paragraph($"Roll No: {student.RollNumber}"));
//                        doc.Add(new Paragraph($"Class: {student.Class}"));
//                        doc.Add(new Paragraph($"Section: {student.Section}"));
//                        doc.Add(new Paragraph(" "));

//                        // Subject table
//                        var tbl = new PdfPTable(3) { WidthPercentage = 100 };
//                        tbl.AddCell("Subject");
//                        tbl.AddCell("Obtained Marks");
//                        tbl.AddCell("Max Marks");

//                        foreach (var s in subjects)
//                        {
//                            tbl.AddCell(s.SubjectName);
//                            tbl.AddCell(s.MarksObtained.ToString());
//                            tbl.AddCell(s.MaximumMarks.ToString());
//                        }

//                        doc.Add(tbl);
//                        doc.Add(new Paragraph(" "));

//                        // Summary
//                        doc.Add(new Paragraph($"Total Obtained: {txtObtainedMarks.Text}"));
//                        doc.Add(new Paragraph($"Total Maximum: {txtTotalMarks.Text}"));
//                        doc.Add(new Paragraph($"Percentage: {txtPercentage.Text}%"));
//                        doc.Add(new Paragraph($"Grade: {txtGrade.Text}"));
//                        doc.Add(new Paragraph($"Status: {txtStatus.Text}"));
//                        doc.Add(new Paragraph(" "));

//                        // Comments
//                        doc.Add(new Paragraph("Comments:"));
//                        doc.Add(new Paragraph(rtbComments.Text));

//                        doc.Close();
//                    }

//                    MessageBox.Show("PDF exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//        }

//        private void LoadResultHistory()
//        {
//            try
//            {
//                var list = _context.Results
//                    .Include(r => r.Student)
//                    .Where(r => r.StudentId == _studentId)
//                    .Select(r => new
//                    {
//                        r.Id,
//                        r.Student.Name,
//                        r.TotalMaximumMarks,
//                        r.TotalMarksObtained,
//                        r.Percentage,
//                        r.Grade,
//                        r.Status
//                    })
//                    .ToList();

//                dgvResultHistory.DataSource = list;
//                AddActionButtonsToGrid();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading history: {ex.Message}");
//            }
//        }

//        private void AddActionButtonsToGrid()
//        {
//            if (dgvResultHistory.Columns["Edit"] == null)
//            {
//                dgvResultHistory.Columns.Add(new DataGridViewButtonColumn
//                {
//                    Name = "Edit",
//                    HeaderText = "Edit",
//                    Text = "Edit",
//                    UseColumnTextForButtonValue = true
//                });
//                dgvResultHistory.Columns.Add(new DataGridViewButtonColumn
//                {
//                    Name = "Delete",
//                    HeaderText = "Delete",
//                    Text = "Delete",
//                    UseColumnTextForButtonValue = true
//                });
//            }
//        }

//        private void dgvResultHistory_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;
//            var row = dgvResultHistory.Rows[e.RowIndex];
//            int id = (int)row.Cells["Id"].Value;

//            if (dgvResultHistory.Columns[e.ColumnIndex].Name == "Edit")
//            {
//                var res = _context.Results.Find(id);
//                if (res != null)
//                {
//                    txtTotalMarks.Text = res.TotalMaximumMarks.ToString();
//                    txtObtainedMarks.Text = res.TotalMarksObtained.ToString();
//                    txtPercentage.Text = res.Percentage.ToString("F2");
//                    txtGrade.Text = res.Grade;
//                    txtStatus.Text = res.Status;
//                    rtbComments.Rtf = res.Comments ?? "";
//                }
//            }
//            else if (dgvResultHistory.Columns[e.ColumnIndex].Name == "Delete")
//            {
//                var res = _context.Results.Find(id);
//                if (res != null && MessageBox.Show("Delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
//                {
//                    _context.Results.Remove(res);
//                    _context.SaveChanges();
//                    LoadResultHistory();
//                }
//            }
//        }

//        private void txtStudentId_TextChanged(object sender, EventArgs e)
//        {
//            // No action required here
//        }
//    }

//    // 🔸 DTO used for result API response
//    //public class GeneratedResultDto
//    //{
//    //    public int TotalMarksObtained { get; set; }
//    //    public int TotalMaximumMarks { get; set; }
//    //    public double Percentage { get; set; }
//    //    public string Grade { get; set; }
//    //    public string Status { get; set; }
//    //    public string Comments { get; set; }
//    //}
//    public class GeneratedResultDto
//    {
//        public decimal TotalMarksObtained { get; set; }
//        public decimal TotalMaximumMarks { get; set; }
//        public decimal Percentage { get; set; }
//        public string Grade { get; set; }
//        public string Status { get; set; }
//        public string Comments { get; set; }
//    }


//}

using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using StudentResultSystem.Data;
using StudentResultSystem.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace StudentResultSystem
{
    public partial class FormResult : Form
    {
        private readonly AppDbContext _context;
        private int _studentId;

        public FormResult(AppDbContext context, int studentId)
        {
            InitializeComponent();
            _context = context;
            _studentId = studentId;
            txtStudentId.Text = _studentId.ToString();
        }

        private void FormResult_Load(object sender, EventArgs e)
        {
            LoadResultHistory();
            dgvResultHistory.CellClick += dgvResultHistory_CellClick;
        }

        //private async void btnGenerateResult_Click(object sender, EventArgs e)
        //{
        //    if (_studentId == 0)
        //    {
        //        MessageBox.Show("Student ID is missing.");
        //        return;
        //    }

        //    try
        //    {
        //        var subjects = _context.ResultSubjects
        //            .Where(s => s.StudentId == _studentId)
        //            .Select(s => new
        //            {
        //                s.SubjectName,
        //                s.MarksObtained,
        //                s.MaximumMarks
        //            })
        //            .ToList();

        //        if (subjects.Count == 0)
        //        {
        //            MessageBox.Show("No subjects found for this student.");
        //            return;
        //        }

        //        // Keep everything as decimal (do NOT cast)
        //        var subjectList = subjects.Select(s => new
        //        {
        //            SubjectName = s.SubjectName,
        //            MarksObtained = Convert.ToDecimal(s.MarksObtained),
        //            MaximumMarks = Convert.ToDecimal(s.MaximumMarks)
        //        }).ToList();


        //        var request = new
        //        {
        //            StudentId = _studentId,
        //            Subjects = subjectList
        //        };

        //        using (var client = new HttpClient())
        //        {
        //            string apiUrl = "https://localhost:7282/api/result/generate";
        //            var response = await client.PostAsJsonAsync(apiUrl, request);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var result = await response.Content.ReadFromJsonAsync<GeneratedResultDto>();

        //                txtTotalMarks.Text = result.TotalMaximumMarks.ToString("F2");
        //                txtMarksObtained.Text = result.TotalMarksObtained.ToString("F2");
        //                txtPercentage.Text = result.Percentage.ToString("F2");
        //                txtGrade.Text = result.Grade;
        //                txtStatus.Text = result.Status;
        //                rtbComments.Rtf = result.Comments;
        //            }
        //            else
        //            {
        //                string error = await response.Content.ReadAsStringAsync();
        //                MessageBox.Show("Error generating result:\n" + error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error generating result:\n" + ex.Message);
        //    }
        //}
        private async void btnGenerateResult_Click(object sender, EventArgs e)
        {
            if (_studentId == 0)
            {
                MessageBox.Show("Student ID is missing.");
                return;
            }

            try
            {
                var subjects = _context.ResultSubjects
                    .Where(s => s.StudentId == _studentId)
                    .Select(s => new
                    {
                        s.SubjectName,
                        MarksObtained = (decimal)s.MarksObtained,
                        MaximumMarks = (decimal)s.MaximumMarks
                    })
                    .ToList();

                if (subjects.Count == 0)
                {
                    MessageBox.Show("No subjects found for this student.");
                    return;
                }

                var subjectList = subjects.Select(s => new
                {
                    s.SubjectName,
                    s.MarksObtained,
                    s.MaximumMarks
                }).ToList();

                var request = new
                {
                    StudentId = _studentId,
                    Subjects = subjectList
                };

                using (var client = new HttpClient())
                {
                    //string apiUrl = "https://localhost:7282/api/result/generate";
                    string apiUrl = "https://localhost:7191/api/result/generate";

                    // Serialize manually to avoid decimal issue
                    var json = System.Text.Json.JsonSerializer.Serialize(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();
                        var result = System.Text.Json.JsonSerializer.Deserialize<GeneratedResultDto>(responseJson, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        txtTotalMarks.Text = result.TotalMaximumMarks.ToString("F2");
                        txtMarksObtained.Text = result.TotalMarksObtained.ToString("F2");
                        txtPercentage.Text = result.Percentage.ToString("F2");
                        txtGrade.Text = result.Grade;
                        txtStatus.Text = result.Status;
                        rtbComments.Rtf = result.Comments;
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error generating result:\n" + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating result:\n" + ex.Message);
            }
        }



        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            var student = _context.Students.Find(_studentId);
            var subjects = _context.ResultSubjects.Where(s => s.StudentId == _studentId).ToList();

            using (var dlg = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = $"Result_{_studentId}.pdf" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new FileStream(dlg.FileName, FileMode.Create))
                    using (var doc = new Document())
                    {
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        var titleFont = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD);
                        var title = new Paragraph("Student Result", titleFont) { Alignment = Element.ALIGN_CENTER };
                        doc.Add(title);
                        doc.Add(new Paragraph(" "));

                        doc.Add(new Paragraph($"Name: {student.Name}"));
                        doc.Add(new Paragraph($"Roll No: {student.RollNumber}"));
                        doc.Add(new Paragraph($"Class: {student.Class}"));
                        doc.Add(new Paragraph($"Section: {student.Section}"));
                        doc.Add(new Paragraph(" "));

                        var tbl = new PdfPTable(3) { WidthPercentage = 100 };
                        tbl.AddCell("Subject");
                        tbl.AddCell("Obtained Marks");
                        tbl.AddCell("Max Marks");

                        foreach (var s in subjects)
                        {
                            tbl.AddCell(s.SubjectName);
                            tbl.AddCell(s.MarksObtained.ToString());
                            tbl.AddCell(s.MaximumMarks.ToString());
                        }

                        doc.Add(tbl);
                        doc.Add(new Paragraph(" "));

                        doc.Add(new Paragraph($"Total Obtained: {txtObtainedMarks.Text}"));
                        doc.Add(new Paragraph($"Total Maximum: {txtTotalMarks.Text}"));
                        doc.Add(new Paragraph($"Percentage: {txtPercentage.Text}%"));
                        doc.Add(new Paragraph($"Grade: {txtGrade.Text}"));
                        doc.Add(new Paragraph($"Status: {txtStatus.Text}"));
                        doc.Add(new Paragraph(" "));

                        doc.Add(new Paragraph("Comments:"));
                        doc.Add(new Paragraph(rtbComments.Text));

                        doc.Close();
                    }

                    MessageBox.Show("PDF exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void LoadResultHistory()
        {
            try
            {
                var list = _context.Results
                    .Include(r => r.Student)
                    .Where(r => r.StudentId == _studentId)
                    .Select(r => new
                    {
                        r.Id,
                        r.Student.Name,
                        r.TotalMaximumMarks,
                        r.TotalMarksObtained,
                        r.Percentage,
                        r.Grade,
                        r.Status
                    })
                    .ToList();

                dgvResultHistory.DataSource = list;
                AddActionButtonsToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading history: {ex.Message}");
            }
        }

        private void AddActionButtonsToGrid()
        {
            if (dgvResultHistory.Columns["Edit"] == null)
            {
                dgvResultHistory.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                });
                dgvResultHistory.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                });
            }
        }

        private void dgvResultHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvResultHistory.Rows[e.RowIndex];
            int id = (int)row.Cells["Id"].Value;

            if (dgvResultHistory.Columns[e.ColumnIndex].Name == "Edit")
            {
                var res = _context.Results.Find(id);
                if (res != null)
                {
                    txtTotalMarks.Text = res.TotalMaximumMarks.ToString();
                    txtObtainedMarks.Text = res.TotalMarksObtained.ToString();
                    txtPercentage.Text = res.Percentage.ToString("F2");
                    txtGrade.Text = res.Grade;
                    txtStatus.Text = res.Status;
                    rtbComments.Rtf = res.Comments ?? "";
                }
            }
            else if (dgvResultHistory.Columns[e.ColumnIndex].Name == "Delete")
            {
                var res = _context.Results.Find(id);
                if (res != null && MessageBox.Show("Delete?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _context.Results.Remove(res);
                    _context.SaveChanges();
                    LoadResultHistory();
                }
            }
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {
            // No action required here
        }
    }

    public class GeneratedResultDto
    {
        public decimal TotalMarksObtained { get; set; }
        public decimal TotalMaximumMarks { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
    }


}
