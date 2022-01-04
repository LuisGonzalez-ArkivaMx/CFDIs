using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaPercepcionesPercepcion
   {
      public NominaPercepcionesPercepcionAccionesOTitulos AccionesOTitulos { get; set; }

      public bool ShouldSerializeAccionesOTitulos()
      {
         return (TipoPercepcion == "045");
      }

      [XmlElementAttribute("HorasExtra")]
      public List<NominaPercepcionesPercepcionHorasExtra> HorasExtra { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      public string TipoPercepcion { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[^|]{3,15}")]
      [MinLength(3)]
      [MaxLength(15)]
      public string Clave { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[^|]{1,100}")]
      [MinLength(1)]
      [MaxLength(100)]
      public string Concepto { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal ImporteGravado { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal ImporteExento { get; set; }
   }
}