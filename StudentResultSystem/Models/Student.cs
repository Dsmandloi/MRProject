//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using StudentResultSystem.Models;
//namespace StudentResultSystem.Models
//{
//    //internal class Student
//    //{
//    //}
//    public class Student
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string RollNumber { get; set; }
//        public string Class { get; set; }
//       // public string Section { get; set; }
//        public string? Section { get; set; }

//        public List<ResultSubject> Subjects { get; set; }
//        public Result Result { get; set; }
//    }
//}
namespace StudentResultSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public string Class { get; set; }
        public string? Section { get; set; }

        public virtual Result Result { get; set; }
    }
}
