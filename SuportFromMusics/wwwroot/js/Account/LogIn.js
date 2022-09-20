var txtEmail = document.getElementById["email"].value;
var txtPassword = document.getElementById["password"].value;
var txtError = document.getElementById["txtError"];

alert("Llksdfkl");

function checkform() {
    if (txtEmail == "") {
        txtError.innerHTML = "لطفا ایمیل را وارد کنید";
        return false;
    }
    else if (txtPassword == "") {
        txtError.innerHTML = "لطفا رمز عبور را وارد نمایید";
        return false;
    }
}