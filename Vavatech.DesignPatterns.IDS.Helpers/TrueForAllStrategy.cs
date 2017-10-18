using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatternsIDS.Models;

namespace Vavatech.DesignPatterns.IDS.Helpers
{
    public class TrueForAllStrategy : IStrategy
    {
        private IList<IStrategy> strategies;

        public TrueForAllStrategy(IList<IStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public bool IsAllowed(Frame frame)
        {
            return !strategies.Any(s => !s.IsAllowed(frame));
        }
    }
}
