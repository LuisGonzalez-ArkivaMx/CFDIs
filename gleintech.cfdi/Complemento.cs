using System.Xml.Serialization;

namespace gleintech.cfdi
{
   public class Complemento
   {
      [XmlElement(ElementName = "Pagos", Namespace = "http://www.sat.gob.mx/Pagos")]
      public ComplementoPagos Pagos { get; set; }

      [XmlElement(ElementName = "Nomina", Namespace = "http://www.sat.gob.mx/nomina12")]
      public ComplementoNomina Nomina { get; set; }

      [XmlElement(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
      public TimbreFiscalDigital TimbreFiscalDigital { get; set; }

      [XmlElement(ElementName = "ImpuestosLocales", Namespace = "http://www.sat.gob.mx/implocal")]
      public ComplementoImpuestosLocales ImpuestosLocales { get; set; }
   }
}