
//公用javascript文件

//================================个人信息，管理员注册页面====================================

//得到省份
function GetProv(select) {
    document.getElementById("GetAdd").value = select.value + "省";
}
//得到市
function GetCity(select) {
    document.getElementById("GetAdd").value += select.value + "市";
}
//得到地区，县
function GetDist(select) {
    document.getElementById("GetAdd").value += select.value;
}


//================================自行车图片列表jQuery文件================================

jQuery(function () {
    //显示购物蓝
    jQuery("#shopBut").click(function () {
        //获取购物车里面的车辆名称
        var VAL = document.getElementById("aiko").rows[1].cells[1];  
       
        if (VAL.innerHTML == "")      
            alert("购物车为空!");       
        else
            jQuery("#shopCart").slideToggle();        
    }); 
})