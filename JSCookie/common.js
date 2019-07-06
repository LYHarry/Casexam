
/***
  ** 作用： JS Cookie操作帮助公共类
  **
  ***/
Utility = {
    /***
      ** 作用： 得到Cookie
      ** name：cookie名称
      **
     ***/
    getCookie: function (name) {
        var c_start = -1, c_end = -1;
        if (document.cookie.length > 0) {
            c_start = document.cookie.indexOf(name + "=")
            if (c_start != -1) {
                c_start = c_start + name.length + 1
                c_end = document.cookie.indexOf(";", c_start)
                if (c_end == -1) c_end = document.cookie.length
                return unescape(document.cookie.substring(c_start, c_end))
            }
        }
        return ""
    },
    /***
      ** 作用： 设置Cookie
      ** name：cookie名称
      ** value：值
      ** time：过期时间
      ** path：存放路径
      **
     ***/
    setCookie: function (name, value, time, path) {
        Utility.delCookie(name)
        if (!time)
            time = 30;
        if (!path)
            path = "/"
        var exp = new Date();
        exp.setTime(exp.getTime() + time * 24 * 60 * 60 * 1000);
        window.document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=" + path + ";";
    },
    /***
      ** 作用： 删除Cookie
      ** name：cookie名称
      **
     ***/
    delCookie: function (name) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = Utility.getCookie(name);
        if (cval != null)
            document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();

    },
    /***
      ** 作用： 格式化时间
      ** timeStr：时间
      ** 说明：格式化失败，返回当前时间
      **
     ***/
    getTime: function (timeStr) {
        var time = new Date(timeStr);
        if (typeof (time) != "object" || isNaN(time.getFullYear()))
        { time = new Date(); }
        var year = time.getFullYear();
        var month = time.getMonth() + 1 < 10 ? "0" + (time.getMonth() + 1) : (time.getMonth() + 1);
        var date = time.getDate() < 10 ? "0" + time.getDate() : time.getDate();
        return year + "-" + month + "-" + date
    },
    /***
      ** 作用： 解析异步返回的时间格式    
      ** timeStr：时间
      ** 说明：时间类型经过异步调用返回时会变成乱码
      ** 格式化失败，返回当前时间
      **
     ***/
    getAsynTime: function (timeStr) {
        var date = new Date(parseInt(timeStr.replace("/Date(", "").replace(")/", ""), 10));
        if (typeof (date) != "object" || isNaN(date.getFullYear()))
        { date = new Date(); }
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : (date.getMonth() + 1);
        var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        var sec = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
        return date.getFullYear() + "-" + month + "-" + currentDate;
    }
};