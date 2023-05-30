using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactCrud.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using System.Linq.Expressions;

namespace ReactCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public ProjectController(StudentDbContext projectDbContext)
        {
            _studentDbContext = projectDbContext;
        }

        [HttpGet]
        [Route("GetProject")]
        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _studentDbContext.Project.ToListAsync();
        }

        [HttpPost]
        [Route("AddProject")]
        public async Task<Project> AddProject(Project objProject)
        {
            _studentDbContext.Project.Add(objProject);
            await _studentDbContext.SaveChangesAsync();
            return objProject;
        }

        [HttpPatch]
        [Route("EditProject")]
        public async Task<Project> EditProject(Project objProject)
        {
            _studentDbContext.Entry(objProject).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return objProject;
        }

        [HttpGet]
        [Route("FindProjects")]
        public async Task<IEnumerable<Project>> SearchProjects(string title)
        {
            IQueryable<Project> query = _studentDbContext.Project;
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(a => a.title.Contains(title));
            }
            return query.ToList();
        }



        [HttpDelete]
        [Route("DeleteProject/{id}")]
        public bool DeleteProject(int id)
        {
            bool a = true;
            var project = _studentDbContext.Project.Find(id);
            if (project != null)
            {
                a = true;
                _studentDbContext.Entry(project).State = EntityState.Deleted;
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
