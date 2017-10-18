using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatternsIDS.Models;

namespace Vavatech.DesignPatterns.IDS.Helpers
{
    public class Filter
    {
        public IStrategy Strategy { get; private set; }

        public Filter(IStrategy strategy)
        {
            this.Strategy = strategy;
        }

        public bool IsAllowed(Frame frame)
        {
            return Strategy.IsAllowed(frame);
        }
    }
}
