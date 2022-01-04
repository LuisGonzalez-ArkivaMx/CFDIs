using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaPercepciones
   {
      [XmlElement("Percepcion")]
      public List<NominaPercepcionesPercepcion> Percepcion { get; set; }

      public NominaPercepcionesJubilacionPensionRetiro JubilacionPensionRetiro { get; set; }

      public NominaPercepcionesSeparacionIndemnizacion SeparacionIndemnizacion { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalSueldos { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalSeparacionIndemnizacion { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalJubilacionPensionRetiro { get; set; }

      [XmlAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalGravado { get; set; }

      [XmlAttribute()]
      [Required]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalExento { get; set; }
   }
}