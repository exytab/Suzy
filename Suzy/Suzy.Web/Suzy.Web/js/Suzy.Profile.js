/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {
    var alertText = "alert:";

    var methods = {
        init: function(options) {
            return this.each(function() {
                var $this = $(this);
                $this.find("#saveProfile").click(function() {
                    $.ajax({
                        type: "POST",
                        url: "/ajax/Common.asmx/SaveProfile",
                        data: "{id: " + $this.find("#idInput").val() + ", name: '" + $this.find("#nameInput").val() + "', password: '" + $this.find("#passwordInput").val() + "', password2: '" + $this.find("#password2Input").val() + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d.indexOf(alertText) == 0) {
                                alert(data.d.substring(alertText.length));
                            } else {
                                console.log(data.d);
                            }

                        }
                    });
                    return false; 
                });
            });
        }
    };

    $.fn.suzyProfile = function(method) {

        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.suzyProfile');
        }
    };
})(jQuery);