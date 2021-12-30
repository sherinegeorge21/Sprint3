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
    public class ProjectControllerTest: IClassFixture<ControllerFixture>
    {
        ProjectController projectController;

        /**
         * xUnit constructor runs before each test. 
         */
        public ProjectControllerTest(ControllerFixture fixture)
        {
            projectController = fixture.projectController;
        }

        [Fact]
        public void GetWithoutParam_Ok_Test()
        {
            var result = projectController.Get() as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }

        [Theory]
        [InlineData(0)]
        public void GetTask_WithNonProject_ThenBadRequest_Test(int id)
        {
            var result = projectController.GetProject(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Project not found!", result.Value);
        }

        [Theory]
        [InlineData(201)]
        public void GetProject_WithTestData_ThenOk_Test(int id)
        {
            var result = projectController.GetProject(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<ProjectDto.Project>(result.Value);
        }

        [Theory]
        [ClassData(typeof(ProjectTheoryData))]
        public void AddProject_WithTestData_ThenOk_Test(ProjectDto.Project projectInfo)
        {
            var result = projectController.AddProject(projectInfo) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(projectInfo), JsonConvert.SerializeObject(result.Value));
        }

        [Theory]
        [InlineData(0)]
        public void Delete_WithNonProject_ThenBadRequest_Test(int id)
        {
            var result = projectController.Delete(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Failed to delete project!", result.Value);
        }

        [Theory]
        [InlineData(121)]
        public void DeleteWithTestData_ThenOk_Test(int id)
        {
            var result = projectController.Delete(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<ProjectDto.Project>(result.Value);
        }

    }
}
