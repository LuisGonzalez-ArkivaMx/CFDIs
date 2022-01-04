using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaOtroPagoSubsidioAlEmpleo
   {
      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal SubsidioCausado { get; set; }
   }
}