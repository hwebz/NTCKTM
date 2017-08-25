﻿define([
    "dojo/_base/connect",
    "dojo/_base/declare",
    "dijit/_CssStateMixin",
    "dijit/_Widget",
    "dijit/_TemplatedMixin",
    "dijit/_WidgetsInTemplateMixin",
    "dojox/widget/ColorPicker",
    "epi/shell/widget/_ValueRequiredMixin"
], function(
    connect,
    declare,
    _CssStateMixin,
    _Widget,
    _TemplatedMixin,
    _WidgetsInTemplateMixin,
    ColorPicker,
    _ValueRequiredMixin) {
    return declare("app.editors.ColorPicker", [_Widget, _TemplatedMixin, _WidgetsInTemplateMixin, _CssStateMixin, _ValueRequiredMixin],
        {
            templateString: "<div class=\"dijitInline\"><div class=\"colorPickerContainer\">" +
                "<div data-dojo-attach-point=\"stateNode, tooltipNode\">" +
                "<div data-dojo-attach-point=\"colorPicker\" data-dojo-type=\"dojox.widget.ColorPicker\" >" +
                "</div></div></div></div>",
            intermediateChanges: false,
            value: null,
            onChange: function(value) {
                // summary:
                // Called when the value in the widget changes.
                // tags:
                // public callback
            },
            postCreate: function() {
                // summary:
                // Set the value to the control after the DOM fragment is created.
                // tags:
                // protected
                if (this.value != null) {
                    this.set("value", this.value);
                } else {
                    this._set("value", "#ffffff");
                    this.onChange(this.value);
                }
                // call base implementation
                this.inherited(arguments);
                // Init widget and bind event
                this.colorPicker.set("intermediateChanges", this.intermediateChanges);
                this.connect(this.colorPicker, "onChange", this._onColorPickerChanged);
            },
            _onIntermediateChange: function(event) {
                // summary:
                // Handles the color picker key press events event and populates this to the onChange method.
                // tags:
                // private
                if (this.intermediateChanges) {
                    this._set("value", event.target.value);
                    this.onChange(this.value);
                }
            },
            focus: function() {
                // summary:
                // Put focus on this widget.
                // tags:
                // public
                dijit.focus(this.colorPicker);
            },
            isValid: function() {
                // summary:
                // Check if widget's value is valid.
                // tags:
                // protected, override
                return !this.required || this.colorPicker.value.length > 0;
            },
            _setValueAttr: function(value) {
                // summary:
                // Sets the value of the widget to "value" and updates the value displayed in the textbox.
                // tags:
                // private
                if (value != null) {
                    this._set("value", value);
                    this.colorPicker.set("value", value);
                }
            },
            _setReadOnlyAttr: function(value) {
                this._set("readOnly", value);
                this.colorPicker.set("readOnly", value);
            },
            // Setter for intermediateChanges
            _setIntermediateChangesAttr: function(value) {
                this.colorPicker.set("intermediateChanges", value);
                this._set("intermediateChanges", value);
            },
            // Event handler for widget
            _onColorPickerChanged: function(value) {
                // summary:
                // Handles the textbox change event and populates this to the onChange method.
                // tags:
                // private
                this._set("value", value);
                this.onChange(this.value);
            },
        }
    );
});