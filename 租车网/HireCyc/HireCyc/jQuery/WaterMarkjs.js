
//文本框水印javascript文件

//textbox  要设置水印的文本框
//str  水印文本

//文本框失去焦点时
function WMOnBlur(textbox, str) {
    if (textbox.value.length == 0) {
        textbox.style.color = "gray";
        textbox.value = str;
    }
}
//文本框得到焦点时
function WMOnfocus(textbox, str) {
    if (textbox.value == str) {
        textbox.style.color = "black";
        textbox.value = "";
    }
}
//密码文本框失去焦点时
function PawWMOnBlur(textbox, str) {
    if (textbox.value.length == 0) {
        textbox.type = "text";
        textbox.style.color = "gray";
        textbox.value = str;
    }
}


//密码文本框得到焦点时
function PawWMOnfocus(textbox, str) {
    if (textbox.value == str) {
        textbox.type = "password";
        textbox.style.color = "black";
        textbox.value = "";
    }
}

