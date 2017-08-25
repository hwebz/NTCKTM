$(document).ready(function () {
    $('[filteredSelection]').on("change", function () {        
        var selectedRegion = $(this).val();
        var filteredSelection = $($(this).attr("filteredSelection"));
        if (filteredSelection) {            
            if (countries && countries.length > 0) {
                $(filteredSelection).empty();
                $(countries).each(function (index, item) {
                    if (item.Value === '' || item.Value.match("^" + selectedRegion)) {
                        filteredSelection.append(
                            $('<option>', {
                                value: item.Value,
                                text: item.Text
                            }, '</option>'));
                    }
                });
                $(filteredSelection).val("");
            }
        }               
    });
});