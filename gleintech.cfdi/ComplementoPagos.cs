using System.Collections.Generic;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ComplementoPagos
   {
      [XmlAttribute]
      public string Version { get; set; }

      [XmlElement("Pago")]
      public List<Pago> Pago { get; set; }
   }
}