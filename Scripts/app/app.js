/* Use the Revealing Module Pattern , Together With IIFE*/
 /* Here is an example of how modularize your javascript code */

/*var HelloJsWorld = function() {
    var sayHi = function() {
        alert("Hello Javascript World!");
    }


    return {
        sayHi: sayHi
    }
}();*/

/* And than call it in your view by calling the function by HelloJsWorld.SayHi() */

var CustomNotifications = function() {
    var displayMessage = function(message, msgType) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
        toastr[msgType](message);
    };

    if ($('#success').val()) {
        displayMessage($('#success').val(), 'success');
    }
    if ($('#info').val()) {
        displayMessage($('#info').val(), 'info');
    }
    if ($('#warning').val()) {
        displayMessage($('#warning').val(), 'warning');
    }
    if ($('#error').val()) {
        displayMessage($('#error').val(), 'error');
    }
    return {
        displayMessage: displayMessage
    }

/*Set the following values in the controller in order make the pop ups
TempData["warning"] = "Warning Message!!";
TempData["success"] = "Mensagem de sucesso!!";
TempData["info"] = "Mensagem de informação!!";
TempData["error"] = "Mensagem de erro!!";*/
}();