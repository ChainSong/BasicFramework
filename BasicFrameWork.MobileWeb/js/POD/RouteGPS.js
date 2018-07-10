var map;
var gpsPoint;
var baiduPoint;
var gpsAddress;
var baiduAddress;


function getLocation() {
    //根据IP获取城市
    //var myCity = new BMap.LocalCity();
    //myCity.get(getCityByIP);
    // 百度地图API功能
    //var map = new BMap.Map("map");
    //map.centerAndZoom(new BMap.Point(118.454, 32.955), 6);
    //map.enableScrollWheelZoom();
    //var beijingPosition = new BMap.Point(116.432045, 39.910683),
    //	hangzhouPosition = new BMap.Point(120.129721, 30.314429),
    //	taiwanPosition = new BMap.Point(121.491121, 25.127053);
    //var points = [beijingPosition, hangzhouPosition, taiwanPosition];

    //var curve = new BMapLib.CurveLine(points, { strokeColor: "blue", strokeWeight: 3, strokeOpacity: 0.5 }); //创建弧线对象
    //map.addOverlay(curve); //添加到地图中
    //curve.enableEditing(); //开启编辑功能

    //获取GPS坐标
    if (navigator.geolocation) {
        //  navigator.geolocation.getCurrentPosition(showMap, handleError, { enableHighAccuracy: true, maximumAge: 1000 });
        navigator.geolocation.getCurrentPosition(showMap);
    } else {
        alert("您的浏览器不支持使用HTML 5来获取地理位置服务");
    }
}

function showMap(value) {


    var longitude = value.coords.longitude;
    var latitude = value.coords.latitude;

    map = new BMap.Map("map");
    //alert("坐标经度为：" + latitude + "， 纬度为：" + longitude );
    //+0.00000000037
    //+0.00000016994
    gpsPoint = new BMap.Point(longitude, latitude);    // 创建点坐标
    map.centerAndZoom(gpsPoint, 15);

    //根据坐标逆解析地址
    var geoc = new BMap.Geocoder();
    // geoc.getLocation(gpsPoint, getCityByCoordinate);

    BMap.Convertor.translate(gpsPoint, 0, translateCallback);
}

translateCallback = function (point) {
    baiduPoint = point;
    var geoc = new BMap.Geocoder();
    geoc.getLocation(baiduPoint, getCityByBaiduCoordinate);
    gpsPoint = new BMap.Point(point.lat, point.lng)
}

function getCityByCoordinate(rs) {
    //gpsAddress = rs.addressComponents;
    //var address = "GPS标注：" + gpsAddress.province + "," + gpsAddress.city + "," + gpsAddress.district + "," + gpsAddress.street + "," + gpsAddress.streetNumber;
    //var marker = new BMap.Marker(gpsPoint);  // 创建标注
    //map.addOverlay(marker);              // 将标注添加到地图中
    //var labelgps = new BMap.Label(address, { offset: new BMap.Size(20, -10) });
    //marker.setLabel(labelgps); //添加GPS标注    
}

function getCityByBaiduCoordinate(rs) {
    baiduAddress = rs.addressComponents;
    var address = "百度标注：" + baiduAddress.province + "," + baiduAddress.city + "," + baiduAddress.district + "," + baiduAddress.street + "," + baiduAddress.streetNumber;
   
    var marker = new BMap.Marker(baiduPoint);  // 创建标注
    map.addOverlay(marker);              // 将标注添加到地图中/31.238946000037//
    //var labelbaidu = new BMap.Label(address, { offset: new BMap.Size(20, -10) });
    var json = address;
    var labelbaidu = new BMap.Label("<a style='color:blue;text-decoration:none' target='_blank'>" + address + "</a>",     //为lable填写内容 href='http://dev.baidu.com/wiki/static/index.htm'
    {
        offset: new BMap.Size(0,-60)                 //label的偏移量，为了让label的中心显示在点上
      
    });                                //label的位置
    labelbaidu.setStyle({                                   //给label设置样式，任意的CSS都是可以的
        fontSize: "14px",               //字号
        border: "0",                    //边
        height: "120px",                //高度
        width: "125px",                 //宽
        textAlign: "center",            //文字水平居中显示
        lineHeight: "120px",            //行高，文字垂直居中显示
        //background: "url(http://cdn1.iconfinder.com/data/icons/CrystalClear/128x128/actions/gohome.png)",    //背景图片，这是房产标注的关键！
        cursor: "pointer"
    });
    //var labelbaidu = new BMap.Label(json, { "offset": new BMap.Size(20, -10) }, {
    //    borderColor: "#808080",
    //    color: "#333",
    //    cursor: "pointer"
    //});
    gpsPoint = new BMap.Point(baiduPoint.lng, baiduPoint.lat);    // 创建点坐标
    map.centerAndZoom(gpsPoint, 15);
    
    marker.setLabel(labelbaidu); //添加百度标注  
  
}

