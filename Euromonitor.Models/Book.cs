using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models
{
    public class Book
    {
        public Book()
        {
            this.AppUsers = new HashSet<AppUser>();
        }

        [Key] //Sets as PK and sets to Identity
        public int Id { get; set; }

        [Required]
        public string BookText { get; set; }

        [Required]
        public double Price { get; set; }

        /*Configure Many to Many relationship in EF-Core
        *Collection Navigation Property
       */
        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}
