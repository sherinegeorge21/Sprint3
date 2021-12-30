using dotnet_core_xunit_test.Mock.Entities;
using System;

namespace dotnet_core_xunit_test.Fixture
{
    public class ContextFixture : IDisposable
    {
        public TestDbContextMock testDbContextMock;

        public ContextFixture()
        {
            testDbContextMock = new TestDbContextMock();

            // mock data created by https://barisates.github.io/pretend
            testDbContextMock.Users.AddRange(new dotnet_core_xunit.Entities.TestDb.Users[]
            {
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Users()
 {
                Id = 564,
                FirstName = "Mark",
                LastName = "Paul",
                Email = "mark.paul@gmail.com",
                Password = "whatsapp123"
            },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Users()
 {
                Id = 897,
                FirstName = "Sherry",
                LastName = "John",
                Email = "sherry.john@gmail.com",
                Password = "facebook@23"
            }
        });

            testDbContextMock.Tasks.AddRange(new dotnet_core_xunit.Entities.TestDb.Tasks[]
{
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Tasks()
 {
                Id = 10,
                ProjectID = 2,
                Status = 3,
                AssignedToUserID=2, 
                Detail = "Angular App", 
                CreatedOn=new DateTime(2021,9,10)
            },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Tasks()
 {
                Id = 21,
                ProjectID = 4,
                Status = 3,
                AssignedToUserID=1,
                Detail = "Test App",
                CreatedOn=new DateTime(2020,10,10)
            }
});

            testDbContextMock.Projects.AddRange(new dotnet_core_xunit.Entities.TestDb.Projects[]
{
                // for delete test
                new dotnet_core_xunit.Entities.TestDb.Projects()
 {
                Id = 10,
                Name="MyName",
                Detail = "Angular App",
                CreatedOn=new DateTime(2021,9,10)
            },
                // for get test
                new dotnet_core_xunit.Entities.TestDb.Projects()
 {
                Id = 21,
                Name="New_world", 
                Detail = "Test App",
                CreatedOn=new DateTime(2020,10,10)
            }
});


            testDbContextMock.SaveChanges();
        }

        // https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019
        #region ImplementIDisposableCorrectly
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ContextFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (testDbContextMock != null)
                {
                    testDbContextMock.Dispose();
                    testDbContextMock = null;
                }
            }
        }
        #endregion
    }
}
