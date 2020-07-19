/**
 * Product:        Social - Premium Responsive Admin Template
 * Version:        v1.5.1
 * Copyright:      2013 CesarLab.com
 * License:        http://themeforest.net/licenses
 * Live Preview:   http://go.cesarlab.com/SocialAdminTemplate
 * Purchase:       http://go.cesarlab.com/PurchaseSocial
 *
*/

var FormValidation;

FormValidation = (function ($) {
    "use strict";
    /**/

    var handleFormValidation, init;
    init = function () {
        handleFormValidation();
    };

    handleFormValidation = function () {
        $("#form1").validate({
            errorElement: "span",
            errorPlacement: function (error, element) {
                error.appendTo(element.parents("div.controls"));
                error.addClass("help-block");
                element.parents(".control-group").removeClass("success").addClass("error");
                return element.parents(".control-group").find("a.chzn-single").addClass("error");
            },
            success: function (label) {
                label.parents(".control-group").removeClass("error");
                return label.parents(".control-group").find("a.chzn-single").removeClass("error");
            },
            rules: rulesOpts
            ,
            submitHandler: submitFun
        });
    };
    return {
        init: init
    };
})(jQuery);
