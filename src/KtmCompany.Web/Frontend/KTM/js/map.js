/**
 * Created by ha.do on 2/4/2016.
 */
function initialize() {
    var mapProp = {
        center:new google.maps.LatLng(23.2901481,14.0983226),
        zoom:2,
        mapTypeId:google.maps.MapTypeId.ROADMAP
    };
    var map=new google.maps.Map(document.getElementById("googleMap"), mapProp);
}
google.maps.event.addDomListener(window, 'load', initialize);

function calculateMapHeight() {
    var section_map_info_height = $(".section-info-map").height();
    section_map_info_height += 40;
    $("#googleMap").css("height", section_map_info_height + "px");
}

$(window).on("resize", function() {
    calculateMapHeight();
});

google.maps.event.addDomListener(window, 'load', calculateMapHeight);