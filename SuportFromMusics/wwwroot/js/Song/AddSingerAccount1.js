//var btn = document.getElementById('btnChangeTitle');
//var IsUseFullnameForTitle = document.getElementById('IsUseFullNameAsTitle');
var TitleBox = document.getElementById('DivTitle');

var ShowTitleDiv = true;
function checkBox() {
    var ChangeTitle = document.getElementById('btnChangeTitle');
    if (ShowTitleDiv == true) {
        ChangeTitle.innerHTML = "استفاده از لقب";
        document.getElementById('IsUseFullNameAsTitle').value = true;
        TitleBox.style.display = "none";
        ShowTitleDiv = false;
    }
    else {
        ChangeTitle.innerHTML = "استفاده از نام و نام خانوادگی";
        document.getElementById('IsUseFullNameAsTitle').value = false;
        TitleBox.style.display = "";
        ShowTitleDiv = true;
    }
}