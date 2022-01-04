using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaReceptorSubContratacion
   {
      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[A-Z&amp;Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]")]
      [MinLength(12)]
      [MaxLength(13)]
      public string RfcLabora { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,3}(.([0-9]{1,3}))?")]
      [Range(0.001, 100.000)]
      public decimal PorcentajeTiempo { get; set; }
   }
}