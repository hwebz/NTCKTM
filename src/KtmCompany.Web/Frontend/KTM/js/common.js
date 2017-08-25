$(document).ready(function() {
    $('.carousel').carousel()
    var margL = parseInt(jQuery('header .container').css('margin-left')) + 15;
    var rowIntro = jQuery('.row-intro');
    if (rowIntro && rowIntro.length > 0) {
        var widthCol4 = jQuery('.row-intro').width() + margL + 1;

        $('.section-info').css({
            'padding-left': margL + 'px',
            'width': widthCol4 + 'px'
        });
        $('.info-block-content').css({ 'margin-left': margL + 'px' });
        $('.slide-img .carousel-indicators').css({ 'padding-left': margL + 'px' });
    }

    var pRowIntro = $('#row-intro-news').parent().height();
    $('#row-intro-news').css('height', pRowIntro + 'px');

    var pRowIntro1 = $('#row-about-company').parent().height();
    $('#row-about-company').css('height', pRowIntro1 + 'px');

    $('.main-slider .ktm-button').pageNav();

    /*var myJapaneseImgSrcs=['https://fbexternal-a.akamaihd.net/safe_image.php?d=AQC9VlSVDssR0HTg&w=470&h=246&url=http%3A%2F%2Fhrinsider.vietnamworks.com%2Fwp-content%2Fuploads%2F2015%2F02%2Fworking-on-holiday-vietnamworks-hrinsider-750x421.jpg&cfs=1&upscale=1&ext=png2jpg','https://fbexternal-a.akamaihd.net/safe_image.php?d=AQC9VlSVDssR0HTg&w=470&h=246&url=http%3A%2F%2Fhrinsider.vietnamworks.com%2Fwp-content%2Fuploads%2F2015%2F02%2Fworking-on-holiday-vietnamworks-hrinsider-750x421.jpg&cfs=1&upscale=1&ext=png2jpg'];

    $(".block-gallery img").each(function(index,ele){
       $(this).attr('src',myJapaneseImgSrcs[index]);
    });*/

    $(".video-control").on("click", function() {
        var video = document.getElementById("postVideo");
        if (video.paused) {
            video.play();
            $(this).css("background-image", "url(../images/pause-icon.png)");
        } else {
            video.pause();
            $(this).css("background-image", "url(../images/play-icon.png)");
        }
    });
    
    /*Animate sub-menu items*/
    $("ul.main-nav > li").mouseover(function() {
        var _this = this;
        $(_this).find("li").each(function(index, ele) {
            // $(ele).css({ opacity: 1 });
            setTimeout(function() {
                $(ele).animate({
                    'opacity': 1.0
                }, {
                    duration: 700
                });

            }, 100 + (index * 50));
        });
    });

    $("ul.main-nav > li").mouseleave(function() {
        var _this = this;
        $(_this).find("li").each(function(index, ele) {
            $(ele).removeAttr("style");
        });
    });
    /*END*/

});

//control the video banner player
//select video player in VideoBannerBlock
var videoCurrentTimes = new Array(); //get current playing time
$("#videoBanner").each(function(index, video) {
    videoCurrentTimes.push(0);
    var currentVideoSource = video.src;
    $(video).parent().find('.videoBannerText, .text-ovelay, #videoBanner').click(function() {
        var paused = video.paused;
        if (paused) {
            video.src = currentVideoSource;
            video.load();
            video.currentTime = videoCurrentTimes[index];
            video.play();
        } else {
            video.pause();
            videoCurrentTimes[index] = video.currentTime;
            video.src = "";
        }
    });
    //display poster after finish video playing
    video.onended = function() {
        this.load();
        this.pause();
    }
});

var textMessage = $('#text-message');
var messages = textMessage.data('text').split('|');
var loop = textMessage.data('loop');
var fadeIn = textMessage.data('fadeIn');
var fadeOut = textMessage.data('fadeOut');
var duration = textMessage.data('duration');

//console.log(fadeIn);

function nextMsg(i) {
    if (messages.length == i) {
        i = 0;
    }
    textMessage.html(messages[i]).fadeIn(fadeIn).delay(duration).fadeOut(fadeOut, function() {
        nextMsg(i + 1);
    });
};

nextMsg(0);

// code for video player in "selected-new" page.

$('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
    disableOn: 700,
    type: 'iframe',
    mainClass: 'mfp-fade',
    removalDelay: 160,
    preloader: false,

    fixedContentPos: false
});

$('.popup-player').magnificPopup({
    type: 'iframe',
    mainClass: 'mfp-fade',
    removalDelay: 160,
    preloader: false,
    fixedContentPos: false,
    iframe: {
        markup: '<div class="mfp-iframe-scaler">' +
                '<div class="mfp-close"></div>' +
                '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' +
              '</div>',

        srcAction: 'iframe_src',
    }
});
