using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatternsIDS.Models
{

    public class UdpPacket : Packet
    {

    }

    public class TcpPacket : Packet
    {
        public Flags Flags { get; set; }
    }

    public abstract class Packet : Base
    {
        public short SourcePort { get; set; }
        public short DestinationPort { get; set; }
        public Content Content { get; set; }
    }


    public class Frame : Base
    {
        public Address Source { get; set; }
        public Address Destination { get; set; }
        public Packet Packet { get; set; }
    }

    public class Address
    {
        public string IP4 { get; set; }
        public string IP6 { get; set; }
        public string MAC { get; set; }
    }

    public class Content
    {
        public string ContentStr { get; set; }
    }

    public class Flags
    {
        private Flag Flag { get; set; }

        public Flags(Flag flag)
        {
            this.Flag = flag;
        }

        public Flags()
        {
            Flag = Flag.None;
        }

        public void Add(Flag flag)
        {
            Flag = Flag | flag;
        }

        public bool HasFlag(Flag flag)
        {
            return Flag.HasFlag(flag);
        }
    }


    [Flags]
    public enum Flag
    {
        None = 0,

        Ack = 1,

        Fin = 2,

        Rst = 4,

        Syn = 8
    }

}
