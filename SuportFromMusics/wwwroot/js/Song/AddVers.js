alert("Hello");
var txtVers = document.getElementById("txtVersText");
var VersNumber = document.getElementById("Versnumber");
var txtError = document.getElementById("ErrorMessage");

function checkform() {
    txtError.style.color = "red";
    if (txtVers.value == "") {
        txtError.innerHTML = "لطفا متن را اهنگ را وارد کنید";
        return false;
    }
    else if (VersNumber.value == 0) {
        txtError.innerHTML = "لطفا شماره ورس را وارد کنید";
        return false;
    }
}

document.getElementById('AddNum').addEventListener("click", AddToVersNum);
document.getElementById('lessnum').addEventListener("click", LessFromVersNum);

function AddToVersNum() {

    Verstext += 1;
}
function LessFromVersNum() {
    Verstext -= 1;
}
