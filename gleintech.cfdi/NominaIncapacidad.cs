using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class NominaIncapacidad
   {
      [XmlAttribute()]
      public int DiasIncapacidad { get; set; }

      [XmlAttribute()]
      public string TipoIncapacidad { get; set; }

      [XmlAttribute()]
      [RegularExpression("[0-9]{1,18}(.[0-9]{1,2})?")]
      public decimal ImporteMonetario { get; set; }
   }
}