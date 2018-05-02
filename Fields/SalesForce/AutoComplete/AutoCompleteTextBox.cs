using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Utilities.TypeConverters;
using SalesForce.Fields.Common;
using SalesForceConnector;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace SalesForce.Fields
{
    /// <summary>
    /// A simple field control used to save a string value.
    /// Use the path to this class when you add the field control
    /// SalesForce.Fields.Fields.SalesForce.AutoComplete.AutoCompleteTextBox
    /// </summary>
    [Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesigner(typeof(SalesForce.Fields.AutoCompleteDesigner))]
    public class AutoCompleteTextBox :  SalesForceControl
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteTextBox" /> class.
        /// </summary>
        public AutoCompleteTextBox()
        {
            layoutTemplatePath = "~/SalesForce.Fields/Templates/AutoCompleteTextBox.ascx";
            ScriptReference = typeof(AutoCompleteTextBox).Namespace + ".AutoCompleteTextBox.js";
        }
        #endregion

        #region Properties

        protected WebControl AutoCompleteControl
        {
            get
            {
                return this.AutoCompleteLabel;
            } 
        }
        protected internal virtual Label AutoCompleteLabel
        {
            get
            {
                return this.Container.GetControl<Label>("autoCompleteLabel", true);
            }
        }

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
        public object ControlID
        {
            get { return TextBoxControl.ClientID; }
        }
        public string Text { get; set; }
        [TypeConverter(typeof(ObjectStringConverter))]
        public string AutoCompleteText
        {
            get
            {
                return AutoCompleteLabel.Text;
            }
            set
            {
                AutoCompleteLabel.Text = value;
            }
        }
        public string ItemsCollection { get; set; }
        public string AutoCompleteSource { get; set; }
        #endregion

        #region Methods
        protected override void InitializeControls(GenericContainer container)
        {
            String autoCompleteJS = string.Empty;
            base.InitializeControls(container);
            Regex rgx = new Regex(@"[^a-zA-Z0-9\s()-]");
            this.TextBoxControl.Attributes.Add("data-id", this.UniqueIdentifier + this.TextBoxControl.ClientID);
            Connector sfConnector = new Connector();
            if (String.IsNullOrEmpty(AutoCompleteSource) == false &&
                AutoCompleteSource.ToLower() == "account")
            {
                // Using an Ajax call to get the data so it doesn't show up in the page source.
                autoCompleteJS = GetAutoCompletJS(this.UniqueIdentifier, this.TextBoxControl.ClientID,"autocomplete_a");
            }
            if (String.IsNullOrEmpty(AutoCompleteSource) == false &&
                AutoCompleteSource.ToLower() == "state")
            {
                autoCompleteJS = GetAutoCompletJS(this.UniqueIdentifier, this.TextBoxControl.ClientID,"autocomplete_s"); 
            }
            if (String.IsNullOrEmpty(AutoCompleteSource) == false &&
                    AutoCompleteSource.ToLower() == "countrycodes")
            {
                ItemsCollection = "[";
                foreach (var r in new List<object>())
                {
                    //TODO: create REST method to get country codes
                    ItemsCollection += "\"" + rgx.Replace("r.Name", "").ToUpper() + "\",";
                }
                ItemsCollection = ItemsCollection.Remove(ItemsCollection.Length - 1);
                ItemsCollection += "]";

                autoCompleteJS = "<script type=\"text/javascript\"> " +
                    "$(\"[data-id*='" + this.UniqueIdentifier + this.TextBoxControl.ClientID + "']\")" +
                        ".autocomplete({ " +
                        "source: function(request, response) { " +
                        "var results = $.ui.autocomplete.filter(" + ItemsCollection + ", request.term); " +
                        "response(results.slice(0, 1)); }" +
                     "}); " +
               "</script>";
            }
            AutoCompleteText = autoCompleteJS; 
        }
        private String GetAutoCompletJS(String uniqueID, String clientID, String source)
        {
            String result = "<script type=\"text/javascript\"> " +
                    "$.ajax({" +
                        "url: '/sitefinity/public/services/formsservice.svc/" + source  + "'," +
                        "data: {" +
                            "format: 'json'" +
                           "}," +
                        "error: function() {}," +
                        "success: function(source) {" +
                            "var data = JSON.parse(source);" +
                            "$(\"[data-id*='" + uniqueID + clientID + "']\")" +
                             ".autocomplete({ " +
                                "source: function(request, response) { " +
                                    "var matcher = new RegExp( \"^\" + $.ui.autocomplete.escapeRegex( request.term ), \"i\" );" +
                                    "response( $.grep( data, function( item ){ " +
                                        "return matcher.test( item ); " +
                                            "}) ); " +
                //"var results = $.ui.autocomplete.filter(data, request.term); " +
                //"response(results.slice(0, 1)); " +
                                    "}" +
                                "}); " +
                          " }," +
                          "minLength: 1, " +
                      "type: 'GET'" +
                    "});" +
                "</script>";

            return result;
        }
        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
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

            scripts.Add(new ScriptReference(ScriptReference, typeof(AutoCompleteTextBox).Assembly.FullName));

            return scripts;
        }

        #endregion
    }
}