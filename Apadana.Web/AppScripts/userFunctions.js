/*----------------- change password -------------------------*/
/*-----------------     START        -------------------------*/
/* Area/Employer/Auth/ChangePassword */

var changePasswordResult = function (data, status, xhr) {

    console.log(data.responseJSON.success);

    var message = "", header = "";

    header = "تغییر رمز عبور"
    if (data.responseJSON.success == true) {
        message = "رمز عبور با موفقیت عوض شد.";
    } else {
        message = "خطا: عملیات تغییر رمز عبور خطا دارد. لطفا دوباره تلاش کنید.";
    }

    show_message(data.responseJSON.success, message, header);

    enable_form();
}