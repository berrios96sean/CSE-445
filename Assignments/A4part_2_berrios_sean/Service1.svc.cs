using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace A4part_2_berrios_sean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string verification(string xml, string xsd)
        {
            try
            {
                XmlDocument schemaDoc = new XmlDocument();
                schemaDoc.Load(xsd);
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(XmlSchema.Read(new StringReader(schemaDoc.OuterXml), null));
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xml);
                xmlDoc.Schemas = schemaSet;
                xmlDoc.Validate(null);

                return "No Error";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

    }
}
