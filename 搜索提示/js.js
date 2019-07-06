$(function () {

    //搜索框
    var sdl = '.search-down-list';
    function upSlide(obj) {
        obj.next(sdl).slideUp();
    }
    function downSilde(obj) {
        obj.next(sdl).slideDown();
    }
    var searWord = $('.search-word');
    searWord.keyup(function () {
        var that = $(this).next(sdl);
        if (that.is(':animated')) {
            return;
        } else {
            if ($(this).val() == '') {
                upSlide($(this));
            } else {
                downSilde($(this));
            }
        }
    });
    searWord.focus(function () {
        if ($(this).val() == '') {
            upSlide($(this));
        } else {
            downSilde($(this));
        }
    }).blur(function () {
        upSlide($(this));
    });
    var downLi = $('.search-down-list li');
    downLi.die("click").live('click', function () {
        var text = $(this).children('span').text();
        searWord.val(text);
        wordClickGo(text);
    });

    //获取搜索关键字提示
    function searchKeywordsCue(word) {
        $.ajax({
            type: "get",
            url: "doAction/GetSearchCue.ashx?callback=?",
            data: { action: "searchCue", Keywords: word },
            jsonp: "callback",
            dataType: "jsonp",
            cache: false,
            success: function (dt) {
                var data = "";
                for (var i = 0; i < dt.rst.length; i++) {
                    data += "<li><span>" + dt.rst[i].sch_name + "</span><em>约" + dt.rst[i].sch_count + "个热搜</em></li>";
                }
                $(".search-down-list").html(data);
            },
            error: function (msg) {
            }
        });
    }


    //显示搜索关键字提示
    function ShowSearchKeywordsCue() {
        $(".search-word").focus(function () {
            var keywords = $(this).val();
            if ($.trim(keywords) != "") {
                searchKeywordsCue(keywords);
            }
        });
        $(".search-word").keyup(function (event) {
            if (event.keyCode == 38 || event.keyCode == 40) {
                return;
            }
            var keywords = $(this).val();
            if ($.trim(keywords) != "") {
                searchKeywordsCue(keywords);
            }
        });
    }


    //键盘
    function enterKeyGo(obj) {
        /**
         *	就这这个函数里写你的代码
         *  text是你点确认时选中的值
         */
        var text = getSearWordValue(obj);
        alert('你点击了确定，且你用上下选择了:“' + text + '”\n你的代码就在这里写');
        $.ajax({
            type: "get",
            url: "doAction/GetSearchCue.ashx?callback=?",
            data: { action: "addSearchKeyworedsNum", Keywords: res },
            jsonp: "callback",
            dataType: "jsonp",
            cache: false,
            success: function (data) {
                var gourl = "/Search.aspx?searchName=" + escape(res);
                window.location.href = gourl;
            },
            error: function (msg) {
            }
        });
    }

    function wordClickGo(text) {
        /**
         *	就这这个函数里写你的代码
         *  text是你点确认时选中的值
         */
        //alert(text);

        $.ajax({
            type: "get",
            url: "doAction/GetSearchCue.ashx?callback=?",
            data: { action: "addSearchKeyworedsNum", Keywords: res },
            jsonp: "callback",
            dataType: "jsonp",
            cache: false,
            success: function (data) {
                var gourl = "/Search.aspx?searchName=" + escape(res);
                window.location.href = gourl;
            },
            error: function (msg) {
            }
        });
    }

    var sdltag = $(sdl);
    var num = -1;
    function selfAddClass(obj) {
        obj.addClass('active');
        obj.siblings().removeClass('active');
    }
    function keyMove(obj, numAttr) {
        num += numAttr;
        if (num < 0)
            num = obj.length - 1;
        if (num > obj.length - 1)
            num = 0;
        selfAddClass(obj.eq(num));
    }
    function keyUpOrDown(obj, event) {
        var text = getSearWordValue(obj);
        if (text == '') {
            return;
        }
        if (event.keyCode == 38) {
            keyMove(obj, -1);
            setSearWordValue(obj);

        }
        if (event.keyCode == 40) {
            keyMove(obj, 1);
            setSearWordValue(obj);
        }
        if (event.keyCode == 13) {
            enterKeyGo(obj);
            sdltag.slideUp();
        }
    }
    sdltag.find('li').live('mouseover', function () {
        selfAddClass($(this));
        num = $(this).index();
    });
    searWord.each(function (event) {
        $(this).live('keyup', function (event) {
            var el = '.search-down-list';
            var sbl = $(this).siblings(el);
            var who = sbl.children('li');
            keyUpOrDown(who, event);
        });
    });
    function setSearWordValue(obj) {
        var parent = obj.parent();
        var wordInput = parent.siblings();
        var who = parent.find('.active span');
        var value = who.text();
        wordInput.val(value);
    }
    function getSearWordValue(obj) {
        var parent = obj.parent();
        var wordInput = parent.siblings();
        return wordInput.val();
    }


    //确认按钮回车搜索， gourl－－跳转的地址
    function enterSearch(gourl) {

        //正则表达式，只能输入汉字，字母，数字
        var reg = /^([\u4e00-\u9fa5]+)|([a-zA-Z0-9]+)$/;

        $("body").bind("keypress", function (even) {

            //判断输入框是否获取焦点
            var isFocus = $("#searchConTxt").is(":focus");

            if (isFocus) {
                var res = $("#searchConTxt").val();
                if (parseInt(even.keyCode) == 13) {
                    if ($.trim(res) == "") {
                        //分类列表页面，搜索为空时不提示
                        var damin = location.pathname;
                        damin = damin.substr(1, 6);
                        if (damin.toLowerCase() == "search") {
                            res = "";
                            window.location.href = gourl + res;
                            return;
                        } else {
                            $.CONFIRM('请输入搜索关键字!', function () {
                                $("#searchConTxt").focus();
                            });
                            return;
                        }
                    }
                    //验证是否输入特殊字符
                    if (!reg.test(res)) {

                        $.CONFIRM('请输入有效的关键字!', function () {
                            $("#searchConTxt").val('');
                            $("#searchConTxt").focus();
                        });
                        return;
                    }
                    else {  //增加搜索词的搜索次数
                        $.ajax({
                            type: "get",
                            url: "doAction/GetSearchCue.ashx?callback=?",
                            data: { action: "addSearchKeyworedsNum", Keywords: res },
                            jsonp: "callback",
                            dataType: "jsonp",
                            cache: false,
                            success: function (data) {
                                gourl = gourl + escape(res);
                                window.location.href = gourl;
                            },
                            error: function (msg) {
                            }
                        });
                    }
                }
            }
        });
    }

});