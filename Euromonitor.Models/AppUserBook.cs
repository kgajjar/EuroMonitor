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

        public int AppUserId { get; set; }

        public int BookId { get; set; }

        public DateTime SubscriptionDate { get; set; }

        public string SubscriptionBookName { get; set; }

        public double SubscriptionPurchasePrice { get; set; }

        public DateTime SubscriptionUnsubscribeDate { get; set; }

        public int SubscriptionIsDeleted { get; set; }
    }
}
