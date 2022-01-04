using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ImpuestosLocalesTrasladosLocales
   {
      [XmlAttribute]
      public string ImpLocTrasladado { get; set; }

      [XmlAttribute]
      public decimal TasadeTraslado { get; set; }

      [XmlAttribute]
      public decimal Importe { get; set; }
   }
}