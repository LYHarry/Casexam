/****
** 该方法页面需要已存在所在存放数据的框
**/
$(function () {

    //计算滚动条顶部位置
    function offsetTop(obj) {
        var height = $(window).height();
        return $('.' + obj).offset().top - height;
    }
    var loadOne = offsetTop('feature-product');
    var loadTwo = offsetTop('hot-shop');
    var loadThree = offsetTop('hot-market:eq(0)');
    var loadFour = offsetTop('hot-market:eq(1)');
    var loadFive = offsetTop('product-list-wrap:eq(0)');
    var loadSix = offsetTop('product-list-wrap:eq(1)');
    var loadSeven = offsetTop('product-list-wrap:eq(2)');
    var yang = 0;
    //触发事件
    function touchOn(index, callback) {
        if (yang == index) {
            callback();
            yang = index + 1;
        } else {
            return;
        }
    }
    $(window).scroll(function () {
        var scrolTop = $(window).scrollTop();
        if (scrolTop >= loadSeven) {
            touchOn(6, function () {
                // 
                // TODO
                //
            });
        } else if (scrolTop >= loadSix) {
            touchOn(5, function () {
                // 
                // TODO
                //
            });
        }
        else if (scrolTop >= loadFive) {
            touchOn(4, function () {
                // 
                // TODO
                //
            });
        } else if (scrolTop >= loadFour) {
            touchOn(3, function () {
                // 
                // TODO
                //
            });
        } else if (scrolTop >= loadThree) {
            touchOn(2, function () {
                // 
                // TODO
                //
            });
        } else if (scrolTop >= loadTwo) {
            touchOn(1, function () {
                // 
                // TODO
                //
            });
        } else if (scrolTop >= loadOne) {
            touchOn(0, function () {
                // 
                // TODO
                //
            });
        }
    });
});
