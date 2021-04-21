using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models.Dtos
{
    public class AppUserBookDto
    {
        [Required]
        public int AppUserId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateTime SubscriptionDate { get; set; } = DateTime.Now;

        [Required]
        public string SubscriptionBookName { get; set; }

        [Required]
        public double SubscriptionPurchasePrice { get; set; }
    }
}
