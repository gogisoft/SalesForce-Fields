﻿using System;
using System.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields.Config;

namespace SalesForce.Fields
{
    public class DropDownDefinitionElement : FieldControlDefinitionElement, IDropDownDefinition
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownDefinitionElement" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public DropDownDefinitionElement(ConfigElement parent)
            : base(parent)
        {
        }
        #endregion

        #region FieldControlDefinitionElement members
        public override DefinitionBase GetDefinition()
        {
            return new DropDownDefinition(this);
        }
        #endregion

        #region IFieldDefinition members
        public override Type DefaultFieldType
        {
            get
            {
                return typeof(DropDown);
            }
        }
        #endregion

        #region IDropDownDefinition
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
