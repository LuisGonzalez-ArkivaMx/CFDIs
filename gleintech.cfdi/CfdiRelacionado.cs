using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class CfdiRelacionado
   {
      [XmlAttribute]
      [Required]
      public string UUID { get; set; }
   }
}