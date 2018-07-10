//var enableScrollWheelZoom = true;
//var map = null;
//var zoom = 15;
//var mapPoint = null;
//var enableKeyboard = true;
//var enableContinuousZoom = true;
//var enableInertialDragging = true;
//var CommunityList = [];//坐标数据凑集
//var MarkerList = [];

//function initCommunityList(data) {
//    CommunityList.length = 0;
//    if ($.trim(data) !== "") {
//        var strCommunityList = data.split(";");
//        $.each(strCommunityList, function (i, item) {
//            if ($.trim(item) !== "") {
//                var instance = item.split(",");
//                var community = new Object();
//                community.CenterLng = instance[0];//横坐标
//                community.CenterLat = instance[1];//竖坐标
//                community.Zoom = instance[2];     //比列尺
//                community.Title = instance[3];
//                //若是没有坐标,则不参加标注数据
//                if (community.CenterLat !== -1000 && community.CenterLng !== -1000) {
//                    CommunityList[CommunityList.length] = community;
//                }
//            }
//        });
//    }
//}

//// 编写自定义函数,创建标注
//function addMarker(commuinity) {
//    var marker = _createNormalMarker(commuinity);
//    map.addOverlay(marker);
//    MarkerList[MarkerList.length] = marker;
//}

////刷新地图标注,以及地图定位
//function RefreshMarker() {
//    ClearMarker();
//    if (CommunityList.length > 0) {
//        for (var index = 0; index < CommunityList.length; index++) {
//            var community = CommunityList[index];
//            addMarker(community);
//        }
//        var commuinty = CommunityList[0];
//        var firstpoint = new BMap.Point(commuinty.CenterLng, commuinty.CenterLat);
//        map.centerAndZoom(firstpoint, Number(community.Zoom));
//    } else {
//        map.centerAndZoom(mapPoint, zoom);                 // 初始化地图,设置中间点坐标和地图级别  
//    }
//}

////清除汗青标注
//function ClearMarker() {
//    if (MarkerList.length > 0) {
//        map.clearOverlays();
//        for (var i in MarkerList) {
//            MarkerList[i] = null;
//        }
//        MarkerList.length = 0;
//    }
//}

////创建具体标注
//function _createNormalMarker(commuinity) {
//    var point = new BMap.Point(commuinity.CenterLng, commuinity.CenterLat);
//    var marker = new BMap.Marker(point, { offset: new BMap.Size(0, 13) });
//    marker.addEventListener("click", function (e) {
//        var opts = {
//            width: 300,
//            height: 100,
//            title: ""
//        };
//        var infoWindow = null;
//        var content = commuinity.Title;
//        infoWindow = new BMap.InfoWindow(content, opts);
//        map.openInfoWindow(infoWindow, e.point);

//    });
//    marker.tag = commuinity;
//    map.addOverlay(marker);
//    return marker;
//}

//window.onload = function () {
//    try {
//        mapPoint = new BMap.Point(114.131, 22.649);
//        if (map === null)
//            map = new BMap.Map("container", { mapType: BMAP_HYBRID_MAP });
//        map.centerAndZoom(mapPoint, zoom);  // 初始化地图,设置中间点坐标和地图级别  
//        if (enableScrollWheelZoom)
//            map.enableScrollWheelZoom();  // 开启鼠标滚轮缩放  
//        if (enableKeyboard)
//            map.enableKeyboard();         // 开启键盘把握  
//        if (enableContinuousZoom)
//            map.enableContinuousZoom();   // 开启连气儿缩放结果  
//        if (enableInertialDragging)
//            map.enableInertialDragging(); // 开启惯性拖拽结果 

//        var strUrl = "/System/Demo/GetData";
//        //默认加载标注数据
//        $.getJSON(strUrl, null,
//            function (data) {
//                initCommunityList(data);
//                RefreshMarker();
//            });
//    }
//    catch (err) {
//        alert("百度地图加载失败,请确保你的电脑能接见百度地图!!");
//    }

//};

$(document).ready(function () {
    //var map = new BMap.Map('container');
    //map.enableScrollWheelZoom();
    //map.centerAndZoom(new BMap.Point(121.487899, 31.249162), 13);
    //var lushu;
    //// 实例化一个驾车导航用来生成路线
    //var drv = new BMap.DrivingRoute('上海', {
    //    onSearchComplete: function (res) {
    //        if (drv.getStatus() == BMAP_STATUS_SUCCESS) {
    //            var arrPois = res.getPlan(0).getRoute(0).getPath();
    //            map.addOverlay(new BMap.Polyline(arrPois, { strokeColor: '#111' }));
    //            map.setViewport(arrPois);

    //            lushu = new BMapLib.LuShu(map, arrPois, {
    //                defaultContent: "",//"从天安门到百度大厦"
    //                autoView: true,//是否开启自动视野调整，如果开启那么路书在运动过程中会根据视野自动调整
    //                icon: new BMap.Icon('http://developer.baidu.com/map/jsdemo/img/car.png', new BMap.Size(52, 26), { anchor: new BMap.Size(27, 13) }),
    //                speed: 4500,
    //                enableRotation: true,//是否设置marker随着道路的走向进行旋转
    //                landmarkPois: [
    //                   { lng: 118.778074, lat: 32.057236, html: '南京', pauseTime: 2 }
    //                ]
    //            });
    //        }
    //    }
    //});
    //drv.search('上海', '北京');

    var map = new BMap.Map('container');
    map.centerAndZoom(new BMap.Point(117.282699, 31.866942), 7);
    map.enableScrollWheelZoom();
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.MapTypeControl());
    map.addControl(new BMap.ScaleControl());
    map.addControl(new BMap.OverviewMapControl());
    var polyline = new BMap.Polyline([
        new BMap.Point(121.487899, 31.249162),
		new BMap.Point(118.778074, 32.057236),
		new BMap.Point(117.282699, 31.866942),
		new BMap.Point(116.395645, 39.929986)
    ], { strokeColor: "red", strokeWeight: 4, strokeOpacity: 1 });   //创建折线
    map.addOverlay(polyline);   //增加折线
});