$(document).ready(function () {
    $('[filteredSelection]').on("change", function () {
        var selectedRegion = $(this).val();
        var filteredSelection = $($(this).attr("filteredSelection"));
        $(filteredSelection).find("option").each(function (i, item) {
            if ($(item).val() === '' || $(item).val().match("^" + selectedRegion)) {
                $(item).show();
            } else {
                $(item).hide();
            }
        });
        $(filteredSelection).val("");
    });
});