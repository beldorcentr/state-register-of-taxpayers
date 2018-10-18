using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Bdc.StateRegisterOfTaxpayers
{
    public class Taxpayer
    {
        [XmlElement("VUNP")]
        public string Unp { get; set; }

        [XmlElement("VNAIMK")]
        public string Name { get; set; }

        [XmlElement("VNAIMP")]
        public string FullNameWithAddress { get; set; }

        [XmlElement("VPADRES")]
        public string Address { get; set; }

        [XmlElement("VKODS")]
        public string Status { get; set; }

        [XmlElement("CKODSOST")]
        public StatusCode StatusCode { get; set; }


        [XmlIgnore]
        public DateTime? CreateDate { get; set; }

        [XmlIgnore]
        private string _dreg;

        [XmlElement("DREG")]
        public string CreateDateString
        {
            get { return _dreg; }
            set
            {
                _dreg = value;
                CreateDate = ConvertToDate(value);
            }
        }


        [XmlIgnore]
        public DateTime? LiquidationDate { get; set; }

        private string _dlikv;

        [XmlElement("DLIKV", IsNullable = true)]
        public string LiquidationDateString
        {
            get { return _dlikv; }
            set
            {
                _dlikv = value;
                LiquidationDate = ConvertToDate(value);
            }
        }


        [XmlElement("VLIKV")]
        public string BasisForLiquidation { get; set; }

        [XmlElement("NMNS")]
        public string TaxAndDutiesMinistryInspectionCode { get; set; }

        [XmlElement("VMNS")]
        public string TaxAndDutiesMinistryInspectionName { get; set; }


        private DateTime? ConvertToDate(string date)
        {
            if (String.IsNullOrWhiteSpace(date))
            {
                return null;
            }
            return DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }
    }
}
