
//==============================个人信息页面=================================

//上传图片按钮
$(function () {
    new AjaxUpload(document.getElementById("uploadBut"), {
        action: "Handler3.ashx",
        name: "file",
        onSubmit: function (file, ext) {
            if (!(ext && /^(jpg|jpeg|JPG|JPEG|bmp|BMP|gif|GIF|png|PNG)$/.test(ext))) {
                alert('图片格式不正确,请选择 jpg、bmp、gif、png 格式的文件!', '系统提示');
                return false;
            }
        }, onComplete: function (file, response) {
            this.enable();
            $('#perImg').attr('src', response);
            $('#SampHun').attr('src', response);
            $('#SampFif').attr('src', response);
        }
    });
});
