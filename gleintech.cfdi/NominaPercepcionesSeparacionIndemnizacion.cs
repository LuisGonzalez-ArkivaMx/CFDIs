using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaPercepcionesSeparacionIndemnizacion
   {
      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalPagado { get; set; }

      [XmlAttribute()]
      [Range(0, 99)]
      public int NumAñosServicio { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal UltimoSueldoMensOrd { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal IngresoAcumulable { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal IngresoNoAcumulable { get; set; }
   }
}