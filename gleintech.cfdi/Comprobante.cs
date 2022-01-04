using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   [XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
   [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
   public class Comprobante : IValidatableObject
   {
      [XmlAttributeAttribute("schemaLocation", AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
      public string SchemaLocation = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd  http://www.sat.gob.mx/implocal http://www.sat.gob.mx/sitio_internet/cfd/implocal/implocal.xsd";

      //public Guid Id { get; set; }

      [XmlAttribute]
      [Required]
      public string Version { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(25)]
      public string Serie { get; set; }

      [XmlAttribute]
      [MinLength(1)]
      [MaxLength(40)]
      public string Folio { get; set; }

      [XmlAttribute]
      //[Required]
      public string Fecha { get; set; }

      //public System.DateTime Fecha { get; set; }

      [XmlAttribute]
      public string Sello { get; set; }

      [XmlAttribute]
      [StringLength(2)]
      public string FormaPago { get; set; }

      [XmlAttribute]
      //[Required]
      [StringLength(20)]
      public string NoCertificado { get; set; }

      [XmlAttribute]
      //[Required]
      public string Certificado { get; set; }

      [XmlAttribute]
      //[MinLength(1)]
      [MaxLength(1000)]
      public string CondicionesDePago { get; set; }

      public bool ShouldSerializeCondicionesDePago()
      {
         return CondicionesDePago.Length > 0;
      }

      [XmlAttribute]
      [Required]
      public decimal SubTotal { get; set; }

      [XmlAttribute]
      public decimal Descuento { get; set; }

      public bool ShouldSerializeDescuento()
      {
         return (Descuento > 0);
      }

      [XmlAttribute]
      [Required]
      [StringLength(3)]
      public string Moneda { get; set; }

      [XmlAttribute]
      public string TipoCambio { get; set; }

      public bool ShouldSerializeTipoCambio()
      {
         return (TipoCambio != "");
      }

      [XmlAttribute]
      [Required]
      public decimal Total { get; set; }

      [XmlAttribute]
      [Required]
      [StringLength(1)]
      public string TipoDeComprobante { get; set; }

      [XmlAttribute]
      [MinLength(3)]
      public string MetodoPago { get; set; }

      [XmlAttribute]
      [MaxLength(10)]
      public string LugarExpedicion { get; set; }

      [XmlAttribute]
      [MinLength(5)]
      public string Confirmacion { get; set; }

      public CfdiRelacionados CfdiRelacionados { get; set; }

      [Required]
      public Emisor Emisor { get; set; }

      [Required]
      public Receptor Receptor { get; set; }

      [Required]
      [XmlArray("Conceptos"), XmlArrayItem(typeof(Concepto), ElementName = "Concepto")]
      public List<Concepto> Conceptos { get; set; } = new List<Concepto>();

      public ComprobanteImpuesto Impuestos { get; set; }  //hay que ver como lo voy a hacer por los las clases que tienen el mismo nombre

      public Complemento Complemento { get; set; } = new Complemento();

      [XmlAnyElement("Addenda")]
      public XmlElement Addenda { get; set; }

      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {
         #region "Comprobante de Recepción de Pago"

         if (TipoDeComprobante == "P")
         {
            //NODO COMPROBANTE
            if (SubTotal != 0)
            {
               yield return new ValidationResult("El valor del campo Subtotal debe ser cero.");
            }
            if (Total != 0)
            {
               yield return new ValidationResult("El valor del campo Total debe ser cero.");
            }
            if (FormaPago != null)
            {
               yield return new ValidationResult("No se debe incluir el campo FormaPago");
            }
            if (CondicionesDePago != null)
            {
               yield return new ValidationResult("No se debe incluir el campo CondicionesDePago.");
            }
            if (Descuento > 0)
            {
               yield return new ValidationResult("No se debe incluir el campo Descuento.");
            }
            if (TipoCambio != "")
            {
               yield return new ValidationResult("No se debe incluir el campo TipoCambio.");
            }
            if (MetodoPago != null)
            {
               yield return new ValidationResult("No se debe incluir el campo MetodoPago.");
            }

            if (Moneda != "XXX")
            {
               yield return new ValidationResult("El valor del campo Moneda debe ser XXX.");
            }

            //NODO RECEPTOR
            if (Receptor.UsoCFDI != "P01")
            {
               yield return new ValidationResult("El valor del campo UsoCFDI debe ser P01.");
            }

            //NODO CONCEPTOS
            int cantidadConceptos = Conceptos.Count;
            if (cantidadConceptos != 1)
            {
               yield return new ValidationResult("Solo se debe de incluir un Concepto.");
            }

            if (cantidadConceptos == 1)
            {
               //Se suponer que debe de tener un solo elemento
               var NodoConceptoCFDIPAgo = Conceptos[0];

               if (NodoConceptoCFDIPAgo.NoIdentificacion != null)
               {
                  yield return new ValidationResult("No se debe incluir el campo NoIdentificacion.");
               }

               if (NodoConceptoCFDIPAgo.Unidad != null) //| NodoConceptoCFDIPAgo.Unidad != ""
               {
                  yield return new ValidationResult("No se debe incluir el campo Unidad.");
               }

               if (NodoConceptoCFDIPAgo.Descuento > 0)
               {
                  yield return new ValidationResult("No se debe incluir el campo Descuento.");
               }

               if (NodoConceptoCFDIPAgo.ValorUnitario != 0)
               {
                  yield return new ValidationResult("El valor del campo ValorUnitario debe ser cero.");
               }

               if (NodoConceptoCFDIPAgo.Importe != 0)
               {
                  yield return new ValidationResult("El valor del campo Importe debe ser cero.");
               }

               if (NodoConceptoCFDIPAgo.ClaveProdServ != "84111506")
               {
                  yield return new ValidationResult("El valor del campo ClaveProdServ debe ser 84111506.");
               }

               if (NodoConceptoCFDIPAgo.Cantidad != 1)
               {
                  yield return new ValidationResult("El valor del campo Cantidad debe ser 1.");
               }

               if (NodoConceptoCFDIPAgo.ClaveUnidad != "ACT")
               {
                  yield return new ValidationResult("El valor del campo ClaveUnidad debe ser ACT.");
               }

               if (NodoConceptoCFDIPAgo.Descripcion != "Pago")
               {
                  yield return new ValidationResult("El valor del campo Descripcion debe ser Pago.");
               }

               if (NodoConceptoCFDIPAgo.InformacionAduanera != null)
               {
                  yield return new ValidationResult("No se debe incluir el nodo Impuestos.");
               }

               if (NodoConceptoCFDIPAgo.CuentaPredial != null)
               {
                  yield return new ValidationResult("No se debe incluir el nodo CuentaPredial.");
               }

               if (NodoConceptoCFDIPAgo.Parte != null)
               {
                  yield return new ValidationResult("No se debe incluir el nodo Parte.");
               }

               if (NodoConceptoCFDIPAgo.Impuestos != null)
               {
                  yield return new ValidationResult("No se debe incluir el nodo Impuestos.");
               }
            }
            //NODO IMPUESTOS
            if (Impuestos != null)
            {
               yield return new ValidationResult("No se debe incluir el nodo Impuestos.");
            }

            //NODO COMPLEMENTO
            if (Complemento == null)
            {
               yield return new ValidationResult("Se debe incluir el nodo Complemento.");
            }
            else
            {
               if (Complemento.Pagos == null)
               {
                  yield return new ValidationResult("Se debe incluir el nodo Pagos.");
               }
               else
               {
                  if (Complemento.Pagos.Pago.Count == 0)
                  {
                     yield return new ValidationResult("Se debe incluir al menos un nodo de Pago.");
                  }
                  else
                  {
                     foreach (var Pago in Complemento.Pagos.Pago)
                     {
                        if (Pago.FechaPago == null)
                        {
                           yield return new ValidationResult("Se debe incluir el valor del campo FechaPago.");
                        }
                        if (Pago.FormaDePagoP == null)
                        {
                           yield return new ValidationResult("Se debe incluir el valor del campo FormaDePagoP.");
                        }
                        if (Pago.TipoCadPago != null)
                        {
                           if (Pago.TipoCadPago != "01")
                           {
                              yield return new ValidationResult("El valor del campo TipoCadPago debe ser 01.");
                           }
                           else
                           {//Se supone que el TipoCadPago es 01 en teoria tons tenemos que validar los demas campos
                              if (Pago.CertPago == null)
                              {
                                 yield return new ValidationResult("Debe incluir el valor del campo CertPago.");
                              }
                              if (Pago.CadPago == null)
                              {
                                 yield return new ValidationResult("Debe incluir el valor del campo CadPago.");
                              }
                              if (Pago.SelloPago == null)
                              {
                                 yield return new ValidationResult("Debe incluir el valor del campo SelloPago.");
                              }
                           }
                        }
                     }
                  }
               }
            }
         }

         #endregion "Comprobante de Recepción de Pago"

         #region "Comprobante de Traslado"

         if (TipoDeComprobante == "T")
         {
            if (Moneda != "MXN")
            {
               yield return new ValidationResult("El valor del campo Moneda debe ser MXN.");
            }

            if (LugarExpedicion == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo LugarExpedicion.");
            }

            if (Folio == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Folio.");
            }

            if (Serie == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Serie.");
            }
            if (Emisor.Nombre == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Emisor Nombre.");
            }

            if (Emisor.Rfc == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Emisor RFC.");
            }

            if (Emisor.RegimenFiscal == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo RegimenFiscal.");
            }

            if (Receptor.Rfc != "XAXX010101000")
            {
               yield return new ValidationResult("El valor del campo Receptor RFC debe ser XAXX010101000.");
            }

            if (Receptor.UsoCFDI != "P01")
            {
               yield return new ValidationResult("El valor del campo Receptor UsoCFDI debe ser P01.");
            }

            foreach (var concepto in Conceptos)
            {
               if (concepto.ClaveProdServ == null)
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo ClaveProdServ.");
               }
               if (concepto.Equals(null))
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo Cantidad.");
               }
               if (concepto.ClaveUnidad == null)
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo ClaveUnidad.");
               }
               if (concepto.Descripcion == null)
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo Descripción.");
               }
               if (!concepto.Descripcion.Contains("Traslado de mercancías"))
               {
                  yield return new ValidationResult("El valor del campo Descripcion debe incluir Traslado de mercancías");
               }
               if (concepto.ValorUnitario != 0)
               {
                  yield return new ValidationResult("El valor del campo ValorUnitario debe ser 0.");
               }
               if (concepto.Importe != 0)
               {
                  yield return new ValidationResult("El valor del campo Importe debe ser 0.");
               }
            }

            if (FormaPago != null)
            {
               yield return new ValidationResult("No se debe incluir el campo FormaPago");
            }
            if (MetodoPago != null)
            {
               yield return new ValidationResult("No se debe incluir el campo MetodoPago.");
            }
            if (Descuento > 0)
            {
               yield return new ValidationResult("No se debe incluir el campo Descuento.");
            }

            if (Impuestos != null)
            {
               yield return new ValidationResult("No se debe incluir el nodo Impuestos.");
            }
            if (CfdiRelacionados != null)
            {
               yield return new ValidationResult("No se debe incluir el nodo CFDI Relacionados.");
            }
         }

         #endregion "Comprobante de Traslado"

         #region "Comprobante de Egreso"

         if (TipoDeComprobante == "E")
         {
            if (Moneda == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Moneda.");
            }

            if (FormaPago == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo FormaPago.");
            }

            if (MetodoPago == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo MetodoPago.");
            }

            if (LugarExpedicion == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo LugarExpedicion.");
            }

            if (Folio == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Folio.");
            }

            if (Serie == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Serie.");
            }

            if (Emisor.Nombre == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Emisor Nombre.");
            }

            if (Emisor.Rfc == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Emisor RFC.");
            }

            if (Emisor.RegimenFiscal == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo RegimenFiscal.");
            }

            if (Receptor.Nombre == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Receptor Nombre.");
            }

            if (Receptor.Rfc == null)
            {
               yield return new ValidationResult("Se debe incluir el valor del campo Receptor RFC.");
            }

            if (Receptor.UsoCFDI != "P01")
            {
               yield return new ValidationResult("El valor del campo UsoCFDI debe ser P01.");
            }

            foreach (var concepto in Conceptos)
            {
               if (concepto.ClaveProdServ == null)
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo ClaveProdServ.");
               }

               if (concepto.Cantidad.Equals(null))
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo Cantidad.");
               }

               if (concepto.ClaveUnidad == null)
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo ClaveUnidad.");
               }

               if (concepto.Descripcion == null)
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo Descripción.");
               }

               if (concepto.ValorUnitario.Equals(null))
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo ValorUnitario.");
               }

               if (concepto.Importe.Equals(null))
               {
                  yield return new ValidationResult("Se debe incluir el valor del campo Importe.");
               }
            }

            if (Impuestos == null)
            {
               yield return new ValidationResult("se debe incluir el nodo Impuestos.");
            }

            if (CfdiRelacionados == null)
            {
               yield return new ValidationResult("Se debe incluir el nodo CFDI Relacionados.");
            }
         }

         #endregion "Comprobante de Egreso"
      }
   }
}