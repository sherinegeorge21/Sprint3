using dotnet_core_xunit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace dotnet_core_xunit_test.Theory
{
    public class TaskTheoryData : TheoryData<TaskDto.Task>
    {

        public TaskTheoryData()
        {

            Add(new TaskDto.Task()
            {
                Id = 1,
                ProjectID = 3,
                Status = 2,
                AssignedToUserID = 2,
                Detail = "Angular App",
                CreatedOn = new DateTime(2021, 9, 10),

            });



        }
    }
}
