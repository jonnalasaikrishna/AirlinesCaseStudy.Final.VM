using System;
using System.Collections.Generic;

#nullable disable

namespace CommonDAL.Models
{
    public partial class AuthenticateUser
    {
        public int Id { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
    }
}
