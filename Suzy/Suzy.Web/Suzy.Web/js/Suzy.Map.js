/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {

    var myMap;
    var myLatitude, myLongitude, myAccuracy;
    var myLocationPoint;

    var methods = {
        init: function (options) {
            return this.each(function () {
                var $this = $(this);

                // Как только будет загружен API и готов DOM, выполняем инициализацию

                ymaps.ready(init);
                
                function init() {
                    // Создание экземпляра карты и его привязка к контейнеру с
                    // заданным id ("map")
                    myLatitude = ymaps.geolocation.latitude;
                    myLongitude = ymaps.geolocation.longitude;
                    myAccuracy = 0;
                    
                    myLocationPoint = new ymaps.GeoObjectCollection();
                    myMap = new ymaps.Map('big-map', {
                        center: [myLatitude, myLongitude],
                        zoom: 16
                    });
                    myMap.controls.add('mapTools');
                    myMap.controls.add('typeSelector');
                    myMap.controls.add('zoomControl');
                    myMap.controls.add('trafficControl');
                    myMap.controls.add('miniMap');

                    var myButton = new ymaps.control.Button({
                        data: {
                            content: 'Save position',
                            title: 'Save position'
                        }
                    }, {
                        selectOnClick: false
                    }
);
                    myButton.events
                        .add('click', function () {
                            methods.send();
                        });
                    myMap.controls.add(myButton, { top: 5, left: 160 });

                    SetPlacement(myMap, myLatitude, myLongitude, "Blue");
                    GetGeoLocation();
                }
                function SetPlacement(myMap, Latitude, Longitude, Color) {
                    var presetStyle = "twirl#blueIcon";
                    if (Color == "Red") presetStyle = "twirl#redIcon";
                    var placemark = new ymaps.Placemark(
                        [Latitude, Longitude],
                        {
                            iconContent: "I"
                        },
                        {
                            preset: presetStyle
                        }
                    );

                    placemark.events.add('click', function () { methods.send(); });

                    myLocationPoint.add(placemark);
                    
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
                    myAccuracy = position.coords.accuracy;
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
        },
        send: function () {
            $.ajax({
                type: "POST",
                url: "/ajax/Common.asmx/SavePosition",
                data: "{latitude: " + myLatitude + ", longitude: " + myLongitude + ", radius:" + myAccuracy + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //if (data.d.indexOf(replaceText) == 0) {
                    //    var $parent = $this.parent();
                    //    $this.remove();
                    //    //$parent.prepend(data.d.substring(replaceText.length));
                    //    $parent.append(data.d.substring(replaceText.length));
                    //} else if (data.d.indexOf(alertText) == 0) {
                    //    alert(data.d.substring(alertText.length));
                    //} else {
                    //    console.log(data.d);
                    //}

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