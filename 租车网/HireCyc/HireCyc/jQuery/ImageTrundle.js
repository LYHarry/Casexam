//图片滚动
var slideNo = 0;
var slideTimer = null;
function showSlide() {
    var slide = document.getElementById("change_ul").getElementsByTagName("li");
    var spans = document.getElementById("slide_no").getElementsByTagName("span");
    for (var i = 0; i < spans.length; i++) {
        spans[i].className = "";
    }
    spans[slideNo].className = "curr";
    for (var i = 0; i < slide.length; i++) {
        slide[i].className = "";
    }
    slide[slideNo].className = "curr_li";
}
function changeSlide() {
    slideNo++;
    if (slideNo >= 6) {
        slideNo = 0;
    }
    showSlide();
}
function changeSlideStart() {
    slideTimer = setInterval(changeSlide, 3000);
}
function changeSlideStop() {
    clearInterval(slideTimer);
}
function selSlide(obj) {
    changeSlideStop();
    slideNo = parseInt(obj.innerHTML) - 1;
    showSlide();
}
changeSlideStart();