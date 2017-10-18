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
        private IStrategy strategy;

        public Filter(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public bool IsAllowed(Frame frame)
        {
            return strategy.IsAllowed(frame);
        }
    }
}
