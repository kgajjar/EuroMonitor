(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link'); //For Changing The Link On The Logo Image
            logo[0].href = "https://www.euromonitor.com/";
            logo[0].target = "_blank";

            logo[0].children[0].alt = "Implemeting Swagger";
            logo[0].children[0].src = "https://blog.euromonitor.com/wp-content/themes/euromonitor/assets/images/logo.png"; //For Changing The Logo Image
        });
    });
})();