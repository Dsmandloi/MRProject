
using System.ComponentModel.DataAnnotations;

namespace StudentResultApi.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string RollNumber { get; set; } = string.Empty;

        [Required]
        public string Class { get; set; } = string.Empty;

        public List<Result> Results { get; set; } = new();
    }
}

