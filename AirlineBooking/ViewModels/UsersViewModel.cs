using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineBooking.ViewModels
{
    public class UsersViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailID { set; get; }
        [Required]
        [StringLength(50)]
        public string UserName { set; get; }
        [Required]
        [StringLength(20)]
        public string passportNumber { set; get; }
        [Required]
        public int Age { set; get; }
    }
}
