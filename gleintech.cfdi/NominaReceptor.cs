using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaReceptor
   {
      [XmlElementAttribute("SubContratacion")]
      public List<NominaReceptorSubContratacion> SubContratacion { get; set; }

      [XmlAttribute()]
      [Required]
      [RegularExpression("[A-Z][AEIOUX][A-Z]{2}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[MH]([ABCMTZ]S|[BCJMOT]C|[CNPST]L|[GNQ]T|[GQS]R|C[MH]|[MY]N|[DH]G|NE|VZ|DF|SP)[BCDFGHJ-NP-TV-Z]{3}[0-9A-Z][0-9]")]
      [StringLength(18)]
      public string Curp { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,15}")]
      [MinLength(1)]
      [MaxLength(15)]
      public string NumSeguridadSocial { get; set; }

      [XmlAttribute(DataType = "date")]
      public DateTime FechaInicioRelLaboral { get; set; }

      [XmlAttribute()]
      [RegularExpression("P(([1-9][0-9]{0,3})|0)W|P([1-9][0-9]?Y)?(([1-9]|1[012])M)?(0|[1-9]|[12][0-9]|3[01])D")]
      public string Antigüedad { get; set; }

      [XmlAttribute()]
      [Required]
      public string TipoContrato { get; set; }

      [XmlAttribute()]
      public string Sindicalizado { get; set; }

      [XmlAttribute()]
      public string TipoJornada { get; set; }

      [XmlAttribute()]
      [Required]
      public string TipoRegimen { get; set; }

      [XmlAttribute()]
      [Required]
      [RegularExpression("[^|]{1,15}")]
      [MinLength(1)]
      [MaxLength(15)]
      public string NumEmpleado { get; set; }

      [XmlAttribute()]
      [RegularExpression("[^|]{1,100}")]
      [MinLength(1)]
      [MaxLength(100)]
      public string Departamento { get; set; }

      [XmlAttribute()]
      [RegularExpression("[^|]{1,100}")]
      [MinLength(1)]
      [MaxLength(100)]
      public string Puesto { get; set; }

      [XmlAttribute()]
      public string RiesgoPuesto { get; set; }

      [XmlAttribute()]
      [Required]
      public string PeriodicidadPago { get; set; }

      [XmlAttribute()]
      public string Banco { get; set; }//No viene en el archivo NOM

      [XmlAttribute(DataType = "integer")]
      [RegularExpression("[0-9]{10,18}")]
      [MinLength(10)]
      [MaxLength(18)]
      public string CuentaBancaria { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal SalarioBaseCotApor { get; set; }

      public bool ShouldSerializeSalarioBaseCotApor()
      {
         return (SalarioBaseCotApor > 0);
      }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal SalarioDiarioIntegrado { get; set; }

      [XmlAttribute()]
      [Required]
      public string ClaveEntFed { get; set; }
   }
}