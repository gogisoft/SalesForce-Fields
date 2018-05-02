using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace SalesForce.Fields
{
    public class DropDownDefinition : FieldControlDefinition, IDropDownDefinition
    {
        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownDefinition" /> class.
        /// </summary>
        public DropDownDefinition()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownDefinition" /> class.
        /// </summary>
        /// <param name="configDefinition">The config definition.</param>
        public DropDownDefinition(ConfigElement configDefinition)
            : base(configDefinition)
        {
        }
        #endregion

        #region IDropDownDefinition members
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