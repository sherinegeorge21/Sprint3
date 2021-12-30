using dotnet_core_xunit.Dtos;
using System;
using Xunit;

namespace dotnet_core_xunit_test.Theory
{
    public class UserTheoryData: TheoryData<UserDto.User>
    {
        public UserTheoryData()
        {
 
            Add(new UserDto.User()
            {
                Email = "yft97l",
                FirstName = "8s0quo",
                LastName="George",
                Id = 2,
                Password = "d87btl",
           
            });



        }
    }
}
