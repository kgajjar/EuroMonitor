using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.Models.Dtos
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }

        public double SubscriptionPurchasePrice { get; set; }
    }
}
