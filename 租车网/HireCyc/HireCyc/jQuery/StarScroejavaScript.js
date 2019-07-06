
//订单评价表星星评分等级javascript文件

window.onload = function () {

    CycStarScrore();  //调用车辆评分函数
    EmpStarScrore();  //调用员工评分函数
};

////车辆评分
function CycStarScrore() {

    var oStar = document.getElementById("star1");
    var aLi = oStar.getElementsByTagName("li");
    var oUl = oStar.getElementsByTagName("ul")[0];
    var i = iScore = iStar = 0;

    for (i = 1; i <= aLi.length; i++) {
        aLi[i - 1].index = i;

        //鼠标移过显示分数
        aLi[i - 1].onmouseover = function () {
            fnPoint(this.index);
        };

        //鼠标离开后恢复上次评分
        aLi[i - 1].onmouseout = function () {
            fnPoint();
        };

        //点击后进行评分处理
        aLi[i - 1].onclick = function () {
            iStar = this.index;
            document.getElementById("hid2").value = iStar;
        }
    }

    //评分处理
    function fnPoint(iArg) {
        //分数赋值
        iScore = iArg || iStar;
        for (i = 0; i < aLi.length; i++) {
            if (i < iScore) {
                aLi[i].innerHTML = "★";
                aLi[i].className = "on";
            }
            else {
                aLi[i].innerHTML = "☆";
                aLi[i].className = "";
            }
        }
    }
}


////员工评分
function EmpStarScrore() {

    var oStar = document.getElementById("star2");
    var aLi = oStar.getElementsByTagName("li");
    var oUl = oStar.getElementsByTagName("ul")[0];
    var i = iScore = iStar = 0;

    for (i = 1; i <= aLi.length; i++) {
        aLi[i - 1].index = i;

        //鼠标移过显示分数
        aLi[i - 1].onmouseover = function () {
            fnPoint(this.index);
        };

        //鼠标离开后恢复上次评分
        aLi[i - 1].onmouseout = function () {
            fnPoint();
        };

        //点击后进行评分处理
        aLi[i - 1].onclick = function () {
            iStar = this.index;
            document.getElementById("hid1").value = iStar;
        }
    }

    ////评分处理
    function fnPoint(iArg) {
        //分数赋值
        iScore = iArg || iStar;
        for (i = 0; i < aLi.length; i++) {
            if (i < iScore) {
                aLi[i].innerHTML = "★";
                aLi[i].className = "on";
            }
            else {
                aLi[i].innerHTML = "☆";
                aLi[i].className = "";
            }
        }
    }
}