//根据IP获取城市
//function getCityByIP(rs) {
//    var cityName = rs.name;
//    alert("根据IP定位您所在的城市为:" + cityName);
//}

function handleError(value) {
    switch (value.code) {
        case 1:
            alert("位置服务被拒绝");
            break;
        case 2:
            alert("暂时获取不到位置信息");
            break;
        case 3:
            alert("获取信息超时");
            break;
        case 4:
            alert("未知错误");
            break;
    }
}

function init() {
    getLocation();
}

window.onload = init;


function GetGPS() {
    var a = baiduPoint.lng;
    $.ajax({
        type: 'post',
        url: '/POD/RouteGPS',
        data: {

            id: $("#Info_ID").val(),
            SystemNumber: $("#Info_SystemNumber").val(),
            CustomerOrderNumber: $("#Info_CustomerOrderNumber").val(),
            address: baiduAddress.city + "" + baiduAddress.district + "" + baiduAddress.street + "" + baiduAddress.streetNumber,
            lng: baiduPoint.lng,
            lat: baiduPoint.lat
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.length > 0) {
                $("#map").hide();
                $("#container").show();
                $("#GetGPS").hide();
                $("#ret").show();
                $("#QueryGPS").hide();
 
                
                // 百度地图API功能
                var map = new BMap.Map("container");
                map.centerAndZoom(new BMap.Point(data[0].Lng, data[0].Lat), 12);
                map.enableScrollWheelZoom();
                var onePosition, twoPosition, threePosition, fourPosition
                var points;
                for (var i = 0; i < data.length; i++) {
                    if (i == 0) {
                        onePosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition];
                    }
                    if (i == 1) {
                        twoPosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition, twoPosition]
                    }
                    if (i == 2) {
                        threePosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition, twoPosition, threePosition]
                    }
                    if (i == 3) {
                        fourPosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition, twoPosition, threePosition, fourPosition]
                    }
                }

               // var points = [onePosition, twoPosition, threePosition, fourPosition];//

                var curve = new BMapLib.CurveLine(points, { strokeColor: "blue", strokeWeight: 3, strokeOpacity: 0.5 }); //创建弧线对象
                map.addOverlay(curve); //添加到地图中
                curve.enableEditing(); //开启编辑功能
            }
        },
        error: function (err) {
            showMsg(err.Massage, 3000);
        }
    });
}
function QueryGPS() {
    var a = baiduPoint.lng;
    $.ajax({
        type: 'post',
        url: '/POD/RouteGPS',
        data: {

            CustomerOrderNumber: $("#Info_CustomerOrderNumber").val(),
        },
        cache: false,
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.length > 0) {
                $("#map").hide();
                $("#container").show();
                $("#GetGPS").hide();
                $("#ret").show();
                $("#QueryGPS").hide();
                // 百度地图API功能
                var map = new BMap.Map("container");
                map.centerAndZoom(new BMap.Point(data[0].Lng, data[0].Lat), 12);
                map.enableScrollWheelZoom();
                var onePosition, twoPosition, threePosition, fourPosition
                var points;
                for (var i = 0; i < data.length; i++) {
                    if (i == 0) {
                        onePosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition];
                    }
                    if (i == 1) {
                        twoPosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition, twoPosition]
                    }
                    if (i == 2) {
                        threePosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition, twoPosition, threePosition]
                    }
                    if (i == 3) {
                        fourPosition = new BMap.Point(data[i].Lng, data[i].Lat);
                        points = [onePosition, twoPosition, threePosition, fourPosition]
                    }
                }

                // var points = [onePosition, twoPosition, threePosition, fourPosition];//

                var curve = new BMapLib.CurveLine(points, { strokeColor: "blue", strokeWeight: 3, strokeOpacity: 0.5 }); //创建弧线对象
                map.addOverlay(curve); //添加到地图中
                curve.enableEditing(); //开启编辑功能
            }
            else {
                showMsg("没找到地理位置，请添加！", 2000);
            }
        },
        error: function (err) {
            showMsg(err.Massage, 3000);
        }
    });
}
//function ret()
//{
//    window.location 
//}
//    //if (navigator.geolocation) {
//    //    navigator.geolocation.getCurrentPosition(showPosition);
//    //} else {
//    //    alert("您的浏览器不支持地理定位");
////}

