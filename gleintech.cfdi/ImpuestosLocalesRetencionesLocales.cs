using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ImpuestosLocalesRetencionesLocales
   {
      [XmlAttribute]
      public string ImpLocRetenido { get; set; }

      [XmlAttribute]
      public decimal TasadeRetencion { get; set; }

      [XmlAttribute]
      public decimal Importe { get; set; }
   }
}