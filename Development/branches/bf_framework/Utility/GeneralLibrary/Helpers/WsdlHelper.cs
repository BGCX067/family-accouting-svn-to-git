using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Description;
using System.Xml;

namespace Wang.Velika.Utility.GeneralLibrary
{
    public static class WsdlHelper
    {
        public static Message CreateSinglePartMessage(string messageName, string partName, XmlQualifiedName xqn)
        {
            if (messageName == null)
            {
                throw new ArgumentNullException("messageName");
            }

            Message ret = new Message();
            ret.Name = messageName;
            ret.Parts.Add(CreateMessagePart(partName, xqn));

            return ret;
        }

        public static MessagePart CreateMessagePart(string partName, string elementName, string elementNamespace)
        {
            if (elementName == null)
            {
                throw new ArgumentNullException("elementName");
            }

            return CreateMessagePart(partName, new XmlQualifiedName(elementName, elementNamespace));
        }

        public static MessagePart CreateMessagePart(string partName, XmlQualifiedName xqn)
        {
            if (partName == null)
            {
                throw new ArgumentNullException("partName");
            }
            if (xqn == null)
            {
                throw new ArgumentNullException("xqn");
            }

            MessagePart ret = new MessagePart();
            ret.Name = partName;
            ret.Element = xqn;

            return ret;
        }

        public static void AddHeaderToAllOperationsInService(ServiceDescription svc, Message msg, string partName, bool needInput, bool requiredInput, bool needOutput, bool requiredOutput)
        {
            if (svc == null)
            {
                throw new ArgumentNullException("svc");
            }

            foreach (Binding bind in svc.Bindings)
            {
                AddHeaderToAllOperationsInBinding(bind, msg, partName, needInput, requiredInput, needOutput, requiredOutput);
            }
        }

        public static void AddHeaderToAllOperationsInBinding(Binding bind, Message msg, string partName, bool needInput, bool requiredInput, bool needOutput, bool requiredOutput)
        {
            if (bind == null)
            {
                throw new ArgumentNullException("bind");
            }

            foreach (OperationBinding operation in bind.Operations)
            {
                AddHeaderToOperation(operation, msg, partName, needInput, requiredInput, needOutput, requiredOutput);
            }
        }

        public static void AddHeaderToOperation(OperationBinding operation, Message msg, string partName, bool needInput, bool requiredInput, bool needOutput, bool requiredOutput)
        {
            if (operation == null)
            {
                throw new ArgumentNullException("operation");
            }

            if (needInput)
            {
                operation.Input.Extensions.Add(CreateHeaderBinding(msg, partName, requiredInput));
            }
            if (needOutput)
            {
                operation.Output.Extensions.Add(CreateHeaderBinding(msg, partName, requiredOutput));
            }
        }

        public static SoapHeaderBinding CreateHeaderBinding(Message msg, string partName, bool required)
        {
            if (msg == null)
            {
                throw new ArgumentNullException("msg");
            }

            SoapHeaderBinding ret = new SoapHeaderBinding();
            if ((partName == null) && (msg.Parts.Count > 0))
            {
                partName = msg.Parts[0].Name;
            }
            ret.Part = partName;
            ret.Message = new XmlQualifiedName(msg.Name, (msg.ServiceDescription == null ? String.Empty : msg.ServiceDescription.TargetNamespace));
            ret.Use = SoapBindingUse.Literal;
            ret.Required = required;

            return ret;
        }
    }
}
