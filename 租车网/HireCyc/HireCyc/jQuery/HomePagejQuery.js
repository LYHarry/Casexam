//主页面jQuery文件

jQuery(function () {
    //鼠标移进导航条改变背景颜色
    jQuery(".topNav ul li").mouseenter(function () {
        jQuery(this).css("background-color", "#a80d27");
    });
    jQuery(".topNav ul li").mouseleave(function () {
        jQuery(this).css("background-color", "#c61a37");

    });

    //鼠标移进联系我们面板改变背景颜色
    jQuery(".panelStyle tr td").mouseenter(function () {
        jQuery(this).css("background-color", "white");
    });
    jQuery(".panelStyle tr td").mouseleave(function () {
        jQuery(this).css("background-color", "rgba(195, 186, 186, 0.37)");

    });

    //鼠标移进联系我们，显示QQ,电话，面板
    jQuery("#Image3").mouseenter(function () {
        jQuery(".QQPanel").css("display", "block");
    });
    jQuery(".QQPanel").mouseleave(function () {
        jQuery(this).css("display", "none");
    });
    jQuery("#Image4").mouseenter(function () {
        jQuery(".phonePanel").css("display", "block");
    });
    jQuery(".phonePanel").mouseleave(function () {
        jQuery(this).css("display", "none");
    });

    //更换QQ联系人
    var index = 0;
    var image = new Array("../Images/other/13031Q55113-7.jpg", "../Images/other/13031Q55113-8.jpg", "../Images/other/13031Q55113-9.jpg", "../Images/other/136538773362.jpg");
    var num = new Array("919793260", "471882784", "840558103", "1132726943");
    setInterval(function () { //定时器，每五秒更换一次联系人
        var href = "http://wpa.qq.com/msgrd?v=3&uin=" + num[index] + "&site=qq&menu=yes";
        var imgSrc = "http://wpa.qq.com/pa?p=2:" + num[index] + ":51";
        jQuery("#QQPanelImg").attr("src", image[index]);
        jQuery("#QQSessionHref").attr("href", href);
        jQuery("#QQSession").attr("src", imgSrc);
        index++;
        if (index == 4)
            index = 0;
    }, 5000);


    //左边导航条随滚动条滚动    
    var leftNavTop = parseInt(jQuery(".leftNav").offset().top); //得到左边导航条TOP坐标
    jQuery(window.document).scroll(function () { //滚动条事件
        var top = parseInt(document.documentElement.scrollTop); //得到滚动条TOP坐标
        var lestTop = leftNavTop + top;
        jQuery(".leftNav").animate({ top: lestTop + "px" }, { duration: 500, queue: false });
    });


    //返回顶部
    jQuery(window.document).scroll(function () {
        var top = document.documentElement.scrollTop;
        if (top > 10) {
            jQuery(".goTop").css("display", "block");

            jQuery(".goTop").mouseenter(function () {
                jQuery(".goTop").css("cursor", "pointer");
                jQuery(".goTop").css("background-color", "rgba(195, 186, 186, 0.37)");
                jQuery(".goTop span").html("返回<br />顶部");
                jQuery(".goTop span").css("padding-top", "10px");

            });

            jQuery(".goTop").mouseleave(function () {
                jQuery(".goTop").css("background-color", "rgba(195, 186, 186, 0.37)");
                jQuery(".goTop span").html('<img src="../Images/other/GoTop.png" width="50" height="50" />');
                jQuery(".goTop span").css("padding-top", "0");
            });

            jQuery(".goTop").click(function () {
                document.documentElement.scrollTop = 0;
            });
        } else {
            jQuery(".goTop").css("display", "none");
        }
    });
});
