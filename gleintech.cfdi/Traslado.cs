using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Traslado
   {
      [XmlAttribute]
      [Required]
      public decimal Base { get; set; }

      [XmlAttribute]
      [Required]
      [StringLength(3)]
      public string Impuesto { get; set; }

      [XmlAttribute]
      [Required]
      [StringLength(10)]
      public string TipoFactor { get; set; }

      [XmlAttribute]
      public decimal TasaOCuota { get; set; }

      [XmlAttribute]
      public decimal Importe { get; set; }
   }
}