using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Controllers
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "dotnet-core-xunit-example", $"v{GetType().Assembly.GetName().Version.ToString()}", });
        }


        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            TaskDto.Task task = _taskService.GetTask(id);

            if (task == null)
                return BadRequest("Task not found!");

            return Ok(task);
        }


        [HttpPost]
        public IActionResult AddTask([FromBody] TaskDto.Task taskInfo)
        {
            TaskDto.Task task = _taskService.AddTask(taskInfo);

            if (task == null)
                return BadRequest("Failed to add task!");

            return Ok(task);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public IActionResult Put([FromBody] TaskDto.Task taskInfo)
        {
            TaskDto.Task task = _taskService.UpdateTask(taskInfo);
            if (task == null)
                return BadRequest("Failed to update task!");

            return Ok(task);

        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TaskDto.Task task = _taskService.DeleteTask(id);

            if (task == null)
                return BadRequest("Failed to delete task!");

            return Ok(task);
        }
     
    }
}
