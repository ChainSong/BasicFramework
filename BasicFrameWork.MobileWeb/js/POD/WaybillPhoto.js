
//图片上传预览    IE是用了滤镜。
function previewImage(file) {
    //preview
    //window.screen.width ;
    //window.screen.height;
 
    var MAXWIDTH = window.screen.width;
    var MAXHEIGHT = window.screen.height;
    var div = document.getElementById('preview');
    if (file.files && file.files[0]) {
        div.innerHTML = '<img id=imghead>';
        var img = document.getElementById('imghead');
        img.onload = function () {
            var rect = clacImgZoomParam(MAXWIDTH, MAXHEIGHT, img.offsetWidth, img.offsetHeight);
            img.width = rect.width;
            img.height = rect.height;
            //                 img.style.marginLeft = rect.left+'px';
           // img.style.marginTop = rect.top + 'px';
        }
        var reader = new FileReader();
        reader.onload = function (evt) { img.src = evt.target.result; }
        reader.readAsDataURL(file.files[0]);
    }
    else //兼容IE


    {
        var sFilter = 'filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale,src="';
        file.select();
        var src = document.selection.createRange().text;
        div.innerHTML = '<img id=imghead>';
        var img = document.getElementById('imghead');
        img.filters.item('DXImageTransform.Microsoft.AlphaImageLoader').src = src;
        var rect = clacImgZoomParam(MAXWIDTH, MAXHEIGHT, img.offsetWidth, img.offsetHeight);
        status = ('rect:' + rect.top + ',' + rect.left + ',' + rect.width + ',' + rect.height);
        div.innerHTML = "<div id=divhead style='width:" + rect.width + "px;height:" + rect.height + "px;margin-top:" + rect.top + "px;" + sFilter + src + "\"'></div>";
    }
}
function clacImgZoomParam(maxWidth, maxHeight, width, height) {
    var param = { top: 0, left: 0, width: width, height: height };
    if (width > maxWidth || height > maxHeight) {
        rateWidth = width / maxWidth;
        rateHeight = height / maxHeight;

        if (rateWidth > rateHeight) {
            param.width = maxWidth;
            param.height = Math.round(height / rateWidth);
        } else {
            param.width = Math.round(width / rateHeight);
            param.height = maxHeight;
        }
    }

    param.left = Math.round((maxWidth - param.width) / 2);
    param.top = Math.round((maxHeight - param.height) / 2);
    return param;
}
document.getElementById("ChoosPicture").addEventListener("click", function () {
    document.getElementById("file").click();

})

document.getElementById("upload").addEventListener("click", function () {
    var canvas = document.getElementById('imghead').src;
   
   var b64 = canvas.substring(23);

    $.ajax({
        type: 'post',
        url: '/POD/WaybillPhoto',
        data: {
            img: b64,
            id: $("#Info_CustomerOrderNumber").val()

        },
        cache: false,
        //dataType: 'json',
        success: function (data) {
          
            if (data=="True") {
                showMsg("上传成功！", 2000);
            } else {
                showMsg("上传失败！", 2000);
            }
              
           
            //if (data.orderManagementInfo.length > 0) {
            //    $("#PageIndex").val(data.PageIndex);
            //    var html = $("#Evaluation").render(data.orderManagementInfo);
            //    //$("#datas")["empty"]();
            //    $("#dataList")["append"](html);
            //}
            //else {
            //    showMsg("没有数据！", 2000);
            //}
        },
        error: function (err) {
            showMsg(err.Massage, 3000);
        }
    });

});












//// 设置事件监听，DOM内容加载完成，和jQuery的$.ready() 效果差不多。
//window.addEventListener("DOMContentLoaded", function () {
//    // canvas 元素将用于抓拍
//    var canvas = document.getElementById("canvas"),
//        context = canvas.getContext("2d"),
//        // video 元素，将用于接收并播放摄像头 的数据流
//        video = document.getElementById("video"),
//        videoObj = { "video": true },
//        // 一个出错的回调函数，在控制台打印出错信息
//        errBack = function (error) {
//            if ("object" === typeof window.console) {
//                console.log("Video capture error: ", error.code);
//            }
//        };
//    // Put video listeners into place
//    // 针对标准的浏览器
//    if (navigator.getUserMedia) { // Standard
//        navigator.getUserMedia(videoObj, function (stream) {
//            video.src = stream;

//            video.play();
//        }, errBack);
//    } else if (navigator.webkitGetUserMedia) { // WebKit-prefixed
//        navigator.webkitGetUserMedia(videoObj, function (stream) {

//            video.src = window.webkitURL.createObjectURL(stream);
//            video.play();
//        }, errBack);
//    }
//    // 对拍照按钮的事件监听
//    var wid = window.screen.availWidth * 0.95;
//    document.getElementById("TakingPictures").addEventListener("click", function () {

//        if (this.innerText.trim() == "拍照") {
//            $("#canvas").show();
//            $("#video").hide();
//            document.getElementById("TakingPictures").innerHTML = '发送';
//            // 画到画布上
//            context.drawImage(video, 0, 0, wid, 400);// 300, wid
//        } else {
//           //context.drawImage(video, 0, 0, 300, 150);// 300, wid
//           var data = canvas.toDataURL();
//           var b64 = data.substring(22);

//           //  b64 = convertCanvasToImage(canvas)

//            $.ajax({
//                type: 'post',
//                url: '/POD/WaybillPhoto',
//                data: {
//                    id: $("#Info_CustomerOrderNumber").val(),
//                    img: b64
//                },
//                cache: false,
//                dataType: 'json',
//                success: function (data) {
//                    //if (data.orderManagementInfo.length > 0) {
//                    //    $("#PageIndex").val(data.PageIndex);
//                    //    var html = $("#Evaluation").render(data.orderManagementInfo);
//                    //    //$("#datas")["empty"]();
//                    //    $("#dataList")["append"](html);
//                    //}
//                    //else {
//                    //    showMsg("没有数据！", 2000);
//                    //}
//                },
//                error: function (err) {
//                    showMsg(err.Massage, 3000);
//                }
//            });
//        }
//    });
//    document.getElementById("Remake").addEventListener("click", function () {

//        $("#video").show();
//        $("#canvas").hide();
//        document.getElementById("TakingPictures").innerHTML = '拍照';
//        context.clearRect(video, 0, 0, wid, 400);//清除画布上的指定区域； 300, wid
//    });

//}, false);
