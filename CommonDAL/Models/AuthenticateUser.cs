using System;
using System.Collections.Generic;

#nullable disable

namespace CommonDAL.Models
{
    public partial class AuthenticateUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
