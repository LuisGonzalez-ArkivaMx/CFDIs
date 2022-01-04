using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace gleintech.cfdi
{
   [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
   [XmlRoot(Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital", IsNullable = false)]
   public class TimbreFiscalDigital
   {
      [XmlAttribute("schemaLocation", AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
      public string SchemaLocation = "http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd";

      [XmlNamespaceDeclarations]
      public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces(new System.Xml.XmlQualifiedName[] { new System.Xml.XmlQualifiedName("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital") });

      [XmlAttribute]
      [Required]
      public string Version { get; set; }

      [XmlAttribute]
      [Required]
      public string UUID { get; set; }

      [XmlAttribute]
      [Required]
      public DateTime FechaTimbrado { get; set; }

      [XmlAttribute]
      [Required]
      public string RfcProvCertif { get; set; }

      [XmlAttribute]
      public string Leyenda { get; set; }

      public bool ShouldSerializeLeyenda()
      {
         return (Leyenda != null);
      }

      [XmlAttribute]
      [Required]
      public string SelloCFD { get; set; }

      [XmlAttribute]
      [Required]
      public string NoCertificadoSAT { get; set; }

      [XmlAttribute]
      [Required]
      public string SelloSAT { get; set; }
   }
}