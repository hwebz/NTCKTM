$(window).ready(function () {
    if ($(window).width() >= 768) {
        sticky();
    }
});
$(window).scroll(function () {
    if ($(window).width() >= 768) {
        sticky();
    }
});
function sticky() {
    $('.sticky-container').each(function () {
        var container = $(this);
        var sticky = container.find('.outer-main-intro');
        var rightColumn = container.find(".col-sm-7");
        if ($(window).scrollTop() > container.offset().top) {
            var min_value = rightColumn.height() - sticky.height();
            min_value = (min_value < 0) ? 0 : min_value;
            //if (container.hasClass('first-section')) {
            //    min_value = (container.height() - sticky.height()) / 2 + 50;
            //}
            sticky.css('top', Math.min($(window).scrollTop() - container.offset().top, min_value));
        }
        else {
            sticky.css('top', 0);
        }
    });
}