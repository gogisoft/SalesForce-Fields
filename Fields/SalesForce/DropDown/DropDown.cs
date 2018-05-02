using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.Web.UI;
using SalesForce.Fields.Common;
using Common;
using SalesForceConnector;

namespace SalesForce.Fields
{
    /// <summary>
    /// A simple field control used to save a string value.
    /// Use the path to this class when you add the field control
    /// </summary>

    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(SalesForce.Fields.DropDownDesigner))]
    public class DropDown : SalesForceControl
    {
   
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDown" /> class.
        /// </summary>
        public DropDown()
        {
            layoutTemplatePath = "~/SalesForce.Fields/Templates/DropDown.ascx";
            ScriptReference = typeof(DropDown).Namespace + ".DropDown.js";
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the text box control.
        /// </summary>
        /// <value>The text box control.</value>
        protected virtual DropDownList DropDownControl
        {
            get
            {
                return this.Container.GetControl<DropDownList>("fieldDropDown", true);
            }
        }
        public string DropDownKey { get; set; }
        [TypeConverter(typeof(ObjectStringConverter))]
        public override object Value
        {
            get
            {
                return this.DropDownControl.SelectedValue;
            }
            set
            {
                this.DropDownControl.SelectedValue = value as string;
            }
        }

        #endregion

        #region Methods
        protected override void InitializeControls(GenericContainer container)
        {
            base.InitializeControls(container);
            this.DropDownControl.SelectedValue = this.Text;
            Connector sfConnector = new Connector();

            if (String.IsNullOrEmpty(SalesForceFieldType) == false && SalesForceFieldType.ToLower() == "contact")
            {
                Field f = sfConnector.GetContactFields().Where(p => p.name.ToLower() == SalesForceField.ToLower()).FirstOrDefault();
                if (f != null)
                {
                    List<PickListValues> picklist = f.picklistValues.ToList();
                    if (f.name.ToLower().Contains("type__c"))
                    {
                        //Lewis wants Support to be the default role for contact creation.
                        PickListValues supportField = picklist.Where(p => p.label.ToLower().Contains("support")).FirstOrDefault();
                        if (supportField != null)
                        {
                            picklist.Remove(supportField);
                            picklist.Insert(0, supportField);
                        }
                    }
                    if (picklist != null)
                    {
                        this.DropDownControl.DataTextField = "label";
                        this.DropDownControl.DataValueField = "value";
                        this.DropDownControl.DataSource = picklist;
                        this.DropDownControl.DataBind();
                    }
                }
            }
            if (String.IsNullOrEmpty(SalesForceFieldType) == false && SalesForceFieldType.ToLower() == "account")
            {
                Field f = sfConnector.GetAccountFields().Where(p => p.name.ToLower() == SalesForceField.ToLower()).FirstOrDefault();
                if (f != null)
                {
                    PickListValues[] picklist = f.picklistValues;
                    if (picklist != null)
                    {
                        this.DropDownControl.DataTextField = "label";
                        this.DropDownControl.DataValueField = "value";
                        this.DropDownControl.DataSource = picklist;
                        this.DropDownControl.DataBind();
                    }
                }
            }
        }

        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            base.GetScriptDescriptors();
            //TODO: Additional scripts
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();
            ScriptControlDescriptor descriptor = base.GetScriptDescriptors().Last() as ScriptControlDescriptor;
            if (this.DropDownControl != null)
            {
                descriptor.AddElementProperty("textBoxElement", this.DropDownControl.ClientID);
                descriptor.AddProperty("dataFieldName", this.MetaField.FieldName);
                descriptor.AddComponentProperty("textBoxElement", this.DropDownControl.ClientID);
            }
            descriptors.Add(descriptor);
            return descriptors.ToArray();
        }

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(ScriptReference, typeof(DropDown).Assembly.FullName));
            return scripts;
        }


        #endregion

    }
}