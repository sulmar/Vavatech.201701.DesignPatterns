using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vavatech.DesignPatternsIDS.Models;
using Vavatech.DesignPatterns.IDS.Helpers;
using System.Collections.Generic;

namespace Vavatech.DesignPatterns.IDS.UnitTests
{
    [TestClass]
    public class PacketUnitTests
    {
        [TestMethod]
        public void CreateUDPPacketTest()
        {
            var frame1 = new FrameBuilder()
                .AddSource(new IP4Address("192.168.0.1"))
                .AddDestination(new IP4Address("192.168.0.100"))
                .AddPacket(new UdpPacket(1020, 1022, new Content("Hello")))
                .GetFrame();


            var frame2 = new FrameBuilder()
                .AddSource(new IP4Address("192.168.30.1"))
                .AddDestination(new IP4Address("192.168.0.70"))
                .AddPacket(new UdpPacket(1020, 1022, new Content("Hello 2")))
                .GetFrame();


            var frame3 = new FrameBuilder()
                .AddSource(new IP4Address("192.168.0.99"))
                .AddDestination(new IP4Address("192.168.10.70"))
                .AddPacket(new UdpPacket(1020, 9999, new Content("Hello 3")))
                .GetFrame();

            IList<Frame> frames = new List<Frame>();
            frames.Add(frame1);
            frames.Add(frame2);
            frames.Add(frame3);

            var blacklist = new List<Address>
            {
                new IP4Address("192.168.30.1"),
                new IP4Address("192.168.0.100"),
            };

            short[] ports = { 9999, 10 };

            IList<IStrategy> strategies = new List<IStrategy>
            {
                new IPStrategy(blacklist),
                new PortStrategy(ports)
            };

            IStrategy strategy = new TrueForAllStrategy(strategies);

            var filter = new Filter(strategy);

            IList<IProvider> providers = new List<IProvider>();
            providers.Add(new ConsoleProvider());
            providers.Add(new SmsProvider());

            foreach (Frame frame in frames)
            {
                var result = filter.IsAllowed(frame);

                if (!result)
                {
                    var alert = new Alert
                    {
                        CreateDate = DateTime.Now,
                        Frame = frame,
                        Message = filter.Strategy.GetType().Name
                    };

                    foreach (var provider in providers)
                    {
                        provider.Send(alert);
                    }

                }
            }

        }
    }
}
