using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;

namespace Logger.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string LayoutType)
        {
            ILayout layout = null;

            switch (LayoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }

            return layout;
        }
    }
}
