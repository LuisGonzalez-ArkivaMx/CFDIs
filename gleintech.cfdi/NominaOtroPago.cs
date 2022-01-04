using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaOtroPago
   {
      public NominaOtroPagoSubsidioAlEmpleo SubsidioAlEmpleo { get; set; }

      public bool ShouldSerializeSubsidioAlEmpleo()
      {
         return (TipoOtroPago == "002");
      }

      public NominaOtroPagoCompensacionSaldosAFavor CompensacionSaldosAFavor { get; set; }

      public bool ShouldSerializeCompensacionSaldosAFavor()
      {
         return (CompensacionSaldosAFavor.RemanenteSalFav > 0);
      }

      [XmlAttributeAttribute()]
      [Required]
      public string TipoOtroPago { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[^|]{3,15}")]
      [MinLength(3)]
      [MaxLength(15)]
      public string Clave { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[^|]{1,100}")]
      [MinLength(1)]
      [MaxLength(100)]
      public string Concepto { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal Importe { get; set; }
   }
}