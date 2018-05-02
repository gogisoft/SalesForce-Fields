using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI.Fields.Definitions;

namespace SalesForce.Fields
{
    public class FieldDefinition : FieldControlDefinition, IFieldDefinition
    {
        #region Constuctors
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldDefinition" /> class.
        /// </summary>
        public FieldDefinition()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldDefinition" /> class.
        /// </summary>
        /// <param name="configDefinition">The config definition.</param>
        public FieldDefinition(ConfigElement configDefinition)
            : base(configDefinition)
        {
        }
        #endregion

        #region IFieldDefinition members
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