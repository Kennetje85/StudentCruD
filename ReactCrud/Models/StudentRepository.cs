namespace ReactCrud.Models
{
    public interface StudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> AddStudent(Student ObjStudent);
        Task<Student> UpdateStudent(Student objStudent);
        public bool DeleteStudent(int id);
        Task<IEnumerable<Student>> FindStudent(string stname);
    }
}
