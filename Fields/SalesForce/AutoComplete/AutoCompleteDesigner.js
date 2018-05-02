Type.registerNamespace("SalesForce.Fields");

SalesForce.Fields.AutoCompleteDesigner = function (element) {
    /* Initialize Title fields */
    this._title = null;
    
    /* Initialize Description fields */
    this._description = null;
    
    /* Initialize Example fields */
    this._example = null;
    
    /* Initialize SalesForceField fields */
    this._salesForceField = null;

    /* Initialize SalesForceFieldType fields */
    this._salesForceFieldType = null;

    this._autoCompleteSource = null;
    
    /* Initialize Note fields */
    this._note = null;
    
    /* Initialize the meta field name TextBox used in form widget designers */
    this._metaFieldNameTextBox = null;

    /* Calls the base constructor */
    SalesForce.Fields.AutoCompleteDesigner.initializeBase(this, [element]);
}

SalesForce.Fields.AutoCompleteDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        SalesForce.Fields.AutoCompleteDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        SalesForce.Fields.AutoCompleteDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {

        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Title */
        jQuery(this.get_title()).val(controlData.Title);

        /* RefreshUI Description */
        jQuery(this.get_description()).val(controlData.Description);

        /* RefreshUI Note */
        jQuery(this.get_note()).val(controlData.Note);

        /* RefreshUI Example */
        jQuery(this.get_example()).val(controlData.Example);

        /* ApplyChanges AutoCompleteSource */
        jQuery(this.get_autoCompleteSource()).empty();
        jQuery(this.get_autoCompleteSource()).append('<option value="Account">Account Names</option>');
        jQuery(this.get_autoCompleteSource()).append('<option value="CountryCodes">Country Codes</option>');
        jQuery(this.get_autoCompleteSource()).append('<option value="State">States</option>');
        jQuery(this.get_autoCompleteSource()).val(controlData.AutoCompleteSource);

        /* RefreshUI SalesForceFieldType */
        jQuery(this.get_salesForceFieldType()).empty();
        jQuery(this.get_salesForceFieldType()).append('<option value="Contact" selected>Contact</option>');
        jQuery(this.get_salesForceFieldType()).append('<option value="Account">Account</option>');
        jQuery(this.get_salesForceFieldType()).val(controlData.SalesForceFieldType);

        this._loadFields(controlData);

        /* RefreshUI SalesForceField */
        jQuery(this.get_salesForceField()).val(controlData.SalesForceField);

        var that = this;
        jQuery(this.get_salesForceFieldType()).change(function () {
            controlData.SalesForceFieldType = jQuery(that.get_salesForceFieldType()).val();
            that._loadFields(controlData);
        });
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Title */
        controlData.Title = jQuery(this.get_title()).val();

        /* ApplyChanges Description */
        controlData.Description = jQuery(this.get_description()).val();

        /* ApplyChanges Example */
        controlData.Example = jQuery(this.get_example()).val();

        /* ApplyChanges SalesForceField */
        controlData.SalesForceField = jQuery(this.get_salesForceField()).val();

        /* ApplyChanges SalesForceFieldType */
        controlData.SalesForceFieldType = jQuery(this.get_salesForceFieldType()).val();

        /* ApplyChanges AutoComplete Source */
        controlData.Note = jQuery(this.get_note()).val();

        /* ApplyChanges AutoCompleteSource */
        controlData.AutoCompleteSource = jQuery(this.get_autoCompleteSource()).val();

        controlData.MetaField.FieldName = this.get_metaFieldNameTextBox().get_value();

    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _loadFields: function (controlData) {
        var fields;
        if (controlData.SalesForceFieldType != null &&
             controlData.SalesForceFieldType.toLowerCase() == "account") {
            fields = JSON.parse(controlData.DropDownListAccounts);
        }
        if (controlData.SalesForceFieldType != null &&
            controlData.SalesForceFieldType.toLowerCase() == "contact") {
            fields = JSON.parse(controlData.DropDownListContacts);
        }

        if (fields == "undefined" || fields == null) return;
        jQuery(this.get_salesForceField()).empty();
        var optionElement;
        for (var i = 0; i < fields.length; i++) {
            if (fields[i].name.toLowerCase() == "firstname" ||
                fields[i].name.toLowerCase() == "lastname" ||
                fields[i].name.toLowerCase() == "accountid" ||
                fields[i].name.toLowerCase() == "type__c" ||
                fields[i].name.toLowerCase() == "name" || 
                fields[i].name.toLowerCase() == "physical_country__c") {
                optionElement = jQuery('<option value="' + fields[i].name + '" style="color:red;font-weight: bold;">' + fields[i].name + '</option>');
            } else {
                optionElement = jQuery('<option value="' + fields[i].name + '">' + fields[i].name + '</option>');
            }
            if (fields[i].picklistValues != null && fields[i].picklistValues.length > 0) {
                optionElement.html(optionElement.html() + "<span style='margin-left:10px;color:#e1e1e1;font-weight:bold;'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;( Drop Down )</span>");
            }

            jQuery(this.get_salesForceField()).append(optionElement);
        }
    },
    /* --------------------------------- properties -------------------------------------- */

    /* Title properties */
    get_title: function () { return this._title; }, 
    set_title: function (value) { this._title = value; },

    /* Description properties */
    get_description: function () { return this._description; }, 
    set_description: function (value) { this._description = value; },

    /* Example properties */
    get_example: function () { return this._example; }, 
    set_example: function (value) { this._example = value; },

    /* SalesForceField properties */
    get_salesForceField: function () { return this._salesForceField; }, 
    set_salesForceField: function (value) { this._salesForceField = value; },

    /* SalesForceFieldType properties */
    get_salesForceFieldType: function () { return this._salesForceFieldType; },
    set_salesForceFieldType: function (value) { this._salesForceFieldType = value; },

    /* AutoCompleteSource properties */
    get_autoCompleteSource: function () { return this._autoCompleteSource; },
    set_autoCompleteSource: function (value) { this._autoCompleteSource = value; },

    /* Note properties */
    get_note: function () { return this._note; }, 
    set_note: function (value) { this._note = value; },

    /* metaFieldNameTextBox properties */
    get_metaFieldNameTextBox: function () { return this._metaFieldNameTextBox; },
    set_metaFieldNameTextBox: function (value) { this._metaFieldNameTextBox = value; }
}

SalesForce.Fields.AutoCompleteDesigner.registerClass('SalesForce.Fields.AutoCompleteDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
