using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Concepto  // : IValidatableObject
   {
      [XmlAttribute]
      [Required]
      [MinLength(1)]
      [MaxLength(30)]
      public string ClaveProdServ { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(100)]
      public string NoIdentificacion { get; set; }

      [XmlAttribute]
      [Required]
      public decimal Cantidad { get; set; }

      [XmlAttribute]
      [Required]
      [MinLength(1)]
      [MaxLength(3)]
      public string ClaveUnidad { get; set; }

      [XmlAttribute]
      [MinLength(0)]
      [MaxLength(20)]
      public string Unidad { get; set; }

      public bool ShouldSerializeUnidad()
      {
         return (Unidad != null && !String.IsNullOrEmpty(Unidad));
      }

      [XmlAttribute]
      [Required]
      [MinLength(1)]
      [MaxLength(1000)]
      public string Descripcion { get; set; }

      [XmlAttribute]
      [Required]
      public decimal ValorUnitario { get; set; }

      [XmlAttribute]
      [Required]
      public decimal Importe { get; set; }

      [XmlAttribute]
      public decimal Descuento { get; set; }

      public bool ShouldSerializeDescuento()
      {
         return (Descuento > 0);
      }

      public Impuesto Impuestos { get; set; }

      public List<InformacionAduanera> InformacionAduanera { get; set; }  //revisar esta opcion que se puede repetir n veces

      public bool ShouldSerializeInformacionAduanera()
      {
         return (InformacionAduanera != null && InformacionAduanera.Count > 0);
      }

      public CuentaPredial CuentaPredial { get; set; }

      public ComplementoConcepto ComplementoConcepto { get; set; }

      public List<Parte> Parte { get; set; }

      public bool ShouldSerializeParte()
      {
         return (Parte != null && Parte.Count > 0);
      }
   }
}