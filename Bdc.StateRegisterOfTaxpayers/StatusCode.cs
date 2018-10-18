using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Bdc.StateRegisterOfTaxpayers
{
    public enum StatusCode
    {
        [XmlEnum("1")]
        Active,

        [XmlEnum("M")]
        ProcessOfLiquidationType1,

        [XmlEnum("Z")]
        ProcessOfLiquidationType2,

        [XmlEnum("L")]
        Liquidated
    }
}
