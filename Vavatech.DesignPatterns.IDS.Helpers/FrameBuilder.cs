using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatternsIDS.Models;

namespace Vavatech.DesignPatterns.IDS.Helpers
{
    public class FrameBuilder
    {
        private Frame frame;
        private Packet packet;

        private Address source;
        private Address destination;

        public FrameBuilder AddPacket(Packet packet)
        {
            this.packet = packet;

            return this;
        }

        public FrameBuilder AddSource(Address address)
        {
            this.source = address;

            return this;
        }

        public FrameBuilder AddDestination(Address address)
        {
            this.destination = address;

            return this;
        }

        public Frame GetFrame()
        {

            var frame = new Frame(packet, source, destination);


            return frame;

        }
    }
}
