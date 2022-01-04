using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaPercepcionesPercepcionHorasExtra
   {
      [XmlAttributeAttribute()]
      [Required]
      public int Dias { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      public string TipoHoras { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      public int HorasExtra { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal ImportePagado { get; set; }
   }
}