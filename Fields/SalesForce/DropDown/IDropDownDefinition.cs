using System;
using System.Linq;
using Telerik.Sitefinity.Web.UI.Fields.Contracts;

namespace SalesForce.Fields
{
    public interface IDropDownDefinition : IFieldControlDefinition
    {
        /// <summary>
        /// Gets or sets the sample text.
        /// </summary>
        /// <value>The sample text.</value>
        string SampleText { get; set; }
    }
}
