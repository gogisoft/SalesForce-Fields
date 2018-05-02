using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI;
using SalesForce.Fields.Common;

namespace SalesForce.Fields
{
    /// <summary>
    /// A simple field control used to save a string value.
    /// Use the path to this class when you add the field control
    /// </summary>
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(SalesForce.Fields.TextFieldDesigner))]
    public class TextBox :  SalesForceControl
    {

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox" /> class.
        /// </summary>
        public TextBox()
        {
            layoutTemplatePath = "~/SalesForce.Fields/Templates/TextBox.ascx";
            ScriptReference = typeof(TextBox).Namespace + ".TextBox.js";
        }
        #endregion

        #region Methods

        /// <summary>
        /// Gets the text box control.
        /// </summary>
        /// <value>The text box control.</value>
        protected virtual System.Web.UI.WebControls.TextBox TextBoxControl
        {
            get
            {
                return this.Container.GetControl<System.Web.UI.WebControls.TextBox>("fieldBox", true);
            }
        }

        [TypeConverter(typeof(ObjectStringConverter))]
        public override object Value
        {
            get
            {
                return this.TextBoxControl.Text;
            }
            set
            {
                this.TextBoxControl.Text = value as string;
            }
        }

        protected override void InitializeControls(GenericContainer container)
        {
            base.InitializeControls(container);
            //TODO: Additional attributes
            this.TextBoxControl.Text = this.Text;
            this.TitleLabel.Attributes.Add("data-id", this.UniqueIdentifier + this.TitleLabel.ClientID);
            this.DescriptionLabel.Attributes.Add("data-id", this.UniqueIdentifier + this.DescriptionLabel.ClientID);
            this.ExampleLabel.Attributes.Add("data-id", this.UniqueIdentifier + this.ExampleLabel.ClientID);
            this.SalesForceFieldLabel.Attributes.Add("data-id", this.UniqueIdentifier + this.SalesForceFieldLabel.ClientID);
            this.SalesForceFieldTypeLabel.Attributes.Add("data-id", this.UniqueIdentifier + this.SalesForceFieldTypeLabel.ClientID);
        }

        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            //TODO: Additional scripts
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            ScriptControlDescriptor descriptor = scriptDescriptors.Last() as ScriptControlDescriptor;
            if (this.TextBoxControl != null)
            {
                descriptor.AddElementProperty("textBoxElement", this.TextBoxControl.ClientID);
                descriptor.AddComponentProperty("textBoxElement", this.TextBoxControl.ClientID);
                descriptor.AddProperty("dataFieldName", this.MetaField.FieldName);
            }
            return scriptDescriptors.ToArray();
        }

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(ScriptReference, typeof(TextBox).Assembly.FullName));
            return scripts;
        }
        #endregion


    }
}