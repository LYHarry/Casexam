
var nowLiIndex = 1; //当前LI下标

$(function () {

    var body = document.getElementsByTagName("body")[0];
    var numer = body.getBoundingClientRect();
    var bodyWid = Math.floor(numer.width * 0.88);

    console.log("bodyw：" + bodyWid + " bodyH：" + Math.floor(numer.height * 0.52));

    var boxLiBtn = $(".box-warp li");
    var prevBtn = $(".prev")[0],
    nextBtn = $(".next")[0];

    //设置高度
    $(".box-warp ul").css({ height: (boxLiBtn.height() + 25) });

    //初始化位置
    init();
    function init() {
        boxLiBtn.each(function () {
            var wid = Math.floor(bodyWid * 0.5);
            boxLiBtn.eq(0).stop().animate({
                width: wid,
                left: -Math.floor(wid * 0.75),
                top: Math.floor(wid / 4)
            }, "slow").css({ "zIndex": 10 });

            boxLiBtn.eq(1).stop().animate({
                left: Math.floor(wid / 2.5),
                top: 10
            }, "slow").css({ "zIndex": 20 });

            if ($(this).index() > 1) {
                $(this).stop().animate({
                    width: wid,
                    left: (bodyWid * ($(this).index() - 1)),
                    top: Math.floor(wid / 4)
                }, "slow").css({ "zIndex": 10 });
            }
        });
    };

    //nextBtn.addEventListener('click', nextFun, false);
    //prevBtn.addEventListener('click', prevFun, false);

    var timer = setInterval(prevFun, 10000);
    $(".box-warp")[0].onmouseover = function () {
        clearInterval(timer);
    };
    $(".box-warp")[0].onmouseout = function () {
        timer = setInterval(prevFun, 10000);
    };

    //向右滑动按钮
    function nextFun() {

        console.log("向右");
        nowLiIndex--;
        if (nowLiIndex < 0) { nowLiIndex = boxLiBtn.length - 1; }
        var prevLi = boxLiBtn.eq(nowLiIndex).next().index();
        var nextLi = boxLiBtn.eq(nowLiIndex).prev().index();
        if (prevLi <= 0) { prevLi = 0; }
        if (nextLi < 0) { nextLi = boxLiBtn.length - 1; }

        moveBanner(nextLi, nowLiIndex, prevLi);
    };

    //向左滑动按钮
    function prevFun() {

        console.log("向左");
        nowLiIndex++;
        if (nowLiIndex > boxLiBtn.length - 1) { nowLiIndex = 0; }
        var prevLi = boxLiBtn.eq(nowLiIndex).prev().index();
        var nextLi = boxLiBtn.eq(nowLiIndex).next().index();
        if (prevLi < 0) { prevLi = boxLiBtn.length - 1; }
        if (nextLi <= 0) { nextLi = 0; }

        moveBanner(prevLi, nowLiIndex, nextLi);
    };

    //移动动画
    function moveBanner(prevSub, nowSub, nextSub) {

        console.log("prevLI：" + prevSub + " nowLI：" + nowSub + " nextLI：" + nextSub);

        boxLiBtn.css({ "zIndex": 0 });
        var wid = Math.floor(bodyWid * 0.5);
        //下一个
        boxLiBtn.eq(prevSub).stop().animate({
            width: wid,
            left: -Math.floor(wid * 0.75),
            top: Math.floor(wid / 4)
        }, "slow").css({ "zIndex": 10 });

        //当前这一个
        boxLiBtn.eq(nowSub).stop().animate({
            width: "65%",
            left: Math.floor(wid / 2.5),
            top: 10
        }, "slow").css({ "zIndex": 20 });

        //上一个
        boxLiBtn.eq(nextSub).stop().animate({
            width: wid,
            left: bodyWid,
            top: Math.floor(wid / 4)
        }, "slow").css({ "zIndex": 10 });
    };

    //滑动
    isTouchDevice();

    //touchstart事件
    function touchSatrtFunc(evt) {
        try {
            //evt.preventDefault(); //阻止触摸时浏览器的缩放、滚动条滚动等
            var touch = evt.touches[0]; //获取第一个触点
            var x = Number(touch.pageX); //页面触点X坐标
            var y = Number(touch.pageY); //页面触点Y坐标
            //记录触点初始位置
            startX = x;
            startY = y;
            touchchange = 0;
            clearInterval(timer);
        } catch (e) {
            alert('touchSatrtFunc：' + e.message);
        }
    };

    //touchmove事件，这个事件无法获取坐标
    var touchchange = 0;
    function touchMoveFunc(evt) {
        touchchange = 0;
        try {
            //evt.preventDefault(); //阻止触摸时浏览器的缩放、滚动条滚动等
            var touch = evt.touches[0]; //获取第一个触点
            var x = Number(touch.pageX); //页面触点X坐标
            var y = Number(touch.pageY); //页面触点Y坐标

            //console.log(x - startX);
            if (x - startX > 70) {
                touchchange = 1;
                //console.log("向右");
            } else if (x - startX < -70) {
                //console.log("向左");
                touchchange = 2;
                //swipeLeft();//你自己的方法
            }
        } catch (e) {
            // alert('touchMoveFunc：' + e.message);
        }
    };

    //touchend事件
    function touchEndFunc(evt) {
        timer = setInterval(prevFun, 10000);
        if (touchchange === 2) {
            prevFun();
        } else if (touchchange === 1) {
            nextFun();
        }
        try {
            // evt.preventDefault(); //阻止触摸时浏览器的缩放、滚动条滚动等
        } catch (e) {
            alert('touchEndFunc：' + e.message);
        }
    };

    //绑定事件
    function bindEvent(box) {
        box.addEventListener('touchstart', touchSatrtFunc, false);
        box.addEventListener('touchmove', touchMoveFunc, false);
        box.addEventListener('touchend', touchEndFunc, false);
    };

    //判断是否支持触摸事件
    function isTouchDevice() {
        // document.getElementById("version").innerHTML = navigator.appVersion;
        try {
            document.createEvent("TouchEvent");
            // alert("支持TouchEvent事件！");
            var box = document.getElementsByClassName("list-warp")[0];
            bindEvent(box); //绑定事件
        } catch (e) {
            // alert("不支持TouchEvent事件！" + e.message);
        }
    };

});