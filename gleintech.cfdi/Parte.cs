using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Parte
   {
      [XmlAttribute]
      [Required]
      [MinLength(1)]
      [MaxLength(30)]
      public string ClaveProdServ { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(100)]
      public string NoIdentificacion { get; set; }

      [XmlAttribute]
      [Required]
      public decimal Cantidad { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(20)]
      public string Unidad { get; set; }

      [XmlAttribute]
      [Required]
      [MinLength(1)]
      [MaxLength(1000)]
      public string Descripcion { get; set; }

      [XmlAttribute]
      [Required]
      public decimal ValorUnitario { get; set; }

      [XmlAttribute]
      [Required]
      public decimal Importe { get; set; }

      public List<InformacionAduanera> ParteInformacionAduanera { get; set; }  //revisar esta opcion que se puede repetir n veces
   }
}