//window.onload = getLocation;
//function getLocation() {
//    if (navigator.geolocation) {
//        navigator.geolocation.getCurrentPosition(showPosition);
//    } else {
//        alert("您的浏览器不支持地理定位");
//    }
//}
////navigator.geolocation.getCurrentPosition(showPosition);

//function showPosition(position) {
//    lat = position.coords.latitude;
//    lon = position.coords.longitude;
//    var point = new BMap.Point(parseFloat(lon) + 0.0065, parseFloat(lat) + 0.0065);
//    var point = new BMap.Point(lon, parseFloat(lat));
//    addMarker(point);
//    //var map = new BMap.Map("allmap");    // 创建Map实例
//    //map.centerAndZoom(new BMap.Point(lon, lat), 11);  // 初始化地图,设置中心点坐标和地图级别
//    //map.addControl(new BMap.MapTypeControl());   //添加地图类型控件
//    //map.setCurrentCity("北京");          // 设置地图显示的城市 此项是必须设置的
//    //map.enableScrollWheelZoom(true);


//var map = new BMap.Map("container");
//map.centerAndZoom(new BMap.Point(lon, lat), 12);
//map.addControl(new BMap.ScaleControl());
//map.addControl(new BMap.OverviewMapControl());
//var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
//map.addControl(ctrl_nav);

//map.enableDragging(); //启用地图拖拽事件，默认启用(可不写)
//map.enableScrollWheelZoom(); //启用地图滚轮放大缩小
//map.enableDoubleClickZoom(); //启用鼠标双击放大，默认启用(可不写)
//map.enableKeyboard(); //启用键盘上下左右键移动地图


//map.addEventListener("click", function () {
//    var center = map.getCenter();
//    document.getElementById("info").innerHTML = center.lng + ", " + center.lat;
//});

//// 编写自定义函数，创建标注   
//function addMarker(point) {

//    // 创建图标对象   
//    var myIcon = new BMap.Icon("http://api.map.baidu.com/img/markers.png", new BMap.Size(23, 25), {
//        // 指定定位位置。   
//        // 当标注显示在地图上时，其所指向的地理位置距离图标左上   
//        // 角各偏移10像素和25像素。您可以看到在本例中该位置即是   
//        // 图标中央下端的尖角位置。   
//        offset: new BMap.Size(10, 25),
//        // 设置图片偏移。   
//        // 当您需要从一幅较大的图片中截取某部分作为标注图标时，您   
//        // 需要指定大图的偏移位置，此做法与css sprites技术类似。   
//        imageOffset: new BMap.Size(0, 0 - 1 * 25)   // 设置图片偏移   
//    });

//    // 创建标注对象并添加到地图   
//    var marker = new BMap.Marker(point);
//    map.addOverlay(marker);

//    //移除标注
//    //marker.addEventListener("click", function () {
//        //            map.removeOverlay(marker);
//        //            marker.dispose();

//    //    var opts = {
//    //        width: 250,     // 信息窗口宽度
//    //        height: 100,     // 信息窗口高度
//    //        title: "lng:" + point.lng + "lat:" + point.lat  // 信息窗口标题
//    //    }

//    //    var infoWindow = new BMap.InfoWindow("", opts);  // 创建信息窗口对象
//    //    marker.openInfoWindow(infoWindow, this.point);      // 打开信息窗口

//    //});
//}


//}