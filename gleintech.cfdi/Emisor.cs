using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Emisor
   {
      //[RegularExpression(@"/^([A-Z,Ñ,&]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[A-Z|\d]{3})$/")]
      [Required]
      [XmlAttribute]
      [RegularExpression("[A-Z,Ñ,&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9]?[A-Z,0-9]?[0-9,A-Z]?")]
      public string Rfc { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(254)]
      public string Nombre { get; set; }

      [Required]
      [XmlAttribute]
      [StringLength(3)]
      public string RegimenFiscal { get; set; }

      [XmlIgnoreAttribute]
      public int MiembroId { get; set; }
   }
}