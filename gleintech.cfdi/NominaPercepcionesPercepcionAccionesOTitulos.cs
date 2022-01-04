using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaPercepcionesPercepcionAccionesOTitulos
   {
      [XmlAttributeAttribute()]
      [Required]
      public decimal ValorMercado { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      public decimal PrecioAlOtorgarse { get; set; }
   }
}