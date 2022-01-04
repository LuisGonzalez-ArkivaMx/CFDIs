using System.Collections.Generic;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Impuesto
   {
      [XmlArray("Traslados"), XmlArrayItem(typeof(Traslado), ElementName = "Traslado")]
      public List<Traslado> Traslados { get; set; } = new List<Traslado>();

      [XmlArray("Retenciones"), XmlArrayItem(typeof(Retencion), ElementName = "Retencion")]
      public List<Retencion> Retenciones { get; set; } = new List<Retencion>();

      [XmlIgnore]
      public bool RetencionesSpecified
      {
         get
         {
            bool isRendered = false;
            if (Retenciones != null)
            {
               isRendered = (this.Retenciones.Count > 0);
            }
            return isRendered;
         }
      }

      [XmlIgnore]
      public bool TrasladosSpecified
      {
         get
         {
            bool isRendered = false;
            if (Traslados != null)
            {
               isRendered = (this.Traslados.Count > 0);
            }
            return isRendered;
         }
      }
   }
}