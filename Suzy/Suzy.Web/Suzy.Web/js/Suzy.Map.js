/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {

    var myMap;
    var myLatitude, myLongitude, myAccuracy;
    var myLocationPoint;
    var $this;
    var points = undefined;

    var methods = {
        init: function (options) {
            if (options !== undefined && options.points !== undefined)
                points = options.points;

            return this.each(function () {
                $this = $(this);

                // Как только будет загружен API и готов DOM, выполняем инициализацию
                ymaps.ready(init);
                
                function init() {
                    // Создание экземпляра карты и его привязка к контейнеру с
                    // заданным id ("map")
                    myLatitude = ymaps.geolocation.latitude;
                    myLongitude = ymaps.geolocation.longitude;
                    myAccuracy = 0;
                    
                    myLocationPoint = new ymaps.GeoObjectCollection();
                    myMap = new ymaps.Map($this.attr("id"), {
                        center: [myLatitude, myLongitude],
                        zoom: 16
                    });
                    myMap.behaviors.enable('scrollZoom');
                    myMap.controls.add('mapTools');
                    myMap.controls.add('typeSelector');
                    myMap.controls.add('zoomControl');
                    myMap.controls.add('trafficControl');
                    myMap.controls.add('miniMap');

//                    var myButton = new ymaps.control.Button({
//                        data: {
//                            content: 'Save position',
//                            title: 'Save position'
//                        }
//                    }, {
//                        selectOnClick: false
//                    }
//);
//                    myButton.events
//                        .add('click', function () {
//                            methods.send();
//                        });
//                    myMap.controls.add(myButton, { top: 5, left: 160 });

                    SetPlacement(myMap, myLatitude, myLongitude, "Blue");
                    GetGeoLocation();
                    
                    if (points !== undefined) {
                        //http://api.yandex.ru/maps/doc/jsapi/2.x/ref/reference/Clusterer.xml

                        // создание кластеризатора
                        // создадим массив геообъектов
                        myGeoObjects = [];
                        
                        for (var i = 0; i < points.length; i++) {
                            myGeoObjects[i] = new ymaps.GeoObject({
                                geometry: { type: "Point", coordinates: [points[i].Latitude, points[i].Longitude] }
                                , properties: {
                                    clusterCaption: points[i].Title
                                    //, balloonContentBody: 'Содержимое балуна геообъекта №1.'
                                }
                            });
                        }
                        //myGeoObjects[0] = new ymaps.GeoObject({
                        //    geometry: { type: "Point", coordinates: [56.034, 36.992] },
                        //    properties: {
                        //        clusterCaption: 'Геообъект №1',
                        //        balloonContentBody: 'Содержимое балуна геообъекта №1.'
                        //    }
                        //});
                        //myGeoObjects[1] = new ymaps.GeoObject({
                        //    geometry: { type: "Point", coordinates: [56.021, 36.983] },
                        //    properties: {
                        //        clusterCaption: 'Геообъект №2',
                        //        balloonContentBody: 'Содержимое балуна геообъекта №2.'
                        //    }
                        //});

                        // создадим кластеризатор и запретим приближать карту при клике на кластеры
                        clusterer = new ymaps.Clusterer({
                            clusterDisableClickZoom: true,
                            openBalloonOnClick: false
                        });
                        clusterer.add(myGeoObjects);
                        
                        

                        // Открытие балуна кластера с выбранным объектом.

                        // Поскольку по умолчанию объекты добавляются асинхронно,
                        // обработку данных можно делать только после события, сигнализирующего об
                        //// окончании добавления объектов на карту.
                        //clusterer.events.add('objectsaddtomap', function () {

                        //    // Получим данные о состоянии объекта внутри кластера.
                        //    var geoObjectState = clusterer.getObjectState(myGeoObjects[1]);
                        //    // Проверяем, находится ли объект находится в видимой области карты.
                        //    if (geoObjectState.isShown) {

                        //        // Если объект попадает в кластер, открываем балун кластера с нужным выбранным объектом.
                        //        if (geoObjectState.isClustered) {
                        //            geoObjectState.cluster.state.set('activeObject', myGeoObjects[1]);
                        //            geoObjectState.cluster.balloon.open();

                        //        } else {
                        //            // Если объект не попал в кластер, открываем его собственный балун.
                        //            myGeoObjects[1].balloon.open();
                        //        }
                        //    }

                        //});

                        myMap.geoObjects.add(clusterer);

                    }
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
                            preset: presetStyle,
                            draggable: true
                        }
                    );

                    placemark.events.add('click', function () { methods.send(); });

                    placemark.events.add('dragend', function () {
                        var coor = placemark.geometry.getCoordinates();
                        myLatitude = coor[0];
                        myLongitude = coor[1];
                        myAccuracy = 1;
                    });

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