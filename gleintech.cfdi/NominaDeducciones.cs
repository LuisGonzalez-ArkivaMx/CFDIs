using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaDeducciones
   {
      [XmlElementAttribute("Deduccion")]
      public List<NominaDeduccionesDeduccion> Deduccion { get; set; }

      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalOtrasDeducciones { get; set; }

      public bool ShouldSerializeTotalOtrasDeducciones()
      {
         return (TotalOtrasDeducciones > 0);
      }

      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalImpuestosRetenidos { get; set; }

      public bool ShouldSerializeTotalImpuestosRetenidos()
      {
         return (TotalImpuestosRetenidos > 0);
      }
   }
}