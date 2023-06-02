using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactCrud.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using System.ComponentModel.DataAnnotations;

namespace ReactCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase, StudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }


        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Student.ToListAsync();
        }

  
        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student ObjStudent)
        {
            _studentDbContext.Student.Add(ObjStudent);
            await _studentDbContext.SaveChangesAsync();
            return ObjStudent;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]

        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDbContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objStudent;

        }

        [HttpGet]
        [Route("FindStudent/{Stname}")]
        public async Task<IEnumerable<Student>> FindStudent(string Stname)
        {
            IQueryable<Student> query = _studentDbContext.Student;
            if (!string.IsNullOrEmpty(Stname))
            {
                query = query.Where(a => a.stname.Contains(Stname));
            }
            return query.ToList();

        }


        [HttpDelete]
        [Route("DeleteStudent/{id}")]

        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _studentDbContext.Student.Find(id);
            if (student != null)
            {
                a = true;
                _studentDbContext.Entry(student).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Deleted;
                _studentDbContext.SaveChanges();
            }
            else
            {
                a = false;

            }
            return a;
        }

    }
    
}
