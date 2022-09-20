
function CheckForm() {
    var Email = document.getElementById('InputEmail').value;
    if (Email == "") {
        document.getElementById('ErrorMessage').style.color = 'red';
        document.getElementById('ErrorMessage').innerHTML = 'لطفا ایمیل را وارد کنید';
        return false;
    }
}