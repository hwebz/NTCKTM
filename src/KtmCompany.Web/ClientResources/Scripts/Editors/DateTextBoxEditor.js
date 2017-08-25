define([
    "dojo/_base/array",
    "dojo/_base/connect",
    "dojo/_base/declare",
    "dojo/_base/lang",

    "dijit/_CssStateMixin",
    "dijit/_Widget",
    "dijit/_TemplatedMixin",
    "dijit/_WidgetsInTemplateMixin",

     "dijit/dijit", // loads the optimized dijit layer
    "dijit/Calendar",
    "dijit/form/DateTextBox",
    "dijit/form/ValidationTextBox",
    "dijit/form/Button",
    "epi/epi"

],
function (
    array,
    connect,
    declare,
    lang,
    _CssStateMixin,
    _Widget,
    _TemplatedMixin,
    _WidgetsInTemplateMixin,
    dijit,
    Calendar, DateTextBox, TextBox, Button,
    epi,
    appModule,
    template
) {

    return declare("app.editors.DateTextboxEditor", [_Widget, _TemplatedMixin, _WidgetsInTemplateMixin, _CssStateMixin], {

        templateString: "<div class=\"dijitInline\">" +
                            "<input type=\"text\" data-dojo-attach-point=\"dateInputWidgetTextbox\" data-dojo-type=\"dijit/form/DateTextBox\"" +
                            "data-dojo-props=\"regExp:'^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$',invalidMessage: 'Please enter a valid date [MM/dd/YYY].'\"/>" +
                            "<button  data-dojo-attach-point=\"dateInputWidgetbtn\" data-dojo-type=\"dijit/form/Button\" type=\"button\" data-dojo-props=\"showLabel: false\" style=\"display:none;\"></button>" +
                            "<div data-dojo-attach-point=\"dateInputWidgetCalendar\" data-dojo-type=\"dijit/Calendar\" data-dojo-props=\"\" class=\"nodisp\"></div>" +
                        "</div>",
        postCreate: function () {
            this.set('value', this.value);
            this.dateInputWidgetTextbox.set("value", this.value);

            this.dateInputWidgetbtn.set("iconClass", "calendarIcon");
            this.dateInputWidgetbtn.set("showLabel", "false");
            this.dateInputWidgetbtn.set("label", "");
            // Init textarea and bind event
            this.connect(this.dateInputWidgetbtn, "onClick", this._onbutton);
            this.connect(this.dateInputWidgetCalendar, "onValueSelected", this._onCalendar);
            this.connect(this.dateInputWidgetTextbox, "onKeyPress", this._onTextAreaPress);
            this.connect(this.dateInputWidgetTextbox, "onBlur", this._onChange);
        },


        _onIntermediateChange: function (event) {
            if (this.intermediateChanges) {
                this._set('value', event.target.value);
                this.onChange(this.value);
            }
        },

        // Setter for value property
        _setValueAttr: function (value) {

            this.dateInputWidgetTextbox.set("value", value);
            this.dateInputWidgetbtn.set("showLabel", "false");
            this.dateInputWidgetbtn.set("label", "");
            this._set('value', value);

        },

        // Setter for intermediateChanges
        _setIntermediateChangesAttr: function (value) {
            this.dateInputWidgetTextbox.set("intermediateChanges", value);
            this._set("intermediateChanges", value);
        },

        // Event handler for textarea
        _onbutton: function () {

            this.dateInputWidgetCalendar.set("style", "display:block!important");
        },

        _onCalendar: function (date) {
            var dd = (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear();
            this.dateInputWidgetTextbox.setValue(dd);
            this._updateValue(this.dateInputWidgetTextbox.value);
            this.dateInputWidgetCalendar.set("style", "display:none!important");
        },

        _onTextAreaPress: function () {
            this._set('value', this.dateInputWidgetTextbox.value);
            this._updateValue(this.dateInputWidgetTextbox.value);
            this.dateInputWidgetCalendar.set("style", "display:block!important");
        },
        _onChange: function () {
            var ISOString = new Date(this.dateInputWidgetTextbox.value).toISOString();
            var date = new Date(ISOString);
            var year = parseInt(ISOString);
            var month = date.getMonth();
            var _date = date.getDate();
            var UTC = new Date(Date.UTC(year, month, _date));

            //this._set('value', this.dateInputWidgetTextbox.value);
            this._set('value', UTC);
            //this._updateValue(this.dateInputWidgetTextbox.value);
            this._updateValue(UTC);


        },
        onChange: function (value) {

        },

        // updates the value and tells epi to save
        _updateValue: function (value) {
            if (epi.areEqual(this.value, value)) {
                return;
            }

            this._set("value", value);
            this.onChange(value);
        }
    });
});