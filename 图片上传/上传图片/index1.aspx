<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index1.aspx.cs" Inherits="UploadingFile.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>同时上传多张图片</title>
</head>
<body>
    <div>
        <span>上传图片：</span>
        <span id="img-warp">
            <img src="images/add.png" width="100" height="100" id="show-picture0" />
            <input type="file" id="fileUpload" multiple="multiple" name="fileUpload" accept="image/*" style="display: none;" />
        </span>
        <span id="loading" style="display: none;">
            <img src="images/uploading.gif" width="24" height="24" />&nbsp;&nbsp;正在处理中.....</span>
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
                url: '/index1.aspx', //用于文件上传的服务器端请求地址
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
                        //上传图片出错
                        if (typeof (data.length) == "undefined" && parseInt(data.status) == -1) {
                            alert(data.message);
                            return;
                        }
                        var res = "";
                        if (data.length > 0) {
                            for (var i = 0; i < data.length; i++) {
                                data[i].message = data[i].status == 1 ? data[i].message : "";
                                res += "<img src='" + data[i].message + "' width='100' height='100' alt='" + data[i].remark + "' />"
                            }
                        }
                        $("#img-warp").html(res);
                    }
                },
                complete: function () {
                    $("#loading").hide();
                },
                error: function (data, status, e) {
                    console.log(e);
                }
            }
		)
        }

        $(function () {
            //上传图片
            $("#show-picture0").click(function () {
                $("#fileUpload").click();
            });

            $("#fileUpload").on("change", function () {
                var files = $(this).val();
                if (files != "") {
                    ajaxUploadFile();
                }
            });
        });

    </script>
</body>
</html>
