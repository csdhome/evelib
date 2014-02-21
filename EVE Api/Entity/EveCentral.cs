﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using eZet.Eve.EoLib.Dto.EveCentral;

namespace eZet.Eve.EoLib.Entity {
    public class EveCentral : BaseEntity {

        protected override sealed string UriBase { get; set; }

        internal EveCentral() {
            UriBase = "http://api.eve-central.com";
        }

        /// <summary>
        /// Returns aggregate statistics for the items specified.
        /// </summary>
        /// <returns></returns>
        public MarketStatResponse getMarketStat() {
            const string uri = "/api/marketstat";
            var postString = "typeid=34&typeid=35&regionlimit=10000002";
            string data = RequestHelper.Request(UriBase + uri, postString);
            var serializer = new XmlSerializer(typeof(MarketStatResponse));
            MarketStatResponse xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (MarketStatResponse)serializer.Deserialize(reader);
            }
            return xmlResponse;

        }

        /// <summary>
        /// Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <returns></returns>
        public QuicklookResponse getQuicklook() {
            const string uri = "/api/quicklook";
            var postString = "typeid=34";
            string data = RequestHelper.Request(UriBase + uri, postString);
            var serializer = new XmlSerializer(typeof(QuicklookResponse));
            QuicklookResponse xmlResponse;
            using (var reader = XmlReader.Create(new StringReader(data))) {
                xmlResponse = (QuicklookResponse)serializer.Deserialize(reader);
            }
            return xmlResponse;
        }

        public void getQuicklookPath() {
            throw new NotImplementedException();
        }

        public void getHistory() {
            throw new NotImplementedException();
        }



    }
}
