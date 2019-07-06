//密码强度javascript文件

///打开文档，加载方法 
jQuery(document).ready(function () {
    pageLoad();
});

//页面加载初始化，以及鼠标事件的绑定
function pageLoad() {

    //文本框绑定事件
    jQuery('#passwordFrame').bind('keyup onfocus onblur', function () {

        var password = document.getElementById('passwordFrame');  //获取密码字符串

        var PawBox = document.getElementById("PWIntensityDiv");  //获取显示密码强度的DIV框

        if (password.value.length < 1) {   //如果密码长度小于1则隐藏密码强度框
            PawBox.className = "PWIntensity setClose";
        }
        else {
            PawBox.className = "PWIntensity setShow";
        }

        var ls = checkStrong(password.value);  //调用检查密码强度级别函数

        switch (ls) {
            case 0:    //弱 
            case 1:    //中 
            case 2:    //强 
            case 3:    //非常强
                showPwRank(ls);
                break;
            default:
                showPwRank(3);
        }
    });
}

//密码强度检测函数   计算出当前密码当中一共有多少种模式 
function checkStrong(Content) {
    var ls = 0;

    if (Content.length < 4) { return ls; }  //密码小于4位，级别为O

    if (Content.match(/[a-z]/g)) { ls++; }
    if (Content.match(/[A-Z]/g)) { ls++; }
    if (Content.match(/[0-9]/g)) { ls++; }
    if (Content.match(/[^a-zA-Z0-9]/g)) { ls++; }

    if (Content.length < 8 && ls > 1) { ls = 1; }

    if (ls > 3) { ls = 3; };

    if (ls > 3 && Content.length > 16) { ls = 3; }

    return ls;
}

//显示密码强度的状态 
function showPwRank(pwRank) {

    var obj = document.getElementById("IntenContent");//获取密码强度内容框 

    switch (pwRank) {
        case 0:
            {
                obj.className = "weak";
                obj.innerHTML = "弱";
            }
            break;
        case 1:
            {
                obj.innerHTML = "中";
                obj.className = "middle";
            } break;
        case 2:
            {
                obj.innerHTML = "强";
                obj.className = "strength";
            }
            break;
        case 3:
            {
                obj.innerHTML = "非常强";
                obj.className = "moreStrength";
            }
            break;
    }
}
