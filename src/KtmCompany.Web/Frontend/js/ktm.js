$(function () {
    var rowIntro = jQuery('.row-intro');
    //if (!rowIntro || rowIntro.length === 0) {
    //    $('.section-map').addClass("col-sm-8");
    //}

    //initialize Information Tabs Block Image
    $('.type-of-categories').each(function (index, item) {
        var $item = $(item);

        var $activeTab = $item.find("li.active .tab-selection").first();

        if ($activeTab) {            
            var tabId = $activeTab.attr("tab-id");
            var sectionBg = $item.closest('.section-bg');
            var backgroundSrc = sectionBg.find('.bg-img img[tab-id="'+ tabId +'"]').first().attr("src");            
            if (backgroundSrc && tabId !== "All") {
                sectionBg.css("background-image", "url('" + backgroundSrc + "')");
            } else {
                sectionBg.css("background-image", "none");
            }
        }
    });

    $(".type-of-categories-mobile select").change(function () {
        var tabId = $(this).children(":selected").attr("tab-id");
        var contentContainer = $($(this).attr("content-container"));
        var sectionBg = contentContainer.closest('.section-bg');

        var url = window.location.pathname;
        url += '?tab=' + $(this).children(":selected").text();
        window.history.pushState(null, null, url);

        if (tabId === "All") {
            contentContainer.children("div").show();
            sectionBg.css("background-image", "none");
        } else {
            contentContainer.children("div").hide().each(function () {
                if ($(this).attr("tab-id") === tabId) {
                    $(this).show();
                }
            });
        }        
        $($(this).attr("image-container")).find("img").each(function () {            
            if ($(this).attr("tab-id") === tabId) {
                $(this).show();                
                var backgroundSrc = $(this).attr("src");
                if (backgroundSrc) {
                    sectionBg.css("background-image", "url('" + backgroundSrc + "')");
                } else {
                    sectionBg.css("background-image", "none");
                }
            } else {
                $(this).hide();                
            }
        });
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
        var sectionBg = contentContainer.closest('.section-bg');

        var url = window.location.pathname;
        url += '?tab=' + tabSelection.attr("title");
        window.history.pushState(null, null, url);

        ulEle.children("li").removeClass("active");
        tabSelection.parent().addClass("active");
        if (tabId === "All") {
            contentContainer.children("div").show();
            sectionBg.css("background-image", "none");
        }
        else
        {
            contentContainer.children("div").hide().each(function () {
                 if ($(this).attr("tab-id") === tabId) {
                     $(this).show();
                 }
             });   
        }        
        $($(this).attr("image-container")).find("img").each(function () {
            if ($(this).attr("tab-id") === tabId) {
                $(this).show();
                var backgroundSrc = $(this).attr("src");
                if (backgroundSrc) {
                    sectionBg.css("background-image", "url('" + backgroundSrc + "')");
                } else {                    
                    sectionBg.css("background-image", "none");
                }
            } else {
                $(this).hide();                
            }
        });
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