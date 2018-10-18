using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Bdc.StateRegisterOfTaxpayers
{
    [XmlRoot("ROWSET")]
    public class TaxpayerCollection
    {
        [XmlElement("ROW")]
        public Taxpayer[] Taxpayers { get; set; }
    }
}
