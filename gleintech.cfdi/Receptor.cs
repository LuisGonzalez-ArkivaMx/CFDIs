using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Receptor
   {
      [Required]
      [XmlAttribute]
      [RegularExpression("[A-Z,Ñ,&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9]?[A-Z,0-9]?[0-9,A-Z]?")]
      public string Rfc { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(254)]
      public string Nombre { get; set; }

      [XmlAttribute]
      [StringLength(3)]
      public string ResidenciaFiscal { get; set; }

      public bool ShouldSerializeResidenciaFiscal()
      {
         return (ResidenciaFiscal != "" || NumRegIdTrib != "");
      }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(40)]
      public string NumRegIdTrib { get; set; }

      public bool ShouldSerializeNumRegIdTrib()
      {
         return (NumRegIdTrib != "");
      }

      [Required]
      [XmlAttribute]
      [StringLength(3)]
      public string UsoCFDI { get; set; }
   }
}