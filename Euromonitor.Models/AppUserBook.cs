using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models
{
    public class AppUserBook
    {
        [Key]
        public int Id { get; set; }

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

        public DateTime SubscriptionUnsubscribeDate { get; set; }

        public int SubscriptionIsDeleted { get; set; }
    }
}
