using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models
{
    public class AppUser
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string AppUserName { get; set; }

        [Required]
        public string AppUserEmailAddress { get; set; }

        [Required]
        public string AppUserFirstName { get; set; }

        [Required]
        public string AppUserLastName { get; set; }

        public string AppUserContactNumber { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public DateTime AppUserCreateDate { get; set; } = DateTime.Now;

        public DateTime AppUserLastActive { get; set; } = DateTime.Now;

        public int AppUserIsDeleted { get; set; }

    }
}
