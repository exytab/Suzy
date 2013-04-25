/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {
    var methods = {
        init: function (options) {
            return this.each(function () {
                var $this = $(this);

                $this.click(function () {
                    $.ajax({
                        type: "POST",
                        url: "/ajax/Common.asmx/Logout",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            location.reload();
                        }
                    });
                    return false;
                });
            });
        }
    };

    $.fn.suzyLogout = function (method) {

        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.suzyLogout');
        }
    };

})(jQuery);