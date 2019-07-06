<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AJAX应用</title>
    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
</head>

<body>

    <div>
        <input type="button" name="name" id="btn_demo1" value="AJAX调用无参方法" />
        <br />
        <br />
        <br />
        <input type="button" name="name" id="btn_demo2" value="AJAX调用有参方法" />
        <br />
        <br />
        <br />
        <input type="button" name="name" id="btn_demo3" value="AJAX调用返回数组" />
        <ul id="ulnum"></ul>
        <br />
        <br />
        <br />
        <input type="button" name="name" id="btn_demo4" value="AJAX调用返回对象Json字符串" />
    </div>

    <script type="text/javascript">
        $(function () {

            $.ajax({
                type: "get",
                //数据传输方式  默认get
                //POST和GET的区别
                // 1、GET方式会把数据附到url后，以?分割URL和传输数据，参数之间以&相连
                // 2、POST方式把提交的数据则放置在是HTTP包的包体中
                // 3、GET方式提交的数据较小，理论上POST没有限制，可传较大量的数据。
                //    注意:对数据有限制是指特定的浏览器及服务器对它的限制。URL本身是不存在参数上限的问题，HTTP协议规范也没有对URL长度进行限制。限制是限制整个URL长度，而不是参数值数据长度
                // 4、服务端获取GET请求参数用Request.QueryString，获取POST请求参数用Request.Form(获取页面上控件的值时，通过name来选择控件而不是通过ID),在JSP中用request.getParameter()来获取
                // 5、POST的安全性要比GET的安全性高
                url: "/Default2.aspx",
                // 提交（请求）的地址，为必须的参数，其他所有参数都可省略
                data: "",
                //提交的参数列表
                // 参数的提交方式
                // 1、直接跟在地址后面 如 Default2.aspx?action="abc"
                // 2、 data:"action=abc"
                // 3、data:{action:"abc",id:id}
                // 4、data:{"action":"abc"}
                dataType: "json",
                // 数据接收的类型（从服务端返回的数据类型）如果不指定，jQuery 将自动根据 HTTP 包 MIME 信息来智能判断
                // xml: 返回 XML 文档
                // html: 返回纯文本 HTML 信息，包含的 script 标签会在插入 dom 时执行。
                // script: 返回纯文本 JavaScript 代码。不会自动缓存结果。除非设置了 "cache" 参数
                // json: 返回 JSON 数据
                // jsonp: JSONP 格式。
                // text: 返回纯文本字符串
                // 注意：
                // 1、JSONP 格式。用于跨域请求，该方式必须在地址后面加callback=?或添加属性 jsonp: "jsonpCallback"，并且返回的数据格式要为context.Response.Write(callback + "({'rst':'abc'})")
                // 2、服务端返回的是JSON格式字符串时，可用$.parseJSON() 将其转换为对象
                // 3、服务端返回的是JSON格式字符串时，可省略dataType，如果把dataType设为json，可能会返回失败      
                // 4、POST不支持跨域，属性 crossdomain: true
                // JSONP格式时，后台返回时把Contenttype设为application/json也能返回成功
                cache: false,
                //设置页面缓存  默认为true
                contentType: "application/json; charset=utf-8",
                //内容编码类型
                async: true,
                //设置请求方式，是否为异常 默认为true
                beforeSend: function () {
                    //在发送请求之前调用，传入 XMLHttpRequest 作为参数。
                    //一般用于禁用按钮等，防止用户重复提交
                },
                dataFilter: function () {
                    //在请求成功之后调用。
                },
                success: function (data) {
                    //当请求成功并从服务端成功返回数据之后调用。传入从服务端返回后的数据
                },
                complete: function () {
                    //当请求完成之后调用这个函数，无论成功或失败。传入 XMLHttpRequest 对象，以及一个包含成功或错误代码的字符串。
                },
                error: function () {
                    //在请求出错时调用。传入 XMLHttpRequest 对象，描述错误类型的字符串以及一个异常对象
                }
            });


            $("#btn_demo1").click(function () {
                $.ajax({
                    type: "post", //必须为post方式
                    url: "/Default.aspx/AjaxSortCourse",
                    contentType: "application/json; charset=utf-8", //必须要添加
                    dataType: "json", //可省略
                    success: function (data) {
                        alert(data.d); //返回的数据通过data.d才能访问到
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
                //禁用按钮的提交 
                return false;
            });

            $("#btn_demo2").click(function () {
                $.ajax({
                    type: "post",
                    url: "/Default.aspx/AjaxSortCourse",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: "{type:54,num:98}",
                    success: function (data) {
                        alert(data.d);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
                //禁用按钮的提交 
                return false;
            });
            //说明：
            //1、data格式:
            //1.data:"{ key1:values1,key2:values2 }" 或 data: '{ "key1": values1, "key2": values}'
            //2.data:JSON.stringify({key1:values1,key2:values2}) 
            //如果调用时出错“无效的 JSON 基元”，则说明data格式输写错误。
            //2、JSON.stringify方法
            //用于从一个对象解析出字符串
            //例： var a = { a: 1, b: 2 }
            //JSON.stringify(a);  ==> "{"a":1,"b":2}"
            //3、JSON.parse方法
            //用于从一个字符串中解析出json对象
            //例： var str = '{"name":"hujian","age":"23"}'
            //JSON.parse(str); ==>  Object { name="huangxiaojian",  age="23"}
            //4、方法传参的写法一定要对，type为形参的名字,num为第二个形参的名字，且参数名称要和调用的方法的形参名称要一样。

            $("#btn_demo3").click(function () {
                $.ajax({
                    type: "post",
                    url: "/Default.aspx/AjaxSortCourse",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: "{max:11}",
                    success: function (data) {
                        var con = "";
                        $(data.d).each(function () {
                            con += "<li>" + this + "</li>";
                        });
                        $("#ulnum").html(con);
                        alert(data.d);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
                //禁用按钮的提交 
                return false;
            });


            $("#btn_demo4").click(function () {
                $.ajax({
                    type: "post",
                    url: "/Default.aspx/AjaxCourse",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify({
                        type: 3
                    }),
                    success: function (data) {

                        //把json格式字符串转换为对象
                        var res = $.parseJSON(data.d);
                        var con = "",
                            i = 1;
                        for (var item in res) {
                            con += "<li>" + res[i].name + "</li>";
                        }
                        $("#ulnum").html(con);
                        alert(data.d);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });
                //禁用按钮的提交 
                return false;
            });

        });
    </script>
</body>

</html>