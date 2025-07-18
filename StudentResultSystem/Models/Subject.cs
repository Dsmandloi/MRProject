
namespace StudentResultSystem.Models
{
    public class ResultSubject
    {
        public int Id { get; set; }

        // ✅ Add StudentId to support subject-wise entry before result is generated
        public int StudentId { get; set; }


        public int? ResultId { get; set; }
        public virtual Result Result { get; set; }

        public string SubjectName { get; set; }
        public int MarksObtained { get; set; }
        public int MaximumMarks { get; set; }
        public string Grade { get; set; }
    }
}
