using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ComprobanteRetencion
   {
      [XmlAttribute]
      [Required]
      [StringLength(3)]
      public string Impuesto { get; set; }

      [XmlAttribute]
      public decimal Importe { get; set; }
   }
}