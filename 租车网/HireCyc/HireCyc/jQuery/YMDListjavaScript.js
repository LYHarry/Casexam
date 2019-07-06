window.onload = function () {
    MonHead = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];  //保存每个月的天数

    //先给年下拉框赋内容
    var year = document.getElementById("YYYY");
    var y = new Date().getFullYear();

    for (var i = y; i >= 1890; i--) {
        var opt = document.createElement("option");
        opt.value = i;
        opt.innerText = i;
        year.appendChild(opt);
    }
    var n = MonHead[new Date().getMonth()];   //得到当前月的天数
}

//年发生变化时日期发生变化(主要是判断闰平年)
function YYYYMM(str) {
    writeMonth();   //调用函数给月份的下拉框赋值

    //得到选择的月份
    var MMvalue = document.getElementById("MM").options[document.getElementById("MM").selectedIndex].value;

    if (MMvalue == "") {
        document.getElementById("DD").length = 1;
        return;
    }
    var n = MonHead[MMvalue - 1];
    if (MMvalue == 2 && IsPinYear(str)) n++;
    writeDay(n);  //调用赋天数的函数
}

//月发生变化时日期联动  
function MMDD(str) {
    //得到选择的年份
    var YYYYvalue = document.getElementById("YYYY").options[document.getElementById("YYYY").selectedIndex].value;

    if (str == "") {
        document.getElementById("DD").length = 1;
        return;
    }
    var n = MonHead[str - 1];
    if (str == 2 && IsPinYear(YYYYvalue)) n++;
    writeDay(n);  //调用赋天数的函数
}

//按条件赋值日期的下拉框
function writeDay(n) {
    document.getElementById("DD").length = 1;  //清除以前的节点，重新添加

    var day = document.getElementById("DD");
    for (var i = 1; i < (n + 1) ; i++) {
        var opt = document.createElement("option");
        opt.value = i;
        opt.innerText = i;
        day.appendChild(opt);
    }
}

//判断是否闰平年  
function IsPinYear(year) {
    return (0 == year % 4 && (year % 100 != 0 || year % 400 == 0))
}

//赋月份的下拉框 
function writeMonth() {
    document.getElementById("MM").length = 1;  //清除以前的节点，重新添加

    var month = document.getElementById("MM");
    for (var i = 1; i < 13; i++) {
        var opt = document.createElement("option");
        opt.value = i;
        opt.innerText = i;
        month.appendChild(opt);
    }
}