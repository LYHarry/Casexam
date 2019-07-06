
//管理员主页面jQuery文件

//退出提示
function quit() {
    if (confirm("您确定要退出吗？")) {
        window.open("../Manager/ManagerLogin.aspx", "_self");
    }
}

jQuery(function () {

    //导航切换
    jQuery("#leftmenu .title").click(function () {
        var $ul = jQuery(this).next("ul");
        jQuery("dd").find("ul").slideUp();
        if ($ul.is(":visible")) {
            jQuery(this).next("ul").slideUp();
        } else {
            jQuery(this).next("ul").slideDown();
        }
    });
})

