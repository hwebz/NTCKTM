define([
    "dojo/_base/declare",
    "dojo/_base/lang",

    "epi/shell/layout/SimpleContainer"
],
function (
    declare,
    lang,

    SimpleContainer
) {

    return declare([SimpleContainer], {
        countryDropdown: null,
        regionDropdown: null,

        addChild: function (child) {
            // Summar: Add a widget to the container

            this.inherited(arguments);

            if (child.name.indexOf("region") >= 0) {
                // If it's the country drop down list
                this.regionDropdown = child;

                // Connect to change event to update the region drop down list
                this.own(this.regionDropdown.on("change", lang.hitch(this, this._updateCountryDropdown)));
            } else if (child.name.indexOf("country") >= 0) {
                // If it's the region drop down list
                this.countryDropdown = child;

                // Update the region drop down
                this._updateCountryDropdown("", true);
            }
        },

        _updateCountryDropdown: function (region, firstLoad) {
            this.regionDropdown.set("value", region);
            if (this.countryDropdown != null) {
                // Summary: Update the filtered category drop down list according to the selected value                
                var selectedValue = this.countryDropdown.value;
                
                if (!region || region.length === 0) {
                    if (!firstLoad) {                        
                        this.countryDropdown.set("value", null);
                        // Set the filter
                        this.countryDropdown.set("filter", function (country) {
                            // Oops, the region code is prefixed with country code, for the simplicity
                            return false;
                        });
                    }                    
                } else {

                    // Set the filter
                    this.countryDropdown.set("filter", function (country) {
                        // Oops, the region code is prefixed with country code, for the simplicity
                        return country.value.indexOf(region) === 0;
                    });

                    if (!firstLoad || selectedValue) {                        
                        this.countryDropdown.set("value", selectedValue);                        
                    }
                }
            }
        }
    });
});