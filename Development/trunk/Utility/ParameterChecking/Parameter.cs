using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Wang.Velika.Utility.ParameterChecking.Validators;

namespace Wang.Velika.Utility.ParameterChecking
{
    public class Parameter
    {
        #region Fields & Properties

        private string _defaultValue;
        public string DefaultValue
        {
            get
            {
                return this._defaultValue;
            }
        }

        private bool _enabled;
        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        private string _helpMessage;
        public string HelpMessage
        {
            get
            {
                return this._helpMessage;
            }
        }

        private bool _isFlag;
        public bool IsFlag
        {
            get
            {
                return this._isFlag;
            }
        }

        private bool _isRequired;
        public bool IsRequired
        {
            get
            {
                return this._isRequired;
            }
            set
            {
                this._isRequired = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return this._name;
            }
        }

        private string _shortName;
        public string ShortName
        {
            get
            {
                return this._shortName;
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return this._value;
            }
            internal set
            {
                this._value = value;
            }
        }

        private List<IParameterValidator> _validators;
        public List<IParameterValidator> Validators
        {
            get
            {
                if (this._validators == null)
                {
                    this._validators = new List<IParameterValidator>();
                }
                return this._validators;
            }
        }

        private string _errorInfo;
        public virtual string ErrorInfo
        {
            get
            {
                return this._errorInfo;
            }
        }

        private bool _isValidated;
        public bool IsValidated
        {
            get
            {
                return this._isValidated;
            }
        }

        #endregion Fields & Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">Name of the <see cref="Parameter"/>.</param>
        /// <param name="shortName">Short name of the <see cref="Parameter"/>.</param>
        public Parameter(string name, string shortName)
        {
            this._name = name;
            this._shortName = shortName;
            this._isFlag = true;
            this._enabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">Name of the <see cref="Parameter"/>.</param>
        /// <param name="shortName">Short name of the <see cref="Parameter"/>.</param>
        /// <param name="isRequired">if set to <c>true</c> [b is required].</param>
        /// <param name="defaultValue">The STR default value.</param>
        /// <param name="validators">The validators.</param>
        public Parameter(string name, string shortName, bool isRequired, string defaultValue, List<IParameterValidator> validators)
            : this(name, shortName, isRequired, defaultValue, validators, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">Name of the <see cref="Parameter"/>.</param>
        /// <param name="shortName">Short name of the <see cref="Parameter"/>.</param>
        /// <param name="isRequired">if set to <c>true</c> [b is required].</param>
        /// <param name="defaultValue">The STR default value.</param>
        /// <param name="validator">The validator.</param>
        public Parameter(string name, string shortName, bool isRequired, string defaultValue, IParameterValidator validator)
            : this(name, shortName, isRequired, defaultValue, validator, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">Name of the <see cref="Parameter"/>.</param>
        /// <param name="shortName">Short name of the <see cref="Parameter"/>.</param>
        /// <param name="isRequired">if set to <c>true</c> [b is required].</param>
        /// <param name="defaultValue">The STR default value.</param>
        /// <param name="validator">The validator.</param>
        /// <param name="strHelpMessage">The <see cref="Parameter"/> help message.</param>
        public Parameter(string name, string shortName, bool isRequired, string defaultValue, IParameterValidator validator, string helpMessage)
            : this(name, shortName, isRequired, defaultValue, validator == null ? null : new List<IParameterValidator>(new IParameterValidator[] { validator }), helpMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">Name of the <see cref="Parameter"/>.</param>
        /// <param name="shortName">Short name of the <see cref="Parameter"/>.</param>
        /// <param name="isRequired">if set to <c>true</c> [b is required].</param>
        /// <param name="defaultValue">The STR default value.</param>
        /// <param name="validators">The validators.</param>
        /// <param name="strHelpMessage">The <see cref="Parameter"/> help message.</param>
        public Parameter(string name, string shortName, bool isRequired, string defaultValue, List<IParameterValidator> validators, string helpMessage)
        {
            this._name = name;
            this._shortName = shortName;
            this._isRequired = isRequired;
            this._defaultValue = defaultValue;
            this._validators = validators;
            this._helpMessage = helpMessage;
            this._enabled = true;
        }

        #endregion Constructors

        /// <summary>
        /// Inits the value from.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        public void InitValueFrom(StringDictionary keyValues)
        {
            if (keyValues != null)
            {
                if (keyValues.ContainsKey(this.Name))
                {
                    this._value = keyValues[this.Name];
                }
                else if (keyValues.ContainsKey(this.ShortName))
                {
                    this._value = keyValues[this.ShortName];
                }
                else
                {
                    this._value = this.DefaultValue;
                }
            }
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            bool validated = true;
            if (this.IsFlag)
            {
                this.Validators.Insert(0, new FlagValidator());
            }
            if (this.IsRequired)
            {
                this.Validators.Insert(0, new RequiredValidator());
            }

            if (this.Validators.Count > 0)
            {
                foreach (IParameterValidator validator in this.Validators)
                {
                    string errorMessage;
                    if (!validator.Validate(this, null, out errorMessage))
                    {
                        this._errorInfo = errorMessage;
                        validated = false;
                        break;
                    }
                }
            }

            this._isValidated = validated;
            return validated;
        }

    }
 
}
