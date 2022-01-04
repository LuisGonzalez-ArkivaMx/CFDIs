using System.Collections.Generic;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ComprobanteImpuesto
   {
      [XmlAttribute]
      public decimal TotalImpuestosRetenidos { get; set; }

      public bool ShouldSerializeTotalImpuestosRetenidos()
      {
         return (TotalImpuestosRetenidos > 0);
      }

      [XmlAttribute]
      public decimal TotalImpuestosTrasladados { get; set; }

      public bool ShouldSerializeTotalImpuestosTrasladados()
      {
         return (TotalImpuestosTrasladados > 0);
      }

      [XmlArray("Retenciones"), XmlArrayItem(typeof(ComprobanteRetencion), ElementName = "Retencion")]
      public List<ComprobanteRetencion> Retenciones { get; set; } = new List<ComprobanteRetencion>();

      [XmlArray("Traslados"), XmlArrayItem(typeof(ComprobanteTraslado), ElementName = "Traslado")]
      public List<ComprobanteTraslado> Traslados { get; set; } = new List<ComprobanteTraslado>();

      [XmlIgnore]
      public bool RetencionesSpecified
      {
         get { return (Retenciones != null && Retenciones.Count > 0); }
      }

      [XmlIgnore]
      public bool TrasladosSpecified
      {
         get { return (Traslados != null && Traslados.Count > 0); }
      }
   }
}