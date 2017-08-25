$(function() {    
    var leftColumn = $("#data-block"); //put id of left column here
    var parentEle = $("#row-intro-news"); //put parent element id of 'leftColumn above'

    var blockTopOffset = null;    
    if (leftColumn != undefined) {
        blockTopOffset = leftColumn.offset().top;        
    }    
    var _leftColumnPosition = null;
    $(window).scroll(function(event) {
        //update top        
        _leftColumnPosition = $("#data-block").height() + parseInt($("#data-block").css("top").replace("px", "")) + parseInt($("#data-block").css("margin-top").replace("px", ""));
        //get window scroll top        
        var windowScrollTop = $(window).scrollTop();
        if (blockTopOffset != null && blockTopOffset < windowScrollTop) {            
            leftColumn.css({
                position: 'absolute',
                top: windowScrollTop - blockTopOffset + "px"
            });
        } else if (blockTopOffset != null && blockTopOffset > windowScrollTop) {
            leftColumn.removeAttr("style");
        } else if ($("#row-intro-news").height() - 101 == parseInt($("#data-block").css("top").replace("px", "")) - $("#data-block").height()) {
            leftColumn.css({
                position: 'absolute',
                top: "587.047px"
            });
        }
    });
});
