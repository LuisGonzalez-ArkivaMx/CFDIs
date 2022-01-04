using System;

namespace gleintech.cfdi.Formatter
{
   [AttributeUsage(AttributeTargets.Property)]
   public class DecimalFormatterAttribute : Attribute
   {
      public DecimalFormatterAttribute(string formatString)
      {
         Format = formatString;
      }

      public string Format { get; private set; }
   }
}