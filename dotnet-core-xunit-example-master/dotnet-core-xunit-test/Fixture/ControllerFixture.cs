using AutoMapper;
using dotnet_core_xunit.Controllers;
using dotnet_core_xunit.Helpers;
using dotnet_core_xunit.Services;
using dotnet_core_xunit_test.Mock.Entities;
using System;

namespace dotnet_core_xunit_test.Fixture
{
    public class ControllerFixture : IDisposable
    {

        private TestDbContextMock testDbContextMock { get; set; }
        private UserService userService { get; set; }
        private ProjectService projectService { get; set; }
        private TaskService taskService { get; set; }
        private IMapper mapper { get; set; }

        public UserController userController { get; private set; }

        public TaskController taskController { get; private set; }

        public ProjectController projectController { get; private set; }

        public ControllerFixture()
        {
            #region Create mock/memory database

            testDbContextMock = new TestDbContextMock();

            // mock data created by https://barisates.github.io/pretend
            testDbContextMock.Users.AddRange(new dotnet_core_xunit.Entities.TestDb.Users[]
            {
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Users()
                {
                  Id = 685349,
                  Email = "0sgtsw",
                  Password = "jmctby",
                  FirstName = "mq8zp2",
                  LastName="John",

                },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Users()
                {
                  Id = 454673,
                  Email = "0tec4e",
                  Password = "al9jje",
                  FirstName = "jqvlv2",
                  LastName="George",
                }
            });

            testDbContextMock.Tasks.AddRange(new dotnet_core_xunit.Entities.TestDb.Tasks[]
           {
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Tasks()
                {
                 Id = 121, 
                 ProjectID = 3,
                 Status=2,
                 AssignedToUserID=2, 
                 Detail = "Angular App", 
                CreatedOn=new DateTime(2021,9,10)
                },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Tasks()
                {
                 Id = 201,
                 ProjectID = 1,
                 Status=1,
                 AssignedToUserID=1,
                 Detail = "Web App",
                CreatedOn=new DateTime(2020,10,8)
                },
             new dotnet_core_xunit.Entities.TestDb.Tasks()
                {
                 Id = 3,
                 ProjectID = 1,
                 Status=1,
                 AssignedToUserID=1,
                 Detail = "Web App",
                CreatedOn=new DateTime(2020,10,8)
                },
           });

            testDbContextMock.Projects.AddRange(new dotnet_core_xunit.Entities.TestDb.Projects[]
          {
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Projects()
                {
                 Id = 121,
                 Name="MyName",
                 Detail = "Angular App",
                CreatedOn=new DateTime(2021,9,10)
                },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Projects()
                {
                 Id = 201,
                 Name="newname",
                 Detail = "Web App",
                CreatedOn=new DateTime(2020,10,8)
                },
             new dotnet_core_xunit.Entities.TestDb.Projects()
                {
                 Id = 3,
                 Name="Fireworld",
                 Detail = "Web App",
                CreatedOn=new DateTime(2020,10,8)
                },
          });

            testDbContextMock.SaveChanges();
            
            #endregion

            #region Mapper settings with original profiles.

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            #endregion

            // Create UserService with Memory Database
            userService = new UserService(testDbContextMock, mapper);

            taskService = new TaskService(testDbContextMock, mapper);

            projectService = new ProjectService(testDbContextMock, mapper);

            // Create Controller
            userController = new UserController(userService);

            taskController = new TaskController(taskService);

            projectController = new ProjectController(projectService);

        }

        #region ImplementIDisposableCorrectly
        /** https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019 */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ControllerFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                testDbContextMock.Dispose();
                testDbContextMock = null;

                userService = null;
                taskService = null;
                projectService = null;
                mapper = null;

                userController = null;
                taskController = null;
                projectController = null;
            }
        }
        #endregion
    }
}
