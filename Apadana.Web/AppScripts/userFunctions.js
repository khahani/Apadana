/*----------------- change password -------------------------*/
/*-----------------     START        -------------------------*/
/* Area/Employer/Auth/ChangePassword */

var changePasswordResult = function (data, status, xhr) {
    try {
        console.log(data.responseJSON.success);

        var message = "", header = "";

        header = "تغییر رمز عبور"
        if (data.responseJSON.success == true) {
            message = "رمز عبور با موفقیت عوض شد.";
        } else {
            message = "خطا: عملیات تغییر رمز عبور خطا دارد. لطفا دوباره تلاش کنید.";
        }

        show_message(data.responseJSON.success, message, header);
    } catch (error) {
        console.log(error);
    } finally {
        enable_form();
    }
}

/*---------------------- End change password -------------------------------------*/

/*----------------- save employer information by employer -------------------------*/
/*-----------------     START        -------------------------*/
/* Area/Employer/Employers/Create */

var createEmployer = function (data, status, xhr) {
    try {
        console.log('response receieved');
        console.log(data.responseJSON.success);
        console.log(data.responseJSON.resultType);

        if (data.responseJSON.resultType == "redirect") {
            console.log("it is redirect");
            window.location = data.responseJSON.url;
        }

        var message = "", header = "";

        if (data.responseJSON.success == true) {
            header = " ذخیره شد"
            message = "اطلاعات کارفرما با موفقیت ذخیره شد.";
        } else {
            header = " ذخیره نشد"
            message = "خطا: عملیات ذخیره اطلاعات کارفرما خطا دارد. لطفا دوباره تلاش کنید.";
        }

        show_message(data.responseJSON.success, message, header);
    }
    catch (error) {
        console.log(error);
    } finally {
        enable_form();
    }
}

/*----------------- End save employer information by employer -------------------------*/