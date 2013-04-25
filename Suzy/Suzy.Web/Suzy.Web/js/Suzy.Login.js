/// <reference path="jquery-1.8.0-vsdoc.js" />
(function ($) {

    var replaceText = "replace:";
    var alertText = "alert:";

    var methods = {
        init: function (options) {
            return this.each(function () {
                var $this = $(this);

                $this.submit(function () {
                    $.ajax({
                        type: "POST",
                        url: "/ajax/Common.asmx/Login",
                        data: "{email: '" + $this.find(".login-email").val() + "', password: " + $this.find(".login-password").val() + "}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d.indexOf(replaceText) == 0) {
                                //var $parent = $this.parent();
                                //$this.remove();
                                ////$parent.prepend(data.d.substring(replaceText.length));
                                //$parent.append(data.d.substring(replaceText.length));
                                location.reload();
                            } else if (data.d.indexOf(alertText) == 0) {
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

    $.fn.suzyLogin = function (method) {

        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery.suzyLogin');
        }
    };

})(jQuery);