using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaPercepcionesJubilacionPensionRetiro
   {
      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalUnaExhibicion { get; set; }

      [XmlIgnore]
      public bool showTotalParcialidad { get; set; }

      public bool ShouldSerializeTotalParcialidad()
      {
         return showTotalParcialidad;
      }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal TotalParcialidad { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal MontoDiario { get; set; }

      [XmlIgnore]
      public bool showMontoDiario { get; set; }

      public bool ShouldSerializeMontoDiario()
      {
         return showMontoDiario;
      }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal IngresoAcumulable { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal IngresoNoAcumulable { get; set; }
   }
}