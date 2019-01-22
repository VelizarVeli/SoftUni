namespace IRunesWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseEntity<TKeyIdentifier>
    {
        public TKeyIdentifier Id { get; set; }
    }
}
