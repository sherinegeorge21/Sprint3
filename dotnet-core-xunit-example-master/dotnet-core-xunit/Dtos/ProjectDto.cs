using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_xunit.Dtos
{
    public class ProjectDto
    {
        public class Project
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Detail { get; set; }

            public DateTime CreatedOn { get; set; }


        }

    }
}
