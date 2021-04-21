using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models.Dtos
{
    public class RegisterDto
    {

        [Required]
        public string AppUserName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]//MaxLength:25, MinLength: 4.
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string AppUserEmailAddress { get; set; }

        [Required]
        public string AppUserFirstName { get; set; }

        [Required]
        public string AppUserLastName { get; set; }

        [Required]
        public string AppUserContactNumber { get; set; }
    }
}
