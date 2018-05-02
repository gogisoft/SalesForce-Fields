using System;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields.Config;

namespace SalesForce.Fields
{
    public class AutoCompleteTextBoxDefinitionElement : FieldControlDefinitionElement, IAutoCompleteTextBoxDefinition
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteTextBoxDefinitionElement" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public AutoCompleteTextBoxDefinitionElement(ConfigElement parent)
            : base(parent)
        {
        }
        #endregion

        #region FieldControlDefinitionElement members
        public override DefinitionBase GetDefinition()
        {
            return new AutoCompleteTextBoxDefinition(this);
        }
        #endregion

        #region IFieldDefinition members
        public override Type DefaultFieldType
        {
            get
            {
                return typeof(AutoCompleteTextBox);
            }
        }
        #endregion

        #region IAutoCompleteTextBoxDefinition
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        [ConfigurationProperty("SampleText")]
        public string SampleText
        {
            get
            {
                return (string)this["SampleText"];
            }
            set
            {
                this["SampleText"] = value;
            }
        }
        #endregion
    }
}
