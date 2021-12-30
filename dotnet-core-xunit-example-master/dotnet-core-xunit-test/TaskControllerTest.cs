using dotnet_core_xunit.Controllers;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit_test.Fixture;
using dotnet_core_xunit_test.Theory;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_core_xunit_test
{
    public class TaskControllerTest : IClassFixture<ControllerFixture>
    {

        TaskController taskController;

        /**
         * xUnit constructor runs before each test. 
         */
        public TaskControllerTest(ControllerFixture fixture)
        {
            taskController = fixture.taskController;
        }

        [Fact]
        public void GetWithoutParam_Ok_Test()
        {
            var result = taskController.Get() as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }

        [Theory]
        [InlineData(0)]
        public void GetTask_WithNonTask_ThenBadRequest_Test(int id)
        {
            var result = taskController.GetTask(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Task not found!", result.Value);
        }

        [Theory]
        [InlineData(1)]
        public void GetTask_WithTestData_ThenOk_Test(int id)
        {
            var result = taskController.GetTask(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<TaskDto.Task>(result.Value);
        }

        [Theory]
        [ClassData(typeof(TaskTheoryData))]
        public void AddTask_WithTestData_ThenOk_Test(TaskDto.Task taskInfo)
        {
            var result = taskController.AddTask(taskInfo) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(taskInfo), JsonConvert.SerializeObject(result.Value));
        }

        [Theory]
        [InlineData(0)]
        public void Delete_WithNonTask_ThenBadRequest_Test(int id)
        {
            var result = taskController.Delete(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Failed to delete task!", result.Value);
        }

        [Theory]
        [InlineData(121)]
        public void DeleteWithTestData_ThenOk_Test(int id)
        {
            var result = taskController.Delete(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
           Assert.IsType<TaskDto.Task>(result.Value);
        }
    }
}
