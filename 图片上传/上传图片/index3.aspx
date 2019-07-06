<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index3.aspx.cs" Inherits="UploadingFile.index3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>先浏览图片，再上传多张图片</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>上传图片：</span>
            <span id="img-warp">
                <img src="images/add.png" width="100" height="100" id="show-picture0" />
                <!--capture="camera"，用于手机支持打开照相功能，IOS默认打开照相机功能-->
                <!--accept="image/*"，表示只接收图片文件-->
                <!--image/* 在Google谷歌浏览中，弹出文件选择框会很慢，建议用(image/png,imgage/jpge,image/jpg) -->
                <!--multiple="multiple"，表示可能多选上传的图片-->
                <input type="file" id="fileUpload" multiple="multiple" name="fileUpload" accept="image/*" style="display: none;" />
            </span>
            <input type="button" value="上传" id="uploadFileBtn" />
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="js/localResizeIMG2.js"></script>
    <script type="text/javascript">

        $("#show-picture0").on("click", function () {
            $("#fileUpload").click();
        });

        $(function () {
            $('#fileUpload').localResizeIMG({
                width: 680,
                quality: 0.9,//0.8 1为不压缩
                before: function (that, blob) { },
                success: function (result) {
                    var resimg = "";
                    if (typeof (result) != "undefined" && typeof (result.length) != "undefined" && result.length > 0) {
                        for (var i = 0; i < result.length; i++) {
                            resimg += "<img src='" + result[i].base64 + "' width='100' height='100' />";
                        }
                    }
                    $('#img-warp').html(resimg);
                }
            });

            $("#uploadFileBtn").on("click", function () {
                var upimgs = [];
                $('#img-warp').find("img").each(function () {
                    upimgs.push({ base64: $(this).attr("src") });
                });
                if (upimgs.length > 0) {
                    $.ajax({
                        type: "post",
                        url: "/index3.aspx",
                        data: { action: "upimg", imgbits: JSON.stringify(upimgs), t: Math.random(), path: "comment" },
                        cache: false,
                        dataType: "json",
                        success: function (data) {
                            if (typeof (data) != "undefined" && data.length > 0) {
                                for (var m = 0; m < data.length; m++) {
                                    alert("上传成功：\n" + data[m].message);
                                }
                            }
                        },
                        error: function (msg) {
                            alert('上传发生异常，可能是图片太大，请刷新页面或者重新选择图片！');
                        }
                    });
                }
            });
        });

    </script>


</body>
</html>
