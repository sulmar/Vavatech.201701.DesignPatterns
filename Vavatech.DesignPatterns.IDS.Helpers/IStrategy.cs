using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatternsIDS.Models;

namespace Vavatech.DesignPatterns.IDS.Helpers
{
    public interface IStrategy
    {
        bool IsAllowed(Frame frame);
    }

    public class IPStrategy : IStrategy
    {
        private IList<Address> blacklist;

        public IPStrategy(IList<Address> blacklist)
        {
            this.blacklist = blacklist;
        }

        public bool IsAllowed(Frame frame)
        {
            return !blacklist.Contains(frame.Source);
        }
    }

    public class PortStrategy : IStrategy
    {
        private IList<short> blacklist;

        public PortStrategy(IList<short> blacklist)
        {
            this.blacklist = blacklist;
        }

        public bool IsAllowed(Frame frame)
        {
            return !(blacklist.Contains(frame.Packet.SourcePort) 
                || blacklist.Contains(frame.Packet.DestinationPort));

        }
    }
}
