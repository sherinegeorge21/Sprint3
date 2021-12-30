using dotnet_core_xunit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_core_xunit_test.Theory
{
    class ProjectTheoryData : TheoryData<ProjectDto.Project>
    {
        public ProjectTheoryData()
        {

            Add(new ProjectDto.Project()
            {
                Id = 1,
                Name="mango",
                Detail = "Angular App",
                CreatedOn = new DateTime(2021, 9, 10),

            });



        }

    }
}
