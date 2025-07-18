

using System;
using System.Collections.Generic;

namespace StudentResultSystem.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public decimal TotalMarksObtained { get; set; }  // ✅ Corrected
        public decimal TotalMaximumMarks { get; set; }   // ✅ Corrected
        public decimal Percentage { get; set; }
        public string Grade { get; set; }               // ✅ Corrected
        public string Status { get; set; }              // ✅ Corrected
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<ResultSubject> Subjects { get; set; }
    }
}
