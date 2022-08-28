(function ($) {

    /*============================ Navigation ================================================================*/

    //replace activeClass according to site Css
    //var activeClass = "button th-yellow active";
    //replace array elements with supported languages, if not a localized site, just set languages = []
    //var languages = ["ru"];
    //EX: $("#ulMenu").setNavigationActiveItem("active",["en","ru"]);
    $.fn.setNavigationActiveItem = function (activeClass, languages) {

        var menu = $(this);

        var path = window.location.pathname;
        path = decodeURIComponent(path);
        path = path.replace(/\/$/, "");


        var segments = path.split("/");
        while (segments.indexOf("") > -1) { //clean up empty segments
            segments.splice(segments.indexOf(""), 1);
        }

        //check if url starts with a locale
        var isUrlLocalized = false;
        for (var i = 0; i < languages.length; i++) {
            if (segments[0] === languages[i]) {
                isUrlLocalized = true;
                break;
            }
        }

        var match;
        if (path == "") {
            menu.children("li").eq(0).addClass(activeClass); //home page
            return;
        }
        for (var i = 0; i < languages.length; i++) {
            if (path == "/" + languages[0]) {
                menu.children("li").eq(0).addClass(activeClass);
                return;
            }
        }


        //try root level pages (/contact-us, /about-us, etc.)
        if ((segments.length == 1 && isUrlLocalized === false) ||
            (segments.length == 2 && isUrlLocalized === true)) {
            match = menu.find(' a[href="' + path + '"]').parent(); //to get the container li
            if (match.length > 0) {
                match.addClass(activeClass);
                return;
            }
        }

        //try subsequent levels (2nd and further pages)
        match = menu.find(' a[href="' + path + '"]').parent();
        if (match.length > 0) {
            match.addClass(activeClass);
            return;
        }

        //no root level match found, check for submenu items' parent elments
        match = menu.find(' a[href^="' + path + '"]').closest("ul").prev().parent(); //to get the container li
        if (match.length > 0) {
            match.addClass(activeClass);
            return;
        }

        //TODO: add support for custom mappings here
        console.log("No active menu item match found!");
    };


    /*============================ Validation Engine ================================================================*/
    //based on https://github.com/posabsolute/jQuery-Validation-Engine
    //EX: $("#divContactForm").validateForm();
    $.fn.validateForm = function () {
        // initialize validation
        var result = $(this).validationEngine('validate');
        return result;
    };


    /*============================ Magnific Popup ================================================================*/
    //Open Inline Div as popup modal using Magnific plugin http://dimsemenov.com/plugins/magnific-popup/
    //EX: $("#divContact").openInlinePopup();
    $.fn.openInlinePopup = function () {
        $(this).magnificPopup({
            type: 'inline',
            preloader: false,
            focus: '#name',
            closeOnBgClick: 'true',
            closeBtnInside: 'true',
    
        });
    };

    //Opne a link to video in popup modal using Magnific plugin http://dimsemenov.com/plugins/magnific-popup/
    //The video src should be in the Href Attribute of the anchor
    //EX: $("#lnkVideo").initializeVideoPopUp();
    $.fn.initializeVideoPopUp = function () {
        $(this).magnificPopup({
            disableOn: 700,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false
        });
    };


    //Opne a link to Image in popup modal using Magnific plugin http://dimsemenov.com/plugins/magnific-popup/
    //The image src should be in the Href Attribute of the anchor
    //EX: $("#lnkImage").initializeImagePopUp();
    $.fn.initializeImagePopUp = function () {
        $(this).magnificPopup({
            type: 'image',
            removalDelay: 300,
            mainClass: 'mfp-fade',
            overflowY: 'scroll'
        });
    };

    //Close any popup modal using Magnific plugin http://dimsemenov.com/plugins/magnific-popup/
    //EX: $.closePopup();
    $.fn.closePopup = function () {
        $.magnificPopup.close();
    };

    /*to initiallize carousel with just its class name and addition of data attributes on the div that has this class
    example:
        *Html Markup should look like this
        <div class="owl-carousel owl-center-scale gallery-carousel owl-loaded owl-drag owl-theme owl-center" data-nav="true"
         data-dots="false" data-margin="0" data-center="true"
         data-loop="true" data-responsive-sm="2" data-responsive-xs="2" data-responsive-xxs="1"

        * in ui.js call this function with the class name of your choice
        $('.owl-carousel').initializeCarousel();
    */
    $.fn.initializeCaruosel = function(){
        if (jQuery().owlCarousel) {
            jQuery(this).each(function () {
                var $carousel = jQuery(this);
                var data = $carousel.data();
                var loop = data.loop ? data.loop : false;
                var margin = (data.margin || data.margin === 0) ? data.margin : 30;
                var nav = data.nav ? data.nav : false;
                var dots = data.dots ? data.dots : false;
                var themeClass = data.themeclass ? data.themeclass : 'owl-theme';
                var center = data.center ? data.center : false;
                var items = data.items ? data.items : 4;
                var autoplay = data.autoplay ? data.autoplay : false;
                var responsiveXs = data.responsiveXs ? data.responsiveXs : 1;
                var responsiveXxs = data.responsiveXxs ? data.responsiveXxs : 1;
                var responsiveSm = data.responsiveSm ? data.responsiveSm : 2;
                var responsiveMd = data.responsiveMd ? data.responsiveMd : 3;
                var responsiveLg = data.responsiveLg ? data.responsiveLg : 4;
                var responsivexLg = data.responsivexLg ? data.responsivexLg : 6;
                var mouseDrag = $carousel.data('mouse-drag') === false ? false : true;
                var touchDrag = $carousel.data('touch-drag') === false ? false : true;
    
    
                $carousel.owlCarousel({
                    loop: loop,
                    margin: margin,
                    nav: nav,
                    navText: ['<span>prev</span>', '<span>next</span>'],
                    autoplay: autoplay,
                    dots: dots,
                    themeClass: themeClass,
                    center: center,
                    items: items,
                    smartSpeed: 400,
                    mouseDrag: mouseDrag,
                    touchDrag: touchDrag,
                    responsive: {
                        0: {
                            items: responsiveXxs
                        },
                        480: {
                            items: responsiveXs
                        },
                        768: {
                            items: responsiveSm
                        },
                        992: {
                            items: responsiveMd
                        },
                        1200: {
                            items: responsiveLg
                        }
                    },
                }).addClass(themeClass);
                if (center) {
                    $carousel.addClass('owl-center');
                }
    
                $window.on('resize', function () {
                    $carousel.trigger('refresh.owl.carousel');
                });
    
                $carousel.on('changed.owl.carousel', function () {
                    if (jQuery().prettyPhoto) {
                        jQuery("a[data-gal^='prettyPhoto']").prettyPhoto({
                            hook: 'data-gal',
                            theme: 'facebook', /* light_rounded / dark_rounded / light_square / dark_square / facebook / pp_default*/
                            social_tools: false
                        });
                    }
                })
            });
    
        }
    }

}($));

