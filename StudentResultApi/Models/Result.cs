
using System;
using System.Collections.Generic;

namespace StudentResultApi.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public double TotalMarksObtained { get; set; }
        public double TotalMaximumMarks { get; set; }
        public double Percentage { get; set; }
        public string Grade { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now; // ✅ Default value

        public List<ResultSubject> Subjects { get; set; }
    }
}
