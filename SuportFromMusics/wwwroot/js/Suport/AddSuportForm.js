var Maxvalue = document.getElementById('Number-Maxvalue');
//alert('Salam0');

function lessMaxValue() {
    if (Maxvalue.value >= 1000000) {
        Maxvalue.value -= 1000000;
    }
}
function addMaxValue() {
    Maxvalue = 1000000;
}
function CheckMaxValue() {

}