define([
    "dojo/_base/array",
    "dojo/_base/connect",
    "dojo/_base/declare",
    "dojo/_base/lang",

    "epi-cms/contentediting/editors/ContentAreaEditor",
    "epi-cms/contentediting/AllowedTypesList",
    "dojo/text!epi-cms/contentediting/editors/templates/ContentAreaEditor.html"
],
function (
    array,
    connect,
    declare,
    lang,

   ContentAreaEditor,
   AllowedTypesList,
   template
) {

    return declare("app.editors.ExtendedContentArea", [ContentAreaEditor], {
        baseClass: '',

        constructor: function () {
            var extendedTemplate = template.replace('dijitInline', 'dijitInline epi-content-area-editor');
            this.templateString = "<div class='dijitInline' tabindex='-1'>" + this.getAllowedTypesTemplate() + extendedTemplate + "</div>";
        },

        getAllowedTypesTemplate: function () {
            return "<div class='epi-content-area-header-block'>" +
                   "    <div data-dojo-type='epi-cms/contentediting/AllowedTypesList' " +
                   "         data-dojo-props='allowedTypes: this.allowedTypes, restrictedTypes: null'" +
                   "         data-dojo-attach-point='allowedTypesHeader'></div>" +
                   "</div>";
        }
    });
});