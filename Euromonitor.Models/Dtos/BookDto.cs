using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models.Dtos
{
    public class BookDto
    {
        [Key] //Sets as PK and sets to Identity
        public int Id { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookText { get; set; }

        [Required]
        public double BookPurchasePrice { get; set; }

        public string BookMarketingImage { get; set; }
    }
}
