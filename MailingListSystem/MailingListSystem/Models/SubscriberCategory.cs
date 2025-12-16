using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListSystem.Models
{
    public class SubscriberCategory
    {
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime SubscriptionDate { get; set; } = DateTime.Now;
    }
}
