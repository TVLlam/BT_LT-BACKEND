using Dependencylnjection.Models;

namespace Dependencylnjection.Services
{
    public class StudentService : IStudentService
    {
        static List<Student> Students = new List<Student>()
    {
        new Student (){Id=1, Name= "Le Van A", Phone="0972882648"},
        new Student (){Id=2, Name= "Le Van B", Phone="0972882648"},
        new Student (){Id=3, Name= "Le Van C", Phone="0972882648"},
    };
        public List<Student> GetAllStudents()
        { return Students; }
    }
}
