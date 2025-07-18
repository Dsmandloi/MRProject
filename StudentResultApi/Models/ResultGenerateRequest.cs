namespace StudentResultApi.Models
{
    public class ResultGenerateRequest
    {
        public int StudentId { get; set; }
        public List<SubjectInput> Subjects { get; set; }
        public string Comments { get; set; }
    }
}
