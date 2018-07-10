var pageIndex = 1,
    keyword = "",
    flag = false;

function aaa() {
    hideMask();
    $('.pageMore').eq(0).children(0).text("加载更多");
}

function appendShipperList(data) {
    for (var i = 0; i < data.CRMShipperCollection.length; i++) {
        var item = data.CRMShipperCollection[i];
        var lrc = "";
        if (item.LegalRepresentativeConta != "") {
            lrc = "<a href='tel:" + item.LegalRepresentativeConta + "' class='text-danger'><span class='glyphicon glyphicon-earphone'></span>：" + item.LegalRepresentativeConta + "</a>";
        }
        var str = "<li class='list-group-item'>\
                                        <a href='/Resource/ShipperInfos/"+ item.ID + "' style='color: #555;'>\
                                            <h4><strong>"+ item.Name + "（" + item.Attribution + "）</strong></h4>\
                                        </a>\
                                        <div class=''>注册资金：<span class='text-danger'>"+ item.RegisteredCapitalRange + "</span></div>\
                                        <div style='float: none'>\
                                            <div style='float: left'>运输方式：<span>"+ item.TransportMode + "</span></div>\
                                            <div style='float: right'>评分指数：<span class='text-danger'>"+ item.Rating + "</span></div>\
                                        </div>\
                                        <br />\
                                        <div style=''>\
                                            <div style='float: left'>车   型：<span>"+ item.TrunkOfVehicleType + "</span></div>\
                                            <div style='float: right'>推荐指数：<span class='text-danger'>"+ item.Recommended + "</span></div>\
                                        </div>\
                                        <br />\
                                        <div style=''>\
                                            <div style='float: left'>法   人：<span>"+ item.LegalRepresentative + "</span></div>\
                                            <div style='float: right'>\
                                                "+ lrc + "\
                                            </div>\
                                        </div>\
                                        <br />\
                                    </li>";
        $(".myList > .list-group").append(str);
    }
}

function getShipperMore() {
    showMask();
    $('.pageMore').eq(0).children(0).text("正在加载...");
    $.ajax({
        type: 'post',
        url: '/Resource/Shipper/?keyword=' + keyword + "&pageIndex=" + pageIndex,
        data: {},
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.CRMShipperCollection.length > 0) {
                appendShipperList(data);
                ++pageIndex;
                aaa();
                if (data.PageCount <= pageIndex) {
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
    keyword = document.getElementById("txt_search").value;
    pageIndex = 0;
    showMask();
    $.ajax({
        type: 'post',
        url: '/Resource/Shipper/?keyword=' + keyword + "&pageIndex=" + pageIndex,
        data: {},
        cache: false,
        dataType: 'json',
        success: function (data) {
            /*console.log(data);*/
            $(".myList > .list-group").children().remove();
            if (data.CRMShipperCollection.length > 0) {
                appendShipperList(data);
                pageIndex = 1;
                if (data.PageCount > pageIndex) {
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