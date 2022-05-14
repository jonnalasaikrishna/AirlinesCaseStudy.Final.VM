using System;
using System.Collections.Generic;

#nullable disable

namespace CommonDAL.Models
{
    public partial class UserRegister
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNum { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
    }
}
