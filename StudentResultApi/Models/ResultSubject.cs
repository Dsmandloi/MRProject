
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StudentResultApi.Models; // Ensure this is correct based on your project structure

namespace StudentResultApi.Models
{
    public class ResultSubject
    {
        public int Id { get; set; }

        [ForeignKey("Result")]
        //public int ResultId { get; set; }
        public int? ResultId { get; set; }  // ✅ Nullable int

        public int StudentId { get; set; }

        public Result Result { get; set; }

        [Required]
        public string SubjectName { get; set; }


        [Column(TypeName = "decimal(5,2)")]
        public decimal MarksObtained { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal MaximumMarks { get; set; }

        [MaxLength(10)]
        public string Grade { get; set; }
    }
}
