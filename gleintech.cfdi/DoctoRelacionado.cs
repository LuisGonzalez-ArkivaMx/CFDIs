using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class DoctoRelacionado
   {
      [XmlAttribute]
      [MinLength(16)]
      [MaxLength(36)]
      [Required]
      public string IdDocumento { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(25)]
      public string Serie { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(40)]
      public string Folio { get; set; }

      [XmlAttribute]
      [Required]
      [StringLength(3)]
      public string MonedaDR { get; set; }

      [XmlAttribute]
      public decimal TipoCambioDR { get; set; }

      public bool ShouldSerializeTipoCambioDR()
      {
         return (TipoCambioDR > 0);
      }

      [XmlAttribute]
      [MinLength(3)]
      [Required]
      public string MetodoDePagoDR { get; set; }

      [XmlAttribute]
      public int NumParcialidad { get; set; }

      public bool ShouldSerializeNumParcialidad()
      {
         return (NumParcialidad > 0);
      }

      [XmlAttribute]
      [XmlIgnore]
      public decimal ImpSaldoAnt { get; set; }

      [XmlAttribute("ImpSaldoAnt")]
      public string ImpSaldoAntString
      {
         get
         {
            return ImpSaldoAnt.ToString("F2");
         }
         set
         {
            decimal amount;
            if (decimal.TryParse(value, out amount))
               ImpSaldoAnt = amount;
         }
      }

      public bool ShouldSerializeImpSaldoAnt()
      {
         return (ImpSaldoAnt > 0);
      }

      [XmlAttribute]
      [XmlIgnore]
      public decimal ImpPagado { get; set; }

      [XmlAttribute("ImpPagado")]
      public string ImpPagadoString
      {
         get
         {
            return ImpPagado.ToString("F2");
         }
         set
         {
            decimal amount;
            if (Decimal.TryParse(value, out amount))
               ImpPagado = amount;
         }
      }

      public bool ShouldSerializeImpPagado()
      {
         return (ImpPagado > 0);
      }

      [XmlAttribute]
      [XmlIgnore]
      public decimal ImpSaldoInsoluto { get; set; }

      [XmlAttribute("ImpSaldoInsoluto")]
      public string ImpSaldoInsolutoString
      {
         get
         {
            return ImpSaldoInsoluto.ToString("F2");
         }
         set
         {
            decimal amount;
            if (Decimal.TryParse(value, out amount))
               ImpSaldoInsoluto = amount;
         }
      }

      public bool ShouldSerializeImpSaldoInsoluto()
      {
         return (ImpSaldoInsoluto > 0);
      }
   }
}