
//选择显示的数据

var rowId = "";  //用于保存选中行的名称
var f = false;  //用于保存行是否被选中


//单击选择全部行
function selectAll() {
    var all = document.getElementById("check");
    var input = document.getElementsByTagName("input");
    var tr = document.getElementsByTagName("tr");
    //选择所有的多选按钮
    for (var j = 0; j < input.length; j++) {
        if (input[j].type == 'checkbox') {
            if (all.checked) {
                f = true;
                input[j].checked = true;
            }
            else {
                f = false;
                input[j].checked = false;
            }
        }
    }
    //选择所有行
    for (var i = 1; i < tr.length; i++) {
        if (all.checked) {
            rowId += tr[i].id + ",";
            tr[i].setAttribute("style", "background-color:#f0f0f0");
        }
        else {
            rowId = "";
            tr[i].setAttribute("style", "background-color:none");
        }
    }
}


//单击选择本行
function selectRow(num) {
    num = num.trim();
    var b = document.getElementById(num);
    var c = num + "1";
    var m = document.getElementById(c);

    if (m.checked) {
        f = true;
        rowId += b.id + ",";
        b.setAttribute("style", "background-color:#f0f0f0");
    }
    else {
        rowId = rowId.trim().substring(0, rowId.length - 1);
        var rw = rowId.split(",");
        var w = "";
        for (var i = 0; i < rw.length; i++) {
            if (rw[i] != b.id)
                w += rw[i] + ",";
        }
        rowId = w;
        f = false;
        b.setAttribute("style", "background-color:none");
    }
}

//根据名称删除信息
function DelData(type) {
    //有行被选中，就执行删除
    if (f) {
        if (confirm("确定要删除吗？")) {
            var row = rowId.trim().substring(0, rowId.length - 1);
            row = encodeURI(row);   //进行编码，解决中文乱码
            ajax("../Share/Handler.ashx?Type=" + type + "&&id=" + row, function (resText) {
                if (resText) {
                    alert("删除成功!");
                    window.location.reload();  //刷新当前页面
                }
            });
        }
    }
}


//根据ID删除信息
function DelDataId(type) {
    //有行被选中，就执行删除
    if (f) {
        if (confirm("确定要删除吗？")) {
            var row = rowId.trim().substring(0, rowId.length - 1);
            row = encodeURI(row);   //进行编码，解决中文乱码
            ajax("../Share/Handler2.ashx?Type=" + type + "&&id=" + row, function (resText) {
                if (resText) {
                    alert("删除成功!");
                    window.location.reload();  //刷新当前页面
                }
            });
        }
    }
}