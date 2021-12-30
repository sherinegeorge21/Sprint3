using System;
using System.Collections.Generic;

namespace dotnet_core_xunit.Entities.TestDb
{
    public partial class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
