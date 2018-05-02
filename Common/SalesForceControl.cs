using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Data.Metadata;
using Telerik.Sitefinity.Metadata.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Fields;
using Telerik.Sitefinity.Modules.Forms.Web.UI.Fields;
using Common;
using SalesForceConnector;

namespace SalesForce.Fields.Common
{
    [DatabaseMapping(UserFriendlyDataType.ShortText), Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(SalesForce.Fields.AutoCompleteDesigner))]
    public class SalesForceControl: FieldControl, IFormFieldControl
    {

       protected string layoutTemplatePath;
       protected string ScriptReference;

        public SalesForceControl()
        {
            this.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
        }
        protected override WebControl TitleControl
        {
            get
            {
                return this.TitleLabel;
            }
        }

        protected override WebControl DescriptionControl
        {
            get
            {
                return this.DescriptionLabel;
            }
        }

        protected override WebControl ExampleControl
        {
            get
            {
                return this.ExampleLabel;
            }
        }
        protected WebControl SalesForceFieldControl
        {
            get
            {
                return this.SalesForceFieldLabel;
            }
        }
        protected WebControl SalesForceFieldTypeControl
        {
            get
            {
                return this.SalesForceFieldTypeLabel;
            }
        }
        protected WebControl ContactFieldsControl
        {
            get
            {
                return this.ContactFieldsLabel;
            }
        }
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    return layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }
        protected internal virtual Label ContactFieldsLabel
        {
            get
            {
                return this.Container.GetControl<Label>("contactfieldsLabel", true);
            }
        }
        protected internal virtual Label SalesForceFieldLabel
        {
            get
            {
                return this.Container.GetControl<Label>("salesforcefieldsLabel", true);
            }
        }
        protected internal virtual Label SalesForceFieldTypeLabel
        {
            get
            {
                return this.Container.GetControl<Label>("salesforcefieldtypeLabel", true);
            }
        }
        /// <summary>
        /// Gets the reference to the label control that represents the title of the field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in write mode.
        /// </remarks>
        protected internal virtual Label TitleLabel
        {
            get
            {
                return this.Container.GetControl<Label>("titleLabel", true);
            }
        }

        /// <summary>
        /// Gets the reference to the label control that represents the description of the field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in write mode.
        /// </remarks>
        protected internal virtual Label DescriptionLabel
        {
            get
            {
                return Container.GetControl<Label>("descriptionLabel", true);
            }
        }

        /// <summary>
        /// Gets the reference to the label control that displays the example for this
        /// field control.
        /// </summary>
        /// <remarks>
        /// This control is mandatory only in the write mode.
        /// </remarks>
        protected internal virtual Label ExampleLabel
        {
            get
            {
                return this.Container.GetControl<Label>("exampleLabel", true);
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public object TitleID
        {
            get
            {
                return this.TitleLabel.ClientID as string;
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public object DescriptionID
        {
            get
            {
                return this.DescriptionLabel.ClientID as string;
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public object ExampleID
        {
            get
            {
                return this.ExampleLabel.ClientID as string;
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public object SalesForceFieldID
        {
            get
            {
                return this.SalesForceFieldLabel.ClientID as string;
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public object SalesForceFieldTypeID
        {
            get
            {
                return this.SalesForceFieldTypeLabel.ClientID as string;
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public object ContactFieldsID
        {
            get
            {
                return this.ContactFieldsLabel.ClientID as string;
            }
        }
        [TypeConverter(typeof(ObjectStringConverter))]
        public string UniqueIdentifier
        {
            get
            {
                return this.ClientID;
            }
        }
        protected string Text { get; set; }
        public string SalesForceField { get; set; }
        public string SalesForceFieldType { get; set; }
        public string Note { get; set; }
        //public string ContactFields
        //{
        //    get
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Field>));
        //        ser.WriteObject(ms, StaticObjects.ContactFields.OrderBy(p=> p.name));
        //        return Encoding.UTF8.GetString(ms.ToArray());
        //    }
        //}
        public string DropDownListContacts
        {
            get
            {
                Connector sfConnector = new Connector();
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Field>));
                ser.WriteObject(ms, sfConnector.GetContactFields().OrderBy(p => p.name));
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        public string DropDownListAccounts
        {
            get
            {
                Connector sfConnector = new Connector();
                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Field>));
                ser.WriteObject(ms, sfConnector.GetAccountFields().OrderBy(p => p.name));
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        protected override void InitializeControls(GenericContainer container)
        {
            this.TitleLabel.Text = this.Title;
            this.ExampleLabel.Text = this.Example;
            this.DescriptionLabel.Text = this.Description;

            this.SalesForceFieldLabel.Text = this.SalesForceField;
            this.SalesForceFieldTypeLabel.Text = this.SalesForceFieldType;
            this.ContactFieldsLabel.Text = this.DropDownListContacts;
        }

        //public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        //{
        //    //TODO: Additional scripts
        //    List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();
        //    ScriptControlDescriptor descriptor = base.GetScriptDescriptors().Last() as ScriptControlDescriptor;
        //    descriptor.AddProperty("dataFieldName", this.MetaField.FieldName);
        //    return descriptors.ToArray();
        //}
        private IMetaField metaField = null;
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IMetaField MetaField
        {
            get
            {
                if (this.metaField == null)
                {
                    this.metaField = this.LoadDefaultMetaField();
                    if (this.metaField == null)
                    {
                        throw new Exception("MetaField = null");
                    }
                }

                return this.metaField;
            }

            set
            {
                this.metaField = value;
            }
        }
    }
}
