Type.registerNamespace("SalesForce.Fields");

SalesForce.Fields.DropDown = function (element) {
    SalesForce.Fields.DropDown.initializeBase(this, [element]);
    this._element = element;
    this._labelElement = null;
    this._textBoxElement = null;
}

SalesForce.Fields.DropDown.prototype = {
    initialize: function () {
        /* Here you can attach to events or do other initialization */      
        SalesForce.Fields.DropDown.callBaseMethod(this, "initialize");
    },

    dispose: function () {
        /*  this is the place to unbind/dispose the event handlers created in the initialize method */   
        SalesForce.Fields.DropDown.callBaseMethod(this, "dispose");
    },

    /* --------------------------------- public methods ---------------------------------- */

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _getTextValue: function(){
        if (this._textBoxElement) {
            return this._textBoxElement.value;
        }
        return null;
    },

    _clearTextBox: function () {
        if (this._textBoxElement != null) {
            this._textBoxElement.value = "";
        }
    },    

    /* --------------------------------- properties -------------------------------------- */
    get_value: function () {    
        var val = this._getTextValue();
        return val;
    },

    set_value: function (value) {
        this._clearTextBox();
        if (value !== undefined && value != null && this._textBoxElement != null) {
            this._textBoxElement.value = value;
        }
        this._value = value;
    },
    
    get_textBoxElement: function () {
        return this._textBoxElement;
    },

    set_textBoxElement: function (value) {
        this._textBoxElement = value;
    }    
};

SalesForce.Fields.DropDown.registerClass("SalesForce.Fields.DropDown", Telerik.Sitefinity.Web.UI.Fields.FieldControl);
