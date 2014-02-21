﻿using System;
using System.Xml.Serialization;

namespace eZet.Eve.EoLib.Dto.EveApi.Character {
    public class ContractBids : XmlResult {

        [XmlElement("rowset")]
        public XmlRowSet<Bid> Bids { get; set; }

        [Serializable]
        [XmlRoot("row")]
        public class Bid {

            [XmlAttribute("bidID")]
            public long BidId { get; set; }

            [XmlAttribute("contractID")]
            public long ContractId { get; set; }

            [XmlAttribute("bidderID")]
            public long BidderId { get; set; }

            [XmlIgnore]
            public DateTime BidDate { get; private set; }

            [XmlAttribute("dateBid")]
            public string BidDateAsString {
                get { return BidDate.ToString(DateFormat); }
                set { BidDate = DateTime.ParseExact(value, DateFormat, null); }
            }

            [XmlAttribute("amount")]
            public decimal Amount { get; set; }

        }
    }
}
