function calculatePositionOfBackgroundImage(container) {
    if (container.parent().css('display') == 'none')
        return;

    var wrapContainer = container.parents('.container');
    var rightColumn = wrapContainer.find('.right-block');

    var containerOffset = wrapContainer.offset().left;
    var imgHeight = container.find('img').height();
    container.height(imgHeight);

    var textContainer = container.parent().children().eq(0);

    // text and image are in a row
    if (textContainer.offset().top == container.offset().top) {
        if (wrapContainer.outerHeight() - parseInt(rightColumn.css('padding-top')) > imgHeight) {
            container.find('img').css({ "top": wrapContainer.outerHeight() - parseInt(rightColumn.css('padding-top')) - imgHeight });
        }
        else {
            container.find('img').css({ "top": 0 });
        }
    }
    else {
        if (wrapContainer.outerHeight() - parseInt(rightColumn.css('padding-top')) - textContainer.height() > imgHeight) {
            container.find('img').css({ "top": wrapContainer.outerHeight() - parseInt(rightColumn.css('padding-top')) - textContainer.height() - imgHeight });
        }
        else {
            container.find('img').css({ "top": 0 });
        }
    }

    var right = $(window).width() - (containerOffset + wrapContainer.outerWidth());
    container.find('img').css({ "right": -right });
}

function image_as_background() {
    var imageBackgroundContainer = $('.image-as-background');
    if (imageBackgroundContainer && imageBackgroundContainer.length > 0) {
        for (var i = 0; i < imageBackgroundContainer.length; i++) {
            calculatePositionOfBackgroundImage(imageBackgroundContainer.eq(i));
        }
    }
}

$(window).load(function () {
    image_as_background();
});

$(function () {
    $(window).resize(function () {
        image_as_background();
    });

    //initialize Information Tabs Block Image    
    $(".type-of-categories-mobile select").change(function () {
        var tabId = $(this).children(":selected").attr("tab-id");
        var contentContainer = $($(this).attr("content-container"));

        var url = window.location.pathname;
        url += '?tab=' + $(this).children(":selected").text();
        window.history.pushState(null, null, url);

        if (tabId === "All") {
            contentContainer.children("div").show();
        } else {
            contentContainer.children("div").hide().each(function () {
                if ($(this).attr("tab-id") === tabId) {
                    $(this).show();
                }
            });
        }      
        $($(this).attr("category-tabs")).find(".tab-selection").each(function () {
            if ($(this).attr("tab-id") === tabId) {
                $(this).closest("li").addClass("active");                
            } else {
                $(this).closest("li").removeClass("active");
            }
        });
    });

    $(".tab-selection").on("click", function () {
        var tabSelection = $(this);
        var tabId = tabSelection.attr("tab-id");
        var ulEle = tabSelection.parent().parent();        
        var contentContainer = $($(this).attr("content-container"));

        var url = window.location.pathname;
        url += '?tab=' + tabSelection.attr("title");
        window.history.pushState(null, null, url);

        ulEle.children("li").removeClass("active");
        tabSelection.parent().addClass("active");
        if (tabId === "All") {
            var allTabContents = contentContainer.children("div");
            for (var i = 0; i < allTabContents.length; i++) {
                allTabContents.show();
                calculatePositionOfBackgroundImage(allTabContents.eq(i).find('.image-as-background'));
            }
        }
        else
        {
            contentContainer.children("div").hide().each(function () {
                 if ($(this).attr("tab-id") === tabId) {
                     $(this).show();

                     calculatePositionOfBackgroundImage($(this).find('.image-as-background'));
                 }
             });   
        }        
        $($(this).attr("category-dropdown")).children("option").each(function() {
            if ($(this).attr("tab-id") === tabId) {
                $(this).attr("selected","selected");                
            } else {
                $(this).removeAttr("selected");
            }
        });
        return false;
    });

    $('#imageBannerReadMore').on("click", function () {
        var ele = $(this).closest(".header-image-post").nextAll('div, section').first();
        if (ele.length > 0) {
            $("html, body").animate({
                scrollTop: $(ele).offset().top
            }, 500);
        }
        return false;
    });

    sharePriceSelection();
});

function toggleLoadMoreContentsButton(visible) {
    if (visible) {
        $('#loadMoreContents').show();
    } else {
        $('#loadMoreContents').hide();
    }
}

function setActiveItemsDirectory(category) {
    if (category !== undefined) {
        $('.type-of-categories span').each(function (index, item) {
            if ($(item).text().toLowerCase() == category.toLowerCase()) {
                $(item).parent().parent().addClass("active");
            }
        });
    } else {
        $('.type-of-categories li').first().addClass("active");
    }
}

function sharePriceSelection() {    
    var sharePriceCombobox = $("[share-price-selection]");    
    if (sharePriceCombobox) {
        sharePriceCombobox.change(function () {            
            var selectedYear = $(this).val();
            var sharePriceTable = $(this).closest("[share-price-table]");
            sharePriceTable.find("[share-price-time]").hide();
            sharePriceTable.find("[share-price-time='" + selectedYear + "']").show();
        });
    }
}

$.urlParams = function () {
    var j, q;
    q = location.search.replace(/\?/, "").split("&");
    j = {};
    $.each(q, function (i, arr) {
        arr = arr.split('=');
        return j[arr[0]] = decodeURIComponent((arr[1]||"").replace(/\+/g, ' '));
    });
    return j;
}

function changeUrlParam(baseUrl, params) {
    var queryString = $.param(params);
    window.location.href = (baseUrl || [location.protocol, '//', location.host, location.pathname].join('')) + "?" + queryString;
}