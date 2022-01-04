using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class CuentaPredial
   {
      [XmlAttribute]
      [Required]
      [MinLength(1)]
      [MaxLength(150)]
      public string Numero { get; set; }
   }
}