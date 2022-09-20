var UserName = document.getElementById('UserName');
var Password = document.getElementById('IPassword');
var RepeatPassword = document.getElementById('IRPassword');
var ErrorEleman = document.getElementById('ErrorMessage');


function checkForm() {
    if (UserName.value == null) {
        ErrorEleman.innerHTML = "لطفا نام کاربری را وارد کنید";
        return false;
    }
    else if (Password.value == "") {
        ErrorEleman.innerHTML = "لطفا رمز عبور را وارد کنید";
        return false;
    }
    else if (Password.length < 6) {
        ErrorEleman.innerHTML = "رمز عبور نمی توانذ کمتر از 6 کاراکتر باشد";
        return false;
    }
    else if (RepeatPassword.value == "") {
        ErrorEleman.innerHTML = "لطفا تکرار رمز عبور را وارد کنید";
        return false;
    }
    else if (Password.value != RepeatPassword.value) {
        ErrorEleman.innerHTML = "تکرار رمز عبور صحیح نمی باشد";
        return false;
    }
}