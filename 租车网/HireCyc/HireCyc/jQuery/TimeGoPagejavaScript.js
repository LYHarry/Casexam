
//倒记时，跳转到另一个页javascript文件

//获取当前时间  
clockStart = new Date().getTime();
//获取两次当前的时间，用于计算间隔
function initStopwatch() {
    var timeNow = new Date().getTime();
    var timeDiff = timeNow - clockStart;       //获取间隔时间
    this.diffSecs = timeDiff / 1000;         //因为时间以毫秒为单位  
    return (this.diffSecs);                     //返回间隔秒数
}

//显示倒计时时间
function getSecs(time) {
    var mySecs = initStopwatch();
    mySecs = time - parseInt(mySecs);
    document.getElementById("time").textContent = mySecs;  //把时间赋给label，显示倒记时
    window.setTimeout("getSecs(10)", 500);
}

//打开新页面
function openNewPage(url) {
    window.open(url, "_self");
}

setTimeout("openNewPage('QuestionList.aspx')", 9500);   //记时，跳转到另一个页面

setTimeout("getSecs(10)", 1);   //记时，显示倒记时