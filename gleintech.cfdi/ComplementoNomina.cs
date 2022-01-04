using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class ComplementoNomina
   {
      [XmlAttribute]
      [Required]
      public string Version { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      public string TipoNomina { get; set; }

      [XmlAttributeAttribute(DataType = "date")]
      [Required]
      public DateTime FechaPago { get; set; }

      [XmlAttributeAttribute(DataType = "date")]
      [Required]
      public DateTime FechaInicialPago { get; set; }

      [XmlAttributeAttribute(DataType = "date")]
      [Required]
      public DateTime FechaFinalPago { get; set; }

      [XmlAttributeAttribute()]
      [RegularExpression("(([1-9][0-9]{0,4})|[0])(.[0-9]{3})?")]
      [Range(0.001, 36160.000)]
      [Required]
      public decimal NumDiasPagados { get; set; }

      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalPercepciones { get; set; }

      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalDeducciones { get; set; }

      public bool ShouldSerializeTotalDeducciones()
      {
         if (Deducciones.Deduccion.Count == 0)
         {
            return false;
         }
         return true;
      }

      [XmlAttributeAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalOtrosPagos { get; set; }

      public bool ShouldSerializeTotalOtrosPagos()
      {
         return (OtrosPagos.Count > 0);
      }

      public NominaEmisor Emisor { get; set; }

      public NominaReceptor Receptor { get; set; }

      public NominaPercepciones Percepciones { get; set; }

      public NominaDeducciones Deducciones { get; set; }

      public bool ShouldSerializeDeducciones()
      {
         return Deducciones.Deduccion.Count > 0;
      }

      [XmlArrayItemAttribute("OtroPago", IsNullable = false)]
      public List<NominaOtroPago> OtrosPagos { get; set; }

      public bool ShouldSerializeOtrosPagos()
      {
         return (OtrosPagos.Count > 0);
      }

      [XmlArrayItemAttribute("Incapacidad", IsNullable = false)]
      public List<NominaIncapacidad> Incapacidades { get; set; }

      public bool ShouldSerializeIncapacidades()
      {
         return (Incapacidades.Count > 0);
      }
   }
}