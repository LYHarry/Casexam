//index.js
//获取应用实例

let ctx;

Page({
  data: {
    size: 2,
    color: "#000000"
  },
  onLoad: function (options) {
    ctx = wx.createCanvasContext("myCanvas");
    ctx.setStrokeStyle(this.data.color);
    ctx.setLineWidth(this.data.size);
    ctx.setLineCap("round");
    ctx.setLineJoin("round");
  },
  TouchStart: function (e) {
    // console.log(e);
    ctx.setStrokeStyle(this.data.color);
    ctx.setLineWidth(this.data.size);
    ctx.moveTo(e.touches[0].x, e.touches[0].y);
  },
  TouchMove: function (e) {
    //console.log(e);
    let x = e.touches[0].x;
    let y = e.touches[0].y;
    ctx.lineTo(x, y);
    ctx.stroke();
    ctx.draw(true);
    ctx.moveTo(x, y);
  },
  SizeChange: function (e) {
    //console.log(e);
    let color = this.data.color;
    this.setData({
      size: e.target.dataset.parm,
      color: color == "#f8f8f8" ? "#000000" : color
    });
  },
  ColorChange: function (e) {
    //console.log(e);
    this.setData({
      size: 2,
      color: e.target.dataset.parm
    });
  },
  ClearCanvas: function (e) {
    //console.log(e);
    this.setData({
      size: 100,
      color: e.target.dataset.parm
    });
  }


})

