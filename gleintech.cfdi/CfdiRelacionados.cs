using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class CfdiRelacionados
   {
      [XmlAttribute]
      [Required]
      public string TipoRelacion { get; set; }

      [XmlElement("CfdiRelacionado")]
      public List<CfdiRelacionado> CfdiRelacionado { get; set; }
   }
}