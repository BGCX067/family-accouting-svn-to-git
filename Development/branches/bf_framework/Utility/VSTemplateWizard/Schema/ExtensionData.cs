﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.1432.
// 
namespace Wang.Velika.Utility.VSTemplateWizard {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://velika.vicp.net/Utility/VSTemplateWizard/ExtensionDataSchema")]
    [System.Xml.Serialization.XmlRootAttribute("projectExtension", Namespace="http://velika.vicp.net/Utility/VSTemplateWizard/ExtensionDataSchema", IsNullable=false)]
    public partial class ProjectExtension {
        
        private FileSearchItem[] fileSearchItemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable=false)]
        public FileSearchItem[] fileSearchItems {
            get {
                return this.fileSearchItemsField;
            }
            set {
                this.fileSearchItemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://velika.vicp.net/Utility/VSTemplateWizard/ExtensionDataSchema")]
    public partial class FileSearchItem {
        
        private ItemProperty[] propertiesField;
        
        private string searchSuffixField;
        
        private string nameParameterField;
        
        private string pathParameterField;
        
        private string folderPathField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
        public ItemProperty[] properties {
            get {
                return this.propertiesField;
            }
            set {
                this.propertiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string searchSuffix {
            get {
                return this.searchSuffixField;
            }
            set {
                this.searchSuffixField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nameParameter {
            get {
                return this.nameParameterField;
            }
            set {
                this.nameParameterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pathParameter {
            get {
                return this.pathParameterField;
            }
            set {
                this.pathParameterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string folderPath {
            get {
                return this.folderPathField;
            }
            set {
                this.folderPathField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://velika.vicp.net/Utility/VSTemplateWizard/ExtensionDataSchema")]
    public partial class ItemProperty {
        
        private string nameField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
}
