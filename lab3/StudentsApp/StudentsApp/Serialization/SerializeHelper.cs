using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using StudentsApp.Responses;

namespace StudentsApp.Serialization
{
    public static class SerializeHelper
    {
        public static MediaTypeFormatter CreateMediaTypeFormatter(string format)
        {
            return CreateMediaTypeFormatter(format, new List<string>());
        }

        public static MediaTypeFormatter CreateMediaTypeFormatter(string format, List<string> ignoreFields)
        {
            switch (format)
            {
                case "json":
                    {
                        return new JsonMediaTypeFormatter
                        {
                            SerializerSettings = new JsonSerializerSettings
                            {
                                ContractResolver = new JsonExcludeFromResponseContractResolver(ignoreFields)
                            }
                        };
                    }
                case "xml":
                    {
                        var overrides = new XmlAttributeOverrides();
                        var xmlMediaTypeFormatter = new XmlMediaTypeFormatter()
                        {
                            UseXmlSerializer = true,
                            SupportedEncodings = { Encoding.UTF8 },
                            SupportedMediaTypes = { new MediaTypeHeaderValue("application/xml") }
                        };

                        foreach (var ignoredField in ignoreFields)
                        {
                            var attribs = new XmlAttributes { XmlIgnore = true };

                            attribs.XmlElements.Add(new XmlElementAttribute(ignoredField));
                            overrides.Add(typeof(StudentResponse), ignoredField, attribs);
                        }

                        var xmlSerializer = new XmlSerializer(typeof(Success<List<Success<StudentResponse>>>), overrides);
                        xmlMediaTypeFormatter.SetSerializer(typeof(Success<List<Success<StudentResponse>>>), xmlSerializer);

                        return xmlMediaTypeFormatter;
                    }
                default: throw new NotImplementedException();
            }
        }
    }
}