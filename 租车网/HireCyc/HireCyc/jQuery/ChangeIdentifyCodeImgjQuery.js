//更换验证码图片jQuery文件

jQuery(function () {

    //点击图片本身更换
    jQuery(".randomCodeImg").click(function () {
        jQuery(this).attr("src", "../Share/IdentifyingCode.aspx?rnd='" + Math.random() + "'");
    });

    //点击更换验证码按钮
    jQuery(".refresh").click(function () {
        jQuery(".randomCodeImg").attr("src", "../Share/IdentifyingCode.aspx?rnd='" + Math.random() + "'");
    });



})

