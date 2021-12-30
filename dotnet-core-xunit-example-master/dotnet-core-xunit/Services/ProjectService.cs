using AutoMapper;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Entities.TestDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Services
{

    public interface IProjectService
    {
        ProjectDto.Project GetProject(int id);

        ProjectDto.Project AddProject(ProjectDto.Project project);

        ProjectDto.Project UpdateProject(ProjectDto.Project project);
        ProjectDto.Project DeleteProject(int id);
    }
    public class ProjectService : IProjectService
    {
        private TestDbContext _testDbContext;

        private IMapper _mapper;

        public ProjectService(TestDbContext testDbContext, IMapper mapper)
        {
            _testDbContext = testDbContext;
            _mapper = mapper;
        }

        public ProjectDto.Project AddProject(ProjectDto.Project project)
        {
            try
            {
                Projects projects = _mapper.Map<Projects>(project);

                _testDbContext.Projects.Add(projects);
                _testDbContext.SaveChanges();

                return _mapper.Map<ProjectDto.Project>(projects);
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public ProjectDto.Project DeleteProject(int id)
        {
            Projects projects = _testDbContext.Projects.Where(w => w.Id == id).FirstOrDefault();

            if (projects == null)
                return null;

            _testDbContext.Projects.Remove(projects);
            _testDbContext.SaveChanges();

            return _mapper.Map<ProjectDto.Project>(projects);
        }

        public ProjectDto.Project GetProject(int id)
        {
            Projects projects = _testDbContext.Projects.Where(w => w.Id == id).FirstOrDefault();

            return _mapper.Map<ProjectDto.Project>(projects);
        }

        public ProjectDto.Project UpdateProject(ProjectDto.Project project)
        {
            Projects project_ = _mapper.Map<Projects>(project);
            Projects projects = _testDbContext.Projects.Where(w => w.Id == project.Id).FirstOrDefault();


            if (projects != null)
            {
                _testDbContext.Projects.Remove(projects);
                _testDbContext.SaveChanges();
                _testDbContext.Projects.Add(project_);

                _testDbContext.SaveChanges();

            }
            return _mapper.Map<ProjectDto.Project>(projects);
        }


    }
}
