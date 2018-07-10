
var pageIndex = 1,
    id = id = document.getElementById("hiddenid").value,
    keyword = "",
    flag = false;

function aaa() {
    hideMask();
    $('.pageMore').eq(0).children(0).text("加载更多");
}


function appendDriverList(data) {

    for (var i = 0; i < data.CRMDriverCollection.length; i++) {
        var item = data.CRMDriverCollection[i];
        var lrc = "";
        var lrcs = "";
        if (item.DriverPhone != "") {
            lrc = "<a href='tel:" + item.DriverPhone + "' class='text-danger'><span class='glyphicon glyphicon-earphone'></span>：" + item.DriverPhone + "</a>";
        }
        if (item.DriverLogisticsCompanyContactPhone != "") {
            lrcs = "<a href='tel:" + item.DriverLogisticsCompanyContactPhone + "' class='text-danger'><span class='glyphicon glyphicon-earphone'></span>：" + item.DriverLogisticsCompanyContactPhone + "</a>";
        }

        var str = "<li class='list-group-item'>\
                                        <a href='/Resource/DriverInfos/"+ item.ID + "' style='color: #555;'>\
                                            <h4><strong>"+ item.DriverName + " </strong></h4>\
                                        </a>\
                                        <div class=''>身份证号：<span>" + item.DriverIDCard + "</span></div>\
                                        <div class=''>出生日期：<span>" + returnstring(item.DriverBirthday) + "</span></div>\
                                         <div style='float: none'>\
                                            <div style='float: left'>领证日期：<span>" + returnstring(item.DriverFirstTimeGetCardDate) + "</span></div>\
                                            <div style='float: right'>驾照类型：<span>" + item.DriverCardType + "</span></div>\
                                        </div>\
                                        <br />\
                                        <div style=''>\
                                            <div style='float: left'>所属公司：<span>" + item.DriverLogisticsCompany + "</span></div>\
                                            <div style='float: right'>公司联系人：<span class='text-danger'>" + item.DriverLogisticsContactPerson + "</span></div>\
                                        </div>\
                                        <br />\
                                        <div style=''>\
                                            <div style='float: left'>驾驶车辆牌号：<span>" + item.DriverCarNo + "</span></div>\
                                            <div style='float: right'>服务区域：<span>" + item.DriverServiceArea + "</span></div>\
                                        </div>\
                                        <br />\
                                        <div class=''>\公司电话： "+ lrcs + "\
                                        </div>\
                                        \
                                        <div class=''>\手机号码： "+ lrc + "\
                                        </div>\
                                        <br />\
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


function getDriverMore() {
    showMask();
    $('.pageMore').eq(0).children(0).text("正在加载...");
    $.ajax({
        type: 'post',
        url: '/Resource/GetShipperMappingDriverInfoBySIDandkeyWord/?id=' + id + "&keyword=" + keyword + "&pageIndex=" + pageIndex,
        data: {},
        cache: false,
        dataType: 'json',

        success: function (data) {
            var datas = JSON.parse(data);
            if (datas.CRMDriverCollection.length > 0) {
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
        url: '/Resource/GetShipperMappingDriverInfoBySIDandkeyWord/?id=' + id + "&keyword=" + keyword + "&pageIndex=" + pageIndex,
        data: {},
        cache: false,
        dataType: 'json',

        success: function (data) {
            /*console.log(data);*/
            $(".myList > .list-group").children().remove();
            var datas = JSON.parse(data);
            if (datas.CRMDriverCollection.length > 0) {
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


