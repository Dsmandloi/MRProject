namespace StudentResultApi.Models
{
    public class SubjectInput
    {
        //public string Subject { get; set; }
        //public double Marks { get; set; }
        //public double MaxMarks { get; set; }

        public string SubjectName { get; set; } = string.Empty;
        public decimal MarksObtained { get; set; }
        public decimal MaximumMarks { get; set; }
    }
}
