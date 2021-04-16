using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models.Dtos
{
    public class MemberDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ContactNumber { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime LastActive { get; set; } = DateTime.Now;
    }
}
