﻿using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace eZet.Eve.EveLib.Model.EveApi.Core {
    [Serializable]
    [XmlRoot("result", IsNullable = false)]
    public class CallList : XmlElement, IXmlSerializable {
        [XmlElement("rowset")]
        public XmlRowSet<CallGroup> CallGroups { get; set; }


        [XmlElement("rowset")]
        public XmlRowSet<Call> Calls { get; set; }


        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader) {
            setRoot(reader);
            CallGroups = deserializeRowSet(getRowSetReader("callGroups"), new CallGroup());
            Calls = deserializeRowSet(getRowSetReader("calls"), new Call());
        }

        public void WriteXml(XmlWriter writer) {
            throw new NotImplementedException();
        }

        [Serializable]
        [XmlRoot("row")]
        public class Call {
            [XmlAttribute("accessMask")]
            public int AccessMask { get; set; }

            [XmlAttribute("type")]
            public string Character { get; set; }

            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("groupID")]
            public long groupId { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }
        }

        [Serializable]
        [XmlRoot("row")]
        public class CallGroup {
            [XmlAttribute("groupID")]
            public long GroupId { get; set; }

            [XmlAttribute("name")]
            public string GroupName { get; set; }

            [XmlAttribute("description")]
            public string Description { get; set; }
        }
    }
}