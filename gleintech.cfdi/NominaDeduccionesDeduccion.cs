using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaDeduccionesDeduccion
   {
      [XmlAttributeAttribute()]
      [Required]
      public string TipoDeduccion { get; set; }

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
      public decimal Importe { get; set; }
   }
}