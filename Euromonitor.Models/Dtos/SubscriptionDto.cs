using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models.Dtos
{
    public class SubscriptionDto
    {

        #region App User Details
        public int AppUserId { get; set; }
        #endregion

        #region Book Subscription Details

        public int AppUserSubscriptionId { get; set; }

        public string SubscriptionBookName { get; set; }

        public double SubscriptionPurchasePrice { get; set; }

        public DateTime SubscriptionDate { get; set; }

        public DateTime SubscriptionUnsubscribeDate { get; set; }
        #endregion

        #region Book Details
        public int BookId { get; set; }

        public string BookName { get; set; }
        public string BookMarketingImage { get; set; }

        public string BookText { get; set; }

        public int BookIsDeleted { get; set; }
        #endregion
    }
}
