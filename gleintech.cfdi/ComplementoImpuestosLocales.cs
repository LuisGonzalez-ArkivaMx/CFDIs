using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ComplementoImpuestosLocales
   {
      [XmlAttribute]
      [Required]
      public string version { get; set; }

      [XmlAttribute]
      public decimal TotaldeRetenciones { get; set; }

      //public bool ShouldSerializeTotaldeRetenciones()
      //{
      //   return (TotaldeRetenciones > 0);
      //}

      [XmlAttribute]
      public decimal TotaldeTraslados { get; set; }

      //public bool ShouldSerializeTotaldeTraslados()
      //{
      //   return (TotaldeTraslados > 0);
      //}

      [XmlElement("RetencionesLocales")]
      public List<ImpuestosLocalesRetencionesLocales> Retenciones { get; set; } = new List<ImpuestosLocalesRetencionesLocales>();

      [XmlElement("TrasladosLocales")]
      public List<ImpuestosLocalesTrasladosLocales> Traslados { get; set; } = new List<ImpuestosLocalesTrasladosLocales>();
   }
}