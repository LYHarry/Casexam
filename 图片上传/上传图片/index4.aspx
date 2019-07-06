<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index4.aspx.cs" Inherits="UploadingFile.index4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>利用FileReader接口先浏览图片，再上传单张图片</title>
</head>
<body>
    <div>
        <span>上传图片：</span>
        <span>
            <img src="images/add.png" width="100" height="100" id="show-picture0" />
            <input type="file" id="fileUpload" name="fileUpload" accept="image/*" style="display: none;" />
        </span>
        <input type="button" value="上传" id="uploadFileBtn" style="display: none;" />
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="js/ajaxfileupload.js"></script>
    <script type="text/javascript">
        //上传图片
        function ajaxUploadFile() {
            $("#loading").ajaxStart(function () {
                $(this).show();
            })//开始上传文件时显示一个图片
            .ajaxComplete(function () {
                $(this).hide();
            }); //文件上传完成将图片隐藏起来

            $.ajaxFileUpload({
                type: "get",
                url: '/index4.aspx', //用于文件上传的服务器端请求地址
                secureuri: false, // 是否需要安全协议，一般设置为false
                cache: false, //是否缓存
                data: { action: "uploadimg", folder: "comment", t: Math.random() },
                fileElementId: 'fileUpload', //文件上传空间的id属性  <input type="file" id="file" name="file" />
                dataType: 'json', //返回值类型 一般设置为json
                beforeSend: function () {
                    $("#loading").show();
                },
                success: function (data) {
                    //从服务器返回的json中取出message中的数据
                    if (typeof (data) != 'undefined' && data != null) {
                        if (data.status != 1) {
                            alert(data.message);
                            return;
                        } else {
                            $("#show-picture0").attr("src", data.message);
                        }
                    }
                },
                complete: function () {
                    $("#loading").hide();
                },
                error: function (data, status, e) {
                    console.log(e);
                }
            });
        }

        //上传图片
        $("#uploadFileBtn").on("click", function () {
            var upimg0 = $('#show-picture0').attr("src");
            if (upimg0.length > 10) {
                $.ajax({
                    type: "post",
                    url: "/index4.aspx",
                    data: { action: "upimg", imgbit0: upimg0, t: Math.random(), path: "comment" },
                    cache: false,
                    dataType: "json",
                    success: function (data) {
                        //data = $.parseJSON(data);
                        if (data != null && parseInt(data.status) == 1) {
                            alert("上传成功：\n" + data.message);
                        }
                    },
                    error: function (msg) {
                        alert('上传发生异常，可能是图片太大，请刷新页面或者重新选择图片！');
                    }
                });
            }
        });

        $(function () {
            //上传图片
            $("#show-picture0").click(function () {
                $("#fileUpload").click();
            });

            /* 
             * 通过FileReader接口实现上传图片浏览             
             * 如果浏览器支持FileReader接口则先浏览再上传图片，
             * 否则使用ajaxfileupload.js上传图片
             * 操作方法文档：http://blog.csdn.net/zk437092645/article/details/8745647
            */
            $("#fileUpload").on("change", function (ev) {
                var files = $(this).val();
                if (files != "") {
                    //判断浏览器是否支持FileReader接口
                    if (typeof (FileReader) == 'undefined') {
                        console.log("你的浏览器不支持FileReader接口！");
                        //使用ajaxfileupload.js上传图片
                        ajaxUploadFile();
                    } else {
                        var reader = new FileReader();
                        reader.readAsDataURL(this.files[0]);
                        reader.onload = function (e) {
                            //显示文件
                            $('#show-picture0').attr("src", this.result);
                            $("#uploadFileBtn").show();
                        }
                    }
                }
            });
        });

    </script>
</body>
</html>
