using System;

namespace Panda.Model
{
    public class Receipt : BaseId
    {
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public Guid UserId { get; set; }
        public User Recipient { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }
    }
}