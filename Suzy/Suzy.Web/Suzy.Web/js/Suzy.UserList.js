/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {
    var trueText = "true";

    var methods = {
        init: function (options) {
            return this.each(function () {
                var $this = $(this);

                $this.find(".userFolButton").each(function () {
                    var $button = $(this);
                    $button.click(function () {

                        if ($button.hasClass("btn-danger")) {

                            if ($button.hasClass("disabled")) {

                            } else {
                                $button.addClass("disabled");
                            }

                            $.ajax({
                                type: "POST",
                                url: "/ajax/Common.asmx/UnFollowing",
                                data: "{id: " + $button.attr("id") + " }",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    if (data.d == trueText) {
                                        $button.removeClass("btn-danger");
                                        $button.addClass("btn-success");
                                        $button.val("Following");
                                    }

                                    if ($button.hasClass("disabled")) {
                                        $button.removeClass("disabled");
                                    }
                                }
                            });

                        } else if ($button.hasClass("btn-success")) {

                            if ($button.hasClass("disabled")) {

                            } else {
                                $button.addClass("disabled");
                            }

                            $.ajax({
                                type: "POST",
                                url: "/ajax/Common.asmx/Following",
                                data: "{id: " + $button.attr("id") + " }",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    if (data.d == trueText) {
                                        $button.removeClass("btn-success");
                                        $button.addClass("btn-danger");
                                        $button.val("Follow");
                                    }

                                    if ($button.hasClass("disabled")) {
                                        $button.removeClass("disabled");
                                    }
                                }
                            });

                        }
                    });

                });

            });
        }
    };

    $.fn.userList = function (method) {
        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.suzyProfile');
        }
    };
})(jQuery);