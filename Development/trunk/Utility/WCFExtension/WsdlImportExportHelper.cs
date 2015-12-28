using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.Runtime.Serialization;
using Wang.Velika.Utility.GeneralLibrary;
using Wsdl = System.Web.Services.Description;
using System.Xml;

namespace Wang.Velika.Utility.WCFExtension
{
    public static class WsdlImportExportHelper
    {
        public static void ExportHeaderToAllOpreations(Type headerType, WsdlExporter exporter, string headerMessageName, string headerPartName, WsdlHeaderOptionElement option)
        {
            if ((option != null) && ((option.ExportInputEnabled) || (option.ExportOutputEnabled)))
            {
                XmlQualifiedName xqn = ExportTypeToXsd(headerType, exporter);
                Wsdl.Message msg = WsdlHelper.CreateSinglePartMessage(headerMessageName, headerPartName, xqn);
                foreach (Wsdl.ServiceDescription svc in exporter.GeneratedWsdlDocuments)
                {
                    if (svc.Messages.Count > 0)
                    {
                        svc.Messages.Add(msg);
                    }
                    WsdlHelper.AddHeaderToAllOperationsInService(svc, msg, null,
                        option.ExportInputEnabled,
                        option.ExportInputRequired,
                        option.ExportOutputEnabled,
                        option.ExportOutputRequired);
                }
            }
        }

        public static XmlQualifiedName ExportTypeToXsd(Type headerType, WsdlExporter exporter)
        {
            if (headerType == null)
            {
                throw new ArgumentNullException("headerType");
            }
            if (exporter == null)
            {
                throw new ArgumentNullException("exporter");
            }

            XsdDataContractExporter xsd = new XsdDataContractExporter(exporter.GeneratedXmlSchemas);
            xsd.Export(headerType);

            return xsd.GetSchemaTypeName(headerType);
        }

    }
}
