﻿using System.Linq;
using eZet.Eve.EveLib.Entity.EveCentral;
using eZet.Eve.EveLib.Model.EveCentral;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eZet.Eve.EveLib.Test {
    [TestClass]
    public class EveCentral_Tests {
        private const long RegionId = 10000002;
        private const long TypeId = 34;
        private const int HourLimit = 5;
        private const int MinQty = 5;
        private readonly EveCentral api;
        private readonly EveCentralOptions invalidOptions;
        private readonly EveCentralOptions validOptions;

        public EveCentral_Tests() {
            api = EveLib.Create().EveCentral;
            validOptions = new EveCentralOptions {HourLimit = HourLimit, MinQuantity = MinQty};
            validOptions.Types.Add(TypeId);
            validOptions.Regions.Add(RegionId);
            invalidOptions = new EveCentralOptions();
        }

        [TestMethod]
        public void GetMarketStat_ValidRequest_ValidResponse() {
            MarketStatResponse res = api.GetMarketStat(validOptions);
            MarketStatItem entry = res.Result.First();
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreNotEqual(0, entry.All.Average);
            Assert.AreNotEqual(0, entry.All.Volume);
            Assert.AreNotEqual(0, entry.All.Max);
            Assert.AreNotEqual(0, entry.All.Min);
            Assert.AreNotEqual(0, entry.All.StdDev);
            Assert.AreNotEqual(0, entry.All.Median);
            Assert.AreNotEqual(0, entry.All.Percentile);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), AllowDerivedTypes = true)]
        public void GetMarketStat_InvalidArgument_ContractException() {
            MarketStatResponse res = api.GetMarketStat(invalidOptions);
        }

        [TestMethod]
        public void GetQuicklook_ValidRequest_ValidReseponse() {
            QuicklookResponse res = api.GetQuicklook(validOptions);
            QuicklookResult entry = res.Result;
            QuicklookOrder order = entry.BuyOrders.First();
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual("Tritanium", entry.TypeName);
            Assert.AreEqual(HourLimit, entry.HourLimit);
            Assert.AreEqual(MinQty, entry.MinQuantity);
            Assert.AreNotEqual("", entry.Regions.First());
            Assert.AreNotEqual(0, order.MinVolume);
            Assert.AreNotEqual(0, order.OrderId);
            Assert.AreNotEqual(0, order.VolRemaining);
            Assert.AreNotEqual(0, order.Price);
            Assert.AreNotEqual(0, order.SecurityRating);
            Assert.AreNotEqual(0, order.StationId);
            Assert.AreNotEqual("", order.StationName);
            Assert.AreNotEqual("", order.Expires);
            Assert.AreNotEqual("", order.ReportedTime);
        }

        [TestMethod]
        public void GetQuicklookPath_ValidRequest_ValidResponse() {
            QuicklookResponse res = api.GetQuicklookPath("Jita", "Amarr", 34, validOptions);
            QuicklookResult entry = res.Result;
            QuicklookOrder order = entry.BuyOrders.First();
            Assert.AreEqual(TypeId, entry.TypeId);
            Assert.AreEqual("Tritanium", entry.TypeName);
            Assert.AreEqual(HourLimit, entry.HourLimit);
            Assert.AreEqual(MinQty, entry.MinQuantity);
            Assert.AreNotEqual(0, order.MinVolume);
            Assert.AreNotEqual(0, order.OrderId);
            Assert.AreNotEqual(0, order.VolRemaining);
            Assert.AreNotEqual(0, order.Price);
            Assert.AreNotEqual(0, order.SecurityRating);
            Assert.AreNotEqual(0, order.StationId);
            Assert.AreNotEqual("", order.StationName);
            Assert.AreNotEqual("", order.Expires);
            Assert.AreNotEqual("", order.ReportedTime);
        }

        [TestMethod]
        public void GetHistory_ValidRequest_ValidResponse() {
            api.GetHistory();
        }
    }
}