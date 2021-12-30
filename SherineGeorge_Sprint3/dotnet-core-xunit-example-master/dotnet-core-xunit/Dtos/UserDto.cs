using System;

namespace dotnet_core_xunit.Dtos
{
    public class UserDto
    {
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }

            public string Password { get; set; }

        }



    }
}