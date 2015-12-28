using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.IO;
using System.Reflection;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class XMLHelper
    {
        private const string XML_NAMESPACE_DECLARATION_PREFIX = "xmlns";
        private const string XML_NAMESPACE_DECLARATION_NAMESPACRURL = "http://www.w3.org/2000/xmlns/";


        private static object ConvertToObject(Type t, XmlReader xr)
        {
            XmlSerializer xser = new XmlSerializer(t);
            return xser.Deserialize(xr);
        }

        public static object ConvertToObject(Type t, XmlDocument xd, XmlSchema xsd)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            if (xd == null)
            {
                throw new ArgumentNullException("xd");
            }

            XmlReader xr = null;
            if (xsd == null)
            {
                xr = new XmlNodeReader(xd);
            }
            else
            {
                Stream stm = ConvertXMLToStream(xd);
                XmlReaderSettings xrs = new XmlReaderSettings();
                xrs.ValidationType = ValidationType.Schema;
                xrs.Schemas.Add(xsd);
                xr = XmlReader.Create(stm, xrs);
            }

            return ConvertToObject(t, xr);
        }

        public static object ConvertToObject(Type t, Stream stm, XmlSchema xsd)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            if (stm == null)
            {
                throw new ArgumentNullException("stm");
            }

            XmlReader xr = null;
            if (xsd == null)
            {
                xr = XmlReader.Create(stm);
            }
            else
            {
                XmlReaderSettings xrs = new XmlReaderSettings();
                xrs.ValidationType = ValidationType.Schema;
                xrs.Schemas.Add(xsd);
                xr = XmlReader.Create(stm, xrs);
            }

            return ConvertToObject(t, xr);
        }

        public static T ConvertToObject<T>(XmlDocument xd, XmlSchema xsd)
            where T : class
        {
            return (T)ConvertToObject(typeof(T), xd, xsd);
        }

        public static T ConvertToObject<T>(Stream stm, XmlSchema xsd)
            where T : class
        {
            return (T)ConvertToObject(typeof(T), stm, xsd);
        }

        public static object ConvertToObject(Type t, XmlDocument xd, Assembly asm, string xsdPath)
        {
            Stream stm = ReflectionHelper.LoadResourceOfAssembly(asm, xsdPath);
            XmlSchema xsd = XmlSchema.Read(stm, null);

            return ConvertToObject(t, xd, xsd);
        }

        public static object ConvertToObject(Type t, Stream stm, Assembly asm, string xsdPath)
        {
            Stream stmXsd = ReflectionHelper.LoadResourceOfAssembly(asm, xsdPath);
            XmlSchema xsd = XmlSchema.Read(stmXsd, null);

            return ConvertToObject(t, stm, xsd);
        }

        public static T ConvertToObject<T>(XmlDocument xd, Assembly asm, string xsdPath)
            where T : class
        {
            return (T)ConvertToObject(typeof(T), xd, asm, xsdPath);
        }

        public static T ConvertToObject<T>(Stream stm, Assembly asm, string xsdPath)
            where T : class
        {
            return (T)ConvertToObject(typeof(T), stm, asm, xsdPath);
        }

        public static Stream ConvertXMLToStream(XmlDocument xd)
        {
            if (xd == null)
            {
                throw new ArgumentNullException("xd");
            }

            MemoryStream ret = new MemoryStream();
            StreamWriter sw = new StreamWriter(ret);
            sw.Write(xd.OuterXml);
            sw.Flush();
            ret.Seek(0L, SeekOrigin.Begin);

            return ret;
        }

        public static XmlAttribute CreateXMLNamespaceSpecifier(XmlDocument xd, string ns)
        {
            if (xd == null)
            {
                throw new ArgumentNullException("xd");
            }

            XmlAttribute ret = xd.CreateAttribute(XML_NAMESPACE_DECLARATION_PREFIX);
            ret.Value = ns;

            return ret;
        }

        public static bool RemoveXMLNamespaceSpecifier(XmlNode xn)
        {
            if (xn == null)
            {
                throw new ArgumentNullException("xn");
            }

            XmlNode target = xn;
            if (target.NodeType == XmlNodeType.Document)
            {
                target = ((XmlDocument)target).DocumentElement;
            }
            XmlAttribute xa = target.Attributes[XML_NAMESPACE_DECLARATION_PREFIX];
            bool ret = (xa != null);
            if (ret)
            {
                target.Attributes.Remove(xa);
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="ns"></param>
        /// <returns>
        /// Original namespace.
        /// <remarks>
        /// <b>null</b> means no &quot;xmlns&quot; attribute. <see cref="String.Empty"/> means there is &quot;xmlns&quot; but with empty value.
        /// </remarks>
        /// </returns>
        public static string ApplyNamespaceToNode(XmlNode xn, string ns)
        {
            if (xn == null)
            {
                throw new ArgumentNullException("xn");
            }

            XmlDocument owner = xn.OwnerDocument;
            XmlNode target = xn;
            if (target.NodeType == XmlNodeType.Document)
            {
                owner = (XmlDocument)target;
                target = owner.DocumentElement;
            }
            string ret = null;
            XmlAttribute xa = target.Attributes[XML_NAMESPACE_DECLARATION_PREFIX];
            if (xa == null)
            {
                xa = CreateXMLNamespaceSpecifier(owner, null);
                target.Attributes.Append(xa);
            }
            else
            {
                ret = xa.Value;
            }
            xa.Value = ns;

            return ret;
        }

        public static string RetrieveNamecpaceOfSerializationClass(Type t)
        {
            string ret = null;
            XmlRootAttribute att = RetrieveRootAttributeOfSerializationClass(t);
            if (att != null)
            {
                ret = att.Namespace;
            }

            return ret;
        }

        public static string RetrieveElementNameOfSerializationClass(Type t)
        {
            string ret = null;
            XmlRootAttribute att = RetrieveRootAttributeOfSerializationClass(t);
            if (att != null)
            {
                ret = att.ElementName;
            }
            if (String.IsNullOrEmpty(ret))
            {
                ret = t.Name;
            }

            return ret;
        }

        private static XmlRootAttribute RetrieveRootAttributeOfSerializationClass(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            return (XmlRootAttribute)Attribute.GetCustomAttribute(t, typeof(XmlRootAttribute));
        }

        public static XmlDocument NormalizeXmlDocumentWithoutNamespace(XmlDocument xd)
        {
            if (xd == null)
            {
                throw new ArgumentNullException("xd");
            }

            XmlDocument ret = new XmlDocument();
            XmlElement documentElement = NormalizeXmlElementWithoutNamespace(xd.DocumentElement, ret);
            ret.AppendChild(documentElement);

            return ret;
        }

        public static XmlElement NormalizeXmlElementWithoutNamespace(XmlElement xe, XmlDocument targetDocument)
        {
            if (xe == null)
            {
                throw new ArgumentNullException("xe");
            }
            if (targetDocument == null)
            {
                throw new ArgumentNullException("targetDocument");
            }

            XmlElement ret = targetDocument.CreateElement(xe.Name);
            foreach (XmlNode xn in xe.ChildNodes)
            {
                switch (xn.NodeType)
                {
                    case XmlNodeType.Text:
                        XmlText childText = NormalizeXmlTextWithoutNamespace((XmlText)xn, targetDocument);
                        ret.AppendChild(childText);
                        break;
                    case XmlNodeType.Attribute:
                        XmlAttribute childAttribute = NormalizeXmlAttributeWithoutNamespace((XmlAttribute)xn, targetDocument);
                        ret.Attributes.Append(childAttribute);
                        break;
                    case XmlNodeType.Element:
                        XmlElement childElement = NormalizeXmlElementWithoutNamespace((XmlElement)xn, targetDocument);
                        ret.AppendChild(childElement);
                        break;
                }
            }

            return ret;
        }

        public static XmlAttribute NormalizeXmlAttributeWithoutNamespace(XmlAttribute xa, XmlDocument targetDocument)
        {
            if (xa == null)
            {
                throw new ArgumentNullException("xa");
            }
            if (targetDocument == null)
            {
                throw new ArgumentNullException("targetDocument");
            }

            XmlAttribute ret = targetDocument.CreateAttribute(xa.Name);
            ret.Value = xa.Value;

            return ret;
        }

        public static XmlText NormalizeXmlTextWithoutNamespace(XmlText xt, XmlDocument targetDocument)
        {
            if (xt == null)
            {
                throw new ArgumentNullException("xt");
            }
            if (targetDocument == null)
            {
                throw new ArgumentNullException("targetDocument");
            }

            XmlText ret = targetDocument.CreateTextNode(xt.Value);

            return ret;
        }
    }
}
