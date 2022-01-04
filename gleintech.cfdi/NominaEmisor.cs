using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaEmisor
   {
      public NominaEmisorEntidadSNCF EntidadSNCF { get; set; }

      public bool ShouldSerializeEntidadSNCF()
      {
         return (EntidadSNCF.OrigenRecurso != "");
      }

      [XmlAttributeAttribute()]
      [RegularExpression("[A-Z][AEIOUX][A-Z]{2}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[MH]([ABCMTZ]S|[BCJMOT]C|[CNPST]L|[GNQ]T|[GQS]R|C[MH]|[MY]N|[DH]G|NE|VZ|DF|SP)[BCDFGHJ-NP-TV-Z]{3}[0-9A-Z][0-9]")]
      [StringLength(18)]
      public string Curp { get; set; }

      [XmlAttributeAttribute()]
      [RegularExpression("[^|]{1,20}")]
      [MinLength(1)]
      [MaxLength(20)]
      public string RegistroPatronal { get; set; }

      [XmlAttributeAttribute()]
      public string RfcPatronOrigen { get; set; }
   }
}