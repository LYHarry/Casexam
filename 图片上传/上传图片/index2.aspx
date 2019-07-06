<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="UploadingFile.index2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>先浏览图片，再上传单张图片</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span>上传图片：</span>
            <span id="img-warp">
                <img src="images/add.png" width="100" height="100" id="show-picture0" />
                <input type="file" id="fileUpload" name="fileUpload" accept="image/*" style="display: none;" />
            </span>
            <input type="button" value="上传" id="uploadFileBtn" />
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="js/localResizeIMG.js"></script>
    <script type="text/javascript">

        $("#show-picture0").on("click", function () {
            $("#fileUpload").click();
        });

        $(function () {
            $('#fileUpload').localResizeIMG({
                width: 680,
                quality: 0.9,//0.8 1为不压缩
                before: function (that, blob) {
                    //var file = that.files[0];
                    //if (file.size > (2 * 1024 * 1024)) {
                    //    alert("上传的图片过大，只能有2M");
                    //    return;
                    //}
                },
                success: function (result) {
                    $('#show-picture0').attr("src", result.base64);
                }
            });

            $("#uploadFileBtn").on("click", function () {
                var upimg0 = $('#show-picture0').attr("src");
                if (upimg0.length > 10) {
                    $.ajax({
                        type: "post",
                        url: "/index2.aspx",
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
        });

    </script>


</body>
</html>
