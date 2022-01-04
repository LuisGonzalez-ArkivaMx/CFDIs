using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Pago
   {
      [XmlAttribute]
      [Required]
      public string FechaPago { get; set; }

      [XmlAttribute]
      [StringLength(2)]
      public string FormaDePagoP { get; set; }

      [XmlAttribute]
      [Required]
      [StringLength(3)]
      public string MonedaP { get; set; }

      [XmlAttribute]
      public decimal TipoCambioP { get; set; }

      public bool ShouldSerializeTipoCambioP()
      {
         return (TipoCambioP > 0);
      }

      [XmlIgnore]
      [Required]
      public decimal Monto { get; set; }

      [XmlAttribute("Monto")]
      public string MontoString
      {
         get
         {
            return Monto.ToString("F2");
         }
         set
         {
            if (Decimal.TryParse(value, out decimal amount))
               Monto = amount;
         }
      }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(100)]
      public string NumOperacion { get; set; }

      [XmlAttribute]
      [MinLength(12)]
      [MaxLength(13)]
      public string RfcEmisorCtaOrd { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(300)]
      public string NomBancoOrdExt { get; set; }

      [XmlAttribute]
      [MinLength(10)]
      [MaxLength(50)]
      public string CtaOrdenante { get; set; }

      [XmlAttribute]
      [MinLength(12)]
      [MaxLength(13)]
      public string RfcEmisorCtaBen { get; set; }

      [XmlAttribute]
      [MinLength(10)]
      [MaxLength(50)]
      public string CtaBeneficiario { get; set; }

      [XmlAttribute]
      public string TipoCadPago { get; set; }

      [XmlAttribute]
      public string CertPago { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(8192)]
      public string CadPago { get; set; }

      [XmlAttribute]
      public string SelloPago { get; set; }

      [XmlElement("DoctoRelacionado")]
      public List<DoctoRelacionado> DoctoRelacionados { get; set; }
   }
}