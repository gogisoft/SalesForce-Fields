using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace SalesForce.Fields
{
    public class AutoCompleteTextBoxDefinition : FieldControlDefinition, IAutoCompleteTextBoxDefinition
    {
        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteTextBoxDefinition" /> class.
        /// </summary>
        public AutoCompleteTextBoxDefinition()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteTextBoxDefinition" /> class.
        /// </summary>
        /// <param name="configDefinition">The config definition.</param>
        public AutoCompleteTextBoxDefinition(ConfigElement configDefinition)
            : base(configDefinition)
        {
        }
        #endregion

        #region IAutoCompleteTextBoxDefinition members
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        public string SampleText
        {
            get
            {
                return this.ResolveProperty("SampleText", this.sampleText);
            }
            set
            {
                this.sampleText = value;
            }
        }
        #endregion

        #region Private members
        private string sampleText;
        #endregion
    }
}