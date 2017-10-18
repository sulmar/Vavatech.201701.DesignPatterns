using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatternsIDS.Models
{

    public class UdpPacket : Packet
    {
        public UdpPacket(short sourcePort, short destinationPort, Content content) 
            : base(sourcePort, destinationPort, content)
        {
        }
    }

    public class TcpPacket : Packet
    {
        public TcpPacket(short sourcePort, 
            short destinationPort, 
            Content content,
            Flags flags) 
            : base(sourcePort, destinationPort, content)
        {
            this.Flags = flags;
        }

        public Flags Flags { get; set; }
    }

    public abstract class Packet : Base
    {
        public short SourcePort { get; set; }
        public short DestinationPort { get; set; }
        public Content Content { get; set; }

        public Packet(short sourcePort, short destinationPort, Content content)
        {
            this.SourcePort = sourcePort;
            this.DestinationPort = destinationPort;
            this.Content = content;
        }
    }


    public class Frame : Base
    {
        public Address Source { get; set; }
        public Address Destination { get; set; }
        public Packet Packet { get; set; }

        public Frame(Packet packet, Address source, Address destination)
        {
            this.Packet = packet;
            this.Source = source;
            this.Destination = destination;

        }
    }

    public class IP4Address : Address
    {
        public string IP4 { get; set; }

        public IP4Address(string address) 
            : base()
        {
            this.IP4 = address;
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IP4Address))
            {
                return false;
            }

            var address = (IP4Address)obj;

            return IP4.Equals(address.IP4);
        }
    }

    public class IP6Address : Address
    {
        public string IP6 { get; set; }

        public IP6Address(string address) 
            : base()
        {
            this.IP6 = address;
        }
    }


    public abstract class Address
    {
        public string MAC { get; set; }

    }

    public class Content
    {
        public string ContentStr { get; set; }

        public Content(string content)
        {
            this.ContentStr = content;
        }
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
