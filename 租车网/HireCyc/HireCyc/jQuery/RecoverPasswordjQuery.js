
//找回密码jQuery文件

jQuery(function () {

    //点击找回密码方式打开相应网页

    jQuery("#mailGet").click(function () {
        window.open("MailMode.aspx", "_self");
    });

    jQuery("#phoneGet").click(function () {
        window.open("PhoneMode.aspx","_self");
    });
})

