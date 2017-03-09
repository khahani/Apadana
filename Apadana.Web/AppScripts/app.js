/* ------------------ client config section ---------------*/
/*-----------------     START        -------------------------*/

var config_message_type = "sweetalert"; //options: toast, sweetalert
var config_loading_type = "double-bounce"; // options: wave, double-bounce
var config_ajax_timeout = 4000;
var config_disable_form_type = "button"; //options: form, button
/*-----------------     END         --------------------------*/


/* ---------------- Submit form through Ajax ------------------------------*/
/* ---------------- START    -----------------------------*/
$(function () {

        $.validator.setDefaults({
            ignore: []
        });

    function ajaxFormSubmit(e) {
        try {

            $.validator.unobtrusive.parse($("form[data-ajax='true']"));

            var isValid = $(this).valid();

            if (!isValid) {
                return false;
            }
            var $form = $(this);

            var options = {
                beforeSend: disable_form,
                url: $form.attr("action"),
                type: $form.attr("method"),
                data: $form.serialize(),
                timeout: config_ajax_timeout,
                fail: serverConnectingFailed
            };

            $.ajax(options);

            e.preventDefault(); // avoid to execute the actual submit of the form.

        }catch(error){
            console.log(error);
        }finally{
            enable_form();
        }
    }

    $("form[data-ajax='true']").submit(ajaxFormSubmit);
   
});
/* ---------------- END     -----------------------------*/

/* ---------------- Server Connection Failure ------------------------------*/
/* ---------------- START    -----------------------------*/

function serverConnectingFailed(jqXHR, exception) {

    if (jqXHR.status === 0) {
        show_message(false, "لطفا اتصال به اینترنت را بررسی کنید..", "عدم اتصال به شبکه");
    } else if (jqXHR.status == 404) {
        show_message(false, 'صفحه مورد نظر وجود ندارد. [404]', "خطا 404");
    } else if (jqXHR.status == 500) {
        show_message(false, 'خطا داخلی سرور رخ داده است [500].', "خطا 500");
    } else if (exception === 'parsererror') {
        show_message(false, 'نتیجه دریافتی غیر قابل قبول است.', "خطا");
    } else if (exception === 'timeout') {
        show_message(false, "اتصال به سرور خارج از محدوده زمان تعیین شده می باشد. لطفا دوباره تلاش کنید.", "اتمام زمان اتصال");
    } else if (exception === 'abort') {
        show_message(false, 'درخواست شما توسط سرور رد شد.', "خطا");
    } else {
        show_message(false, "در ایجاد ارتباط با سرور مشکل بوجود آمده است. لطفا دوباره تلاش کنید.", "خطا نا مشخص");
    }

    enable_form();
}

/* ---------------- End    -----------------------------*/



/* ---------------- enable / disable form ------------------------------*/
/* ---------------- START    -----------------------------*/

var form_is_disable = false;

function disable_form() {
    switch(config_disable_form_type)
    {
        case "form":
            $("form[data-ajax='true'] :input").attr("disabled", true);
            break;
        case "button":
            setTimeout(function () { $("form[data-ajax='true'] :button[data-disable-onsubmit='true']").attr("disabled", true); }, 0);
            break;
    }
    
    form_is_disable = true;

    setTimeout(function () { }, 0);
}

function enable_form() {
    if (!form_is_disable)
        return;
    switch (config_disable_form_type) {
        case "form":
            $("form[data-ajax='true'] :input").attr("disabled", false);
            break;
        case "button":
            $("form[data-ajax='true'] :button[data-disable-onsubmit='true']").attr("disabled", false);
            break;
    }
        
}

/* ---------------- END    -----------------------------*/



/* ---------------- show message ------------------------------*/
/* ---------------- START    -----------------------------*/

function show_message(isSuccess, message, header)
{
    switch(config_message_type)
    {
        case "toast":
            setTimeout(function () {
                toastr.options = {
                    closeButton: true,
                    progressBar: true,
                    showMethod: 'slideDown',
                    positionClass: 'toast-top-left',
                    timeOut: 4000
                };

                if (isSuccess)
                    toastr.success(message, header);
                else
                    toastr.error(message, header);

            }, 1300);
           
            break;
        case "sweetalert":
            swal({
                title: header,
                text: message,
                timer: 4000,
                type: isSuccess ? "success" : "error"
            });
            break;
    }
}

/*-----------------     End        -------------------------*/

/* ---------------- Loading ------------------------------*/
/* ---------------- START    -----------------------------*/

function show_loading(selector) {
    var loadingHtml;
    switch (config_loading_type) {
        case "wave":
            loadingHtml = '<div class="sk-spinner sk-spinner-wave"><div class="sk-rect1"></div><div class="sk-rect2"></div><div class="sk-rect3"></div><div class="sk-rect4"></div><div class="sk-rect5"></div></div>';
            break;
        case "double-bounce":
            loadingHtml = '<div class="sk-spinner sk-spinner-double-bounce"><div class="sk-double-bounce1"></div><div class="sk-double-bounce2"></div></div>';
            break;
    }

    $(selector).append(loadingHtml);
}
function hide_loading(selector) {
    $(selector).empty();
}

/*------------------- END   -----------------------------*/