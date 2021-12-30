using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "dotnet-core-xunit-example", $"v{GetType().Assembly.GetName().Version.ToString()}", });
        }


        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            ProjectDto.Project project = _projectService.GetProject(id);

            if (project == null)
                return BadRequest("Project not found!");

            return Ok(project);
        }


        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectDto.Project projectInfo)
        {
            ProjectDto.Project project = _projectService.AddProject(projectInfo);

            if (project == null)
                return BadRequest("Failed to add project!");

            return Ok(project);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put([FromBody] ProjectDto.Project projectInfo)
        {
            ProjectDto.Project project = _projectService.UpdateProject(projectInfo);
            if (project == null)
                return BadRequest("Failed to update project!");

            return Ok(project);

        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ProjectDto.Project project = _projectService.DeleteProject(id);

            if (project == null)
                return BadRequest("Failed to delete project!");

            return Ok(project);
        }

    }
}
