using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaOtroPagoCompensacionSaldosAFavor
   {
      /// <remarks/>
      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal SaldoAFavor { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      public short Año { get; set; }

      [XmlAttributeAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal RemanenteSalFav { get; set; }
   }
}