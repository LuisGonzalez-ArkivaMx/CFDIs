using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaEmisorEntidadSNCF
   {
      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[A-Z&amp;Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]")]
      [MinLength(12)]
      [MaxLength(13)]
      public string OrigenRecurso { get; set; }

      public bool ShouldSerializeOrigenRecurso()
      {
         return (OrigenRecurso != "");
      }

      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal MontoRecursoPropio { get; set; } //No viene en el archivo NOM

      public bool ShouldSerializeMontoRecursoPropio()
      {
         return (MontoRecursoPropio > 0);
      }
   }
}