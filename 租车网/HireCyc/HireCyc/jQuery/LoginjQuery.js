//登陆jQuery文件

jQuery(function () {
    //鼠标移进个人主页改变背景颜色
    jQuery("#loginSubmit").mouseenter(function () {
        jQuery(this).css("background-color", "#c00d0e");
        jQuery(this).css("cursor", "pointer");

    });
    jQuery("#loginSubmit").mouseleave(function () {
        jQuery(this).css("background-color", "#FF6600");

    });

    //点击更换验证码图片
    jQuery(".randomCodeImg").click(function () {
        jQuery(this).attr("src", "../Share/IdentifyingCode.aspx?rnd='" + Math.random() + "'");
    });
});