using System;

namespace Panda.Model
{
    public class Receipt : BaseId
    {
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientId { get; set; }
        public virtual PandaUser Recipient { get; set; }

        public Guid PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}