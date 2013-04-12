/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {

    //var replaceText = "replace:";
    //var alertText = "alert:";

    var methods = {
        init: function (options) {
            return this.each(function () {
                var $this = $(this);

                // Как только будет загружен API и готов DOM, выполняем инициализацию
                var myMap;
                var myLatitude, myLongitude;
                var myLocationPoint;
                ymaps.ready(init);
                GetGeoLocation();
                function init() {
                    // Создание экземпляра карты и его привязка к контейнеру с
                    // заданным id ("map")
                    myLatitude = ymaps.geolocation.latitude;
                    myLongitude = ymaps.geolocation.longitude;
                    myLocationPoint = new ymaps.GeoObjectCollection();
                    myMap = new ymaps.Map('big-map', {
                        center: [myLatitude, myLongitude],
                        zoom: 16
                    });
                    myMap.controls.add(new ymaps.control.ZoomControl());
                    myMap.controls.add('typeSelector');
                    myMap.controls.add('zoomControl');
                    myMap.controls.add('trafficControl');
                    SetPlacement(myMap, myLatitude, myLongitude, "Blue")
                }
                function SetPlacement(myMap, Latitude, Longitude, Color) {
                    var presetStyle = "twirl#blueIcon";
                    if (Color == "Red") presetStyle = "twirl#redIcon";
                    myLocationPoint.add(
                        new ymaps.Placemark(
                           [Latitude, Longitude],
                           {
                               iconContent: "I"
                           },
                           {
                               preset: presetStyle
                           }
                        )
                    );
                    myMap.geoObjects.add(myLocationPoint);
                    myMap.panTo([Latitude, Longitude]);
                }
                function GetGeoLocation() {
                    var timeoutTime = 10 * 1000 * 1000;
                    if (navigator.geolocation) {
                        navigator.geolocation.getCurrentPosition(
                        SetMyCoords,
                        displayError,
                        { enableHighAccuracy: true, timeout: timeoutTime, maximumAge: 0 }
                        );
                    } else {
                        alert("Geolocation API is not supported on your browser");
                    }
                }
                function SetMyCoords(position) {
                    myLatitude = position.coords.latitude;
                    myLongitude = position.coords.longitude;
                    myLocationPoint.removeAll();
                    SetPlacement(myMap, myLatitude, myLongitude, "Red");
                }
                function displayPosition(position) {
                    alert("Latitude: " + position.coords.latitude + ", Longitude: " + position.coords.longitude);
                }
                function displayError(error) {
                    var errors = {
                        1: 'No access',
                        2: 'Location can not be determined',
                        3: 'Connect timeout'
                    };
                    alert("Error: " + errors[error.code]);
                }

            });
        }
    };

    $.fn.suzyMap = function (method) {

        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.suzyMap');
        }
    };

})(jQuery);