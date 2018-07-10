
var pageIndex = 1,
    keyword = "",
    id = document.getElementById("hiddenid").value,
    flag = false;


function aaa() {
    hideMask();
    $('.pageMore').eq(0).children(0).text("加载更多");
}
function appendDriverList(data) {

    for (var i = 0; i < data.CRMVehicleCollection.length; i++) {
        var item = data.CRMVehicleCollection[i];

        var str = "<li class='list-group-item'>\
                                        <a href='/Resource/VehicleInfos/" + item.ID + "' style='color: #555;'>\
                                            <h4><strong>" + item.CarNo + " </strong></h4>\
                                        </a>\
                                    <div style=''>\
                                        <div style='float: left'>上牌日期：<span>" + item.BoardlotDate + "</span></div>\
                                        <div style='float: right'>车身颜色：<span>" + item.CarBodyColor + "</span></div>\
                                    </div><br />\
                                    <div style=''>\
                                        <div style='float: left'>车辆种类：<span>" + item.CarType + "</span></div>\
                                        <div style='float: right'>车牌种类：<span>" + item.CarNumType + "</span></div>\
                                    </div><br />\
                                    <div style=''>\
                                        <div style='float: left'>所属公司：<span>" + item.LogisticCompany + "</span></div>\
                                         <div style='float: right'>公司联系人：<span>" + item.LoadPerson + "</span></div>\
                                    </div><br />\
                                    <div style=''>\
                                         <div style='float: left'>运营证号：<span>" + item.TrailerNo + "</span></div>\
                                        <div style='float: right'>车辆尺寸：<span>" + item.Size + "</span></div>\
                                    </div><br />\
                                            <div class=''>保险有效截止日期：<span>" + item.InsuranceEndDate + "</span></div>\ \
                                            <div class=''>加入虹迪服务时间：<span>" + item.StartServiceDate + "</span></div>\
                                   </li>";
        $(".myList > .list-group").append(str);
    }
}

function returnstring(datetimes) {
    if (datetimes == '0001-01-01') {
        return "";
    } else {
        return datetimes;
    }
}


function getVehicleMore() {
    showMask();
    $('.pageMore').eq(0).children(0).text("正在加载...");
    $.ajax({
        type: 'post',
        url: '/Resource/GetShipperMappingVehicleInfoByShipperIDandkeyWord/?id=' + id + "&keyword=" + keyword + "&pageIndex=" + pageIndex,
        data: {},
        cache: false,
        dataType: 'json',

        success: function (data) {
            var datas = JSON.parse(data);
            if (datas.CRMVehicleCollection.length > 0) {
                appendDriverList(datas);
                ++pageIndex;
                aaa();
                if (datas.PageCount <= pageIndex) {
                    $('.pageMore').hide();
                }
            }
            else {
                aaa();
                showMsg("没有数据！", 2000);
            }
        },
        error: function (err) {
            aaa();
            showMsg(err.Massage, 3000);
        }
    });
}

function search() {
    var keyword = encodeURI(document.getElementById("txt_search").value);

    pageIndex = 0;
    showMask();
    $.ajax({
        type: 'post',
        url: '/Resource/GetShipperMappingVehicleInfoByShipperIDandkeyWord/?id=' + id + "&keyword=" + keyword + "&pageIndex=" + pageIndex,
        data: {},
        cache: false,
        dataType: 'json',

        success: function (data) {
            /*console.log(data);*/
            $(".myList > .list-group").children().remove();
            var datas = JSON.parse(data);
            if (datas.CRMVehicleCollection.length > 0) {
                appendDriverList(datas);
                pageIndex = 1;
                if (datas.PageCount > pageIndex) {
                    $('.pageMore').show();
                }
                else {
                    $('.pageMore').hide();
                }
            }
            else {
                showMsg("没有数据！", 2000);
                $('.pageMore').hide();
            }
            hideMask();
        },
        error: function (err) {
            hideMask();
            showMsg(err.Massage, 3000);
        }
    });
}
 
