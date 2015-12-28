using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Wang.Velika.Utility.GeneralLibrary;

namespace Wang.Velika.Utility.WCFExtension
{
    public class WsdlHeaderOptionElement : ExtendedConfigurationElement
    {
        [ConfigurationProperty("exportInput")]
        public WsdlHeaderBindingElement ExportInput
        {
            get
            {
                return (WsdlHeaderBindingElement)this["exportInput"];
            }
            set
            {
                this["exportInput"] = value;
            }
        }

        [ConfigurationProperty("exportOutput")]
        public WsdlHeaderBindingElement ExportOutput
        {
            get
            {
                return (WsdlHeaderBindingElement)this["exportOutput"];
            }
            set
            {
                this["exportOutput"] = value;
            }
        }

        public bool ExportInputEnabled
        {
            get
            {
                return ((this.ExportInput != null) && this.ExportInput.Enabled);
            }
        }

        public bool ExportInputRequired
        {
            get
            {
                return (this.ExportInputEnabled && this.ExportInput.IsRequired);
            }
        }

        public bool ExportOutputEnabled
        {
            get
            {
                return ((this.ExportOutput != null) && this.ExportOutput.Enabled);
            }
        }

        public bool ExportOutputRequired
        {
            get
            {
                return (this.ExportOutputEnabled && this.ExportOutput.IsRequired);
            }
        }
    }
}
