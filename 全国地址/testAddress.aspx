<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testAddress.aspx.cs" Inherits="TestAddress" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>测试全国地址</title>
    <style type="text/css">
        * {
            margin: 0;
            padding: 0;
            list-style: none;
            font-size: 15px;
            color: black;
        }

        .rea-warp {
            width: 100%;
            height: auto;
            text-align: center;
        }

            .rea-warp .name-warp {
                width: 100%;
                height: 30px;
                line-height: 30px;
                margin-bottom: 15px;
            }

                .rea-warp ul, .rea-warp .name-warp span {
                    width: 18%;
                    border: 1px solid blue;
                    float: left;
                }

                    .rea-warp ul.prov-warp {
                        clear: both;
                    }

                    .rea-warp ul li {
                        width: 100%;
                        height: 30px;
                        line-height: 30px;
                        border: 1px solid #d7d3d3;
                    }

        .act {
            background-color: #e6e6e6;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="rea-warp">
            <div class="name-warp">
                <span>省</span>
                <span>市</span>
                <span>区县</span>
                <span>乡镇</span>
                <span>街道</span>
            </div>

            <ul class="prov-warp">
                <asp:Repeater ID="prov_rep" runat="server">
                    <ItemTemplate>
                        <li provid="<%#Eval("area_province")%>"><%#Eval("area_name")%></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <ul class="city-warp">
            </ul>
            <ul class="dist-warp">
            </ul>
            <ul class="town-warp">
            </ul>
            <ul class="street-warp">
            </ul>
        </div>
        <div style="clear: both; height: 50px;"></div>
    </form>

    <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script type="text/javascript">

        $(function () {
            //省点击事件
            var parms = { action: "", code: "0", tags: "" };
            $("ul.prov-warp").find("li").on("click", function () {
                $(this).addClass("act").siblings("li").removeClass("act");
                $(".dist-warp,.town-warp,.street-warp").html("");
                parms.action = "city";
                var prov = $(this).attr("provid");
                parms.code = prov == "" || typeof (prov) == "undefined" ? "0" : prov;
                parms.tags = "city-warp";
                getAddress(parms);
            });
            //市点击事件
            $("ul.city-warp").find("li").die("click").live("click", function () {
                $(this).addClass("act").siblings("li").removeClass("act");
                $(".town-warp,.street-warp").html("");
                parms.action = "dist";
                var city = $(this).attr("code");
                parms.code = city == "" || typeof (city) == "undefined" ? "0" : city;
                parms.tags = "dist-warp";
                getAddress(parms);
            });
            //区县点击事件
            $("ul.dist-warp").find("li").die("click").live("click", function () {
                $(this).addClass("act").siblings("li").removeClass("act");
                $(".street-warp").html("");
                parms.action = "town";
                var city = $(this).attr("code");
                parms.code = city == "" || typeof (city) == "undefined" ? "0" : city;
                parms.tags = "town-warp";
                getAddress(parms);
            });
            //乡镇点击事件
            $("ul.town-warp").find("li").die("click").live("click", function () {
                $(this).addClass("act").siblings("li").removeClass("act");
                parms.action = "street";
                var city = $(this).attr("code");
                parms.code = city == "" || typeof (city) == "undefined" ? "0" : city;
                parms.tags = "street-warp";
                getAddress(parms);
            });
            //街道点击事件
            $("ul.street-warp").find("li").die("click").live("click", function () {
                console.log($(this).text());
            });
        });

        function getAddress(parms) {
            $.ajax({
                type: "get",
                url: "/testAddress.aspx",
                data: parms,
                dataType: "json",
                success: function (data) {
                    var res = "";
                    if (data != null && data.length > 0) {
                        for (var i = 0; i < data.length; i++) {
                            res += "<li code='" + data[i].code + "'>" + data[i].name + "</li>";
                        }
                    }
                    $("." + parms.tags).html(res);
                },
                error: function (msg) {
                    console.log(msg);
                }
            });
        }
    </script>
</body>
</html>
