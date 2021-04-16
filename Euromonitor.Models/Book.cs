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
        [Key] //Sets as PK and sets to Identity
        public int Id { get; set; }

        [Required]
        public string BookText { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
