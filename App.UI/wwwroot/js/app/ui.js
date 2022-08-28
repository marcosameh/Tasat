$(document).ready(function () {

    // M-Menu=====================================================
    mmenu = new Mmenu("#mobileMenu", {
        navbar: {
            title: ""
        },
        offCanvas: {
            position: "left"
        }
    }, {
        offCanvas: {
            page: {
                pageNodetype: 'body',
                selector: "main"
            }
        }
    });

    //===================Magnific Popup==================================
    $(".popup-with-form").openInlinePopup();
    $('.popup-youtube, .popup-vimeo, .popup-gmaps').initializeVideoPopUp();
    $(".popup-image").initializeImagePopUp();


     //===================owl Carousel==================================
     $('.owl-carousel').initializeCarousel();

});

function popupWindowAtCenter(url) {
    popupWindow = window.open(
        url, 'popUpWindow', 'height=600,width=600,left=10,top=10,resizable=yes,scrollbars=yes,toolbar=yes,menubar=no,location=no,directories=no,status=yes')
}