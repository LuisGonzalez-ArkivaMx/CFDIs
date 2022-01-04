using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class InformacionAduanera
   {
      [XmlAttribute]
      [Required]
      [StringLength(21)]
      public string NumeroPedimento { get; set; }
   }
}