
$(function () {
    $('.datepicker').datepicker({
        //startDate: '-2d'
    });
});

function jSeries(name, data) {
    var data = [];
    this.name = name;
    this.data = data;
}

var arrSeries = [];
var names = ['订单到达', '干线', '到达终端', '运单签收'];

function myfunction() {
    for (var i = 0; i < 4; i++) {
        var temp = [];
        var s = new jSeries(names[i], temp);
        for (var j = 10; j < 14; j++) {
            s.data.push(i);
        }
        arrSeries.push(s);
    }
}
//function getDatas() {
    $(function () {
        $("#start_ActualDeliveryDate").val($("#transOrderRequest_StartTime").val());
        $("#end_ActualDeliveryDate").val($("#transOrderRequest_EndTime").val());
        window.onload = getsearch();
    //$('#ShipperName').autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            url: "/Pod/Pod/GetUserShipper",
    //            type: "POST",
    //            dataType: "json",
    //            data: { name: request.term },
    //            success: function (data) {
    //                response($.map(data, function (item) {
    //                    return { label: item.Text, value: item.Text, data: item }
    //                }));
    //            }
    //        });
    //    },
    //    select: function (event, ui) {
    //        $('#ShipperID').val(ui.item.data.Value);
    //        $('#ShipperName').val(ui.item.data.Text);
    //    }
    //}).change(function () {
    //    if ($(this).val() === '') {
    //        $('#ShipperID').val('');
    //    }
    //});

   // $('#searchButton').click(function () {
        //if ($('#ShipperName').val() === '') {
        //    BasicFramework.Alert('请录入并选择承运商');
        //    return;
        //}select = document.getElementById('mySelect');
      
})
    function getsearch() {
        $('#container').show();
        $('#containers').hide();
        $('#containers3').hide();
        
        $.ajax({
            type: 'post',
            url: '/Report/TransOrderStatus',
            data: {
                id: $('#transOrderRequest_ID').val(),
                Customers: $('#txt_search').val(),
                //ShipperName: $('#ShipperName').val(),
                //Consignee: $('#ConsigneeName').val(),
                startTime: $('#start_ActualDeliveryDate').val(),
                endTime: $('#end_ActualDeliveryDate').val(),
            },
            cache: false,
            dataType: 'json',
            success: function (response) {
                if (response.JsonDate) {
                    $('#container').hide();
                    $('#containers').hide();
                    $('#containers3').show();
                    $("#containers3").html="";
                    var html = $("#Evaluation").render(JSON.parse(response.JsonDate));
                    $("#containers3")["empty"]();
                    $("#containers3")["append"](html);
                }
                else {
                    if (response.brandsDataTotal=="[]")
                    {
                        $('#container').hide();
                        $('#containers').hide();
                        $('#containers3').hide();
                        showMsg("请重新筛选！", 2000);
                        return "";
                    }
                    var sbDate = response.sbDate;
                    var brandsDataTotal = response.brandsDataTotal;
                    var brandsDataAdidas = response.brandsDataAdidas;
                    var brandsDataNIKE = response.brandsDataNIKE;
                    var brandsDataHilti = response.brandsDataHilti;
                    var brandsDataAKZO = response.brandsDataAKZO;
                    if ($('#txt_search').val() == "") {
                        if (response) {
                            $(function () {
                                $('#container').highcharts({
                                    chart: {
                                        type: 'column'
                                    },
                                    title: {
                                        text: ' '
                                    },
                                    subtitle: {
                                        text: ' '
                                    },
                                    xAxis: {
                                        categories: sbDate,
                                    },
                                    yAxis: {
                                        min: 0,
                                        title: {
                                            text: '单量 (单)'
                                        }
                                    },
                                    //tooltip: {
                                    //    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                    //    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                    //        '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                                    //    footerFormat: '</table>',
                                    //    shared: true,
                                    //    useHTML: true
                                    //},
                                    plotOptions: {
                                        column: {
                                            pointPadding: 0.2,
                                            borderWidth: 0,
                                            dataLabels: {
                                                enabled: true,
                                                style: {
                                                    fontSize: '12',
                                                    color: 'RoyalBlue'
                                                }
                                            }
                                        }, series: {
                                            point: {
                                                events: {
                                                    click: function (e) {

                                                        var Time = this.category;
                                                        $.ajax({
                                                            type: 'post',
                                                            url: '/Report/TransOrderStatus',
                                                            data: {
                                                                id: $('#transOrderRequest_ID').val(),
                                                                Customers: $('#txt_search').val(),
                                                                //ShipperName: $('#ShipperName').val(),
                                                                //Consignee: $('#ConsigneeName').val(),
                                                                startTime: $('#start_ActualDeliveryDate').val(),
                                                                endTime: $('#end_ActualDeliveryDate').val(),
                                                                Time: Time
                                                            },
                                                            cache: false,
                                                            dataType: 'json',
                                                            success: function (responsedata) {
                                                                if (responsedata) {
                                                                    $('#container').hide();
                                                                    $('#containers').show();
                                                                    $('#containers3').hide();
                                                                    var sbDates = responsedata.sbDate;
                                                                    var brandsDataTotals = responsedata.brandsDataTotal;
                                                                    var brandsDataAdidass = responsedata.brandsDataAdidas;
                                                                    var brandsDataNIKEs = responsedata.brandsDataNIKE;
                                                                    var brandsDataHiltis = responsedata.brandsDataHilti;
                                                                    var brandsDataAKZOs = responsedata.brandsDataAKZO;

                                                                    $(function () {
                                                                        $('#containers').highcharts({
                                                                            chart: {
                                                                                type: 'column'
                                                                            },
                                                                            title: {
                                                                                text: ' '
                                                                            },
                                                                            subtitle: {
                                                                                text: ' '
                                                                            },
                                                                            xAxis: {
                                                                                categories: sbDates
                                                                            },
                                                                            yAxis: {
                                                                                min: 0,
                                                                                title: {
                                                                                    text: '单量 (单)'
                                                                                }
                                                                            },
                                                                            //tooltip: {
                                                                            //    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                                                            //    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                                                            //        '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                                                                            //    footerFormat: '</table>',
                                                                            //    shared: true,
                                                                            //    useHTML: true
                                                                            //},
                                                                            plotOptions: {
                                                                                column: {
                                                                                    pointPadding: 0.2,
                                                                                    borderWidth: 0,
                                                                                    dataLabels: {
                                                                                        enabled: true,
                                                                                        style: {
                                                                                            fontSize: '12',
                                                                                            color: 'RoyalBlue'
                                                                                        }
                                                                                    }
                                                                                }, series: {
                                                                                    point: {
                                                                                        events: {
                                                                                            click: function (e) {
                                                                                                $('#container').show();
                                                                                                $('#containers').hide();
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            },
                                                                            series: [{
                                                                                name: 'Total',
                                                                                colors: '#feeeed',
                                                                                data: JSON.parse(brandsDataTotals)

                                                                            }, {
                                                                                name: '订单下达',
                                                                                colors: '#f47920',
                                                                                data: JSON.parse(brandsDataAdidass)

                                                                            }, {
                                                                                name: '干线运输',
                                                                                colors: '#80752c',

                                                                                data: JSON.parse(brandsDataNIKEs)
                                                                            }, {
                                                                                name: '到达终端',
                                                                                colors: '#2a5caa',

                                                                                data: JSON.parse(brandsDataHiltis)
                                                                            }, {
                                                                                name: '运单签收',
                                                                                colors: '#ad9b01',
                                                                                data: JSON.parse(brandsDataAKZOs)

                                                                            }]
                                                                        });
                                                                    });
                                                                }
                                                            }
                                                        })
                                                    }
                                                }
                                            }
                                        }

                                    },
                                    series: [{
                                        name: 'Total',
                                        colors: '#feeeed',
                                        data: JSON.parse(brandsDataTotal)

                                    }, {
                                        name: '订单下达',
                                        colors: '#f47920',

                                        data: JSON.parse(brandsDataAdidas)
                                    }, {
                                        name: '干线运输',
                                        colors: '#80752c',
                                        data: JSON.parse(brandsDataNIKE)

                                    }, {
                                        name: '到达终端',
                                        colors: '#2a5caa',

                                        data: JSON.parse(brandsDataHilti)
                                    }, {
                                        name: '运单签收',
                                        colors: '#ad9b01',
                                        data: JSON.parse(brandsDataAKZO)

                                    }]
                                });
                            });
                        }
                    }
                    else {
                        $(function () {
                            $('#container').highcharts({
                                chart: {
                                    type: 'column'
                                },
                                title: {
                                    text: ' '
                                },
                                subtitle: {
                                    text: ' '
                                },
                                xAxis: {
                                    categories: sbDate
                                },
                                yAxis: {
                                    min: 0,
                                    title: {
                                        text: '单量 (单)'
                                    }
                                },
                                //tooltip: {
                                //    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                //    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                //        '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
                                //    footerFormat: '</table>',
                                //    shared: true,
                                //    useHTML: true
                                //},
                                plotOptions: {
                                    column: {
                                        pointPadding: 0.2,
                                        borderWidth: 0,
                                        dataLabels: {
                                            enabled: true,
                                            style: {
                                                fontSize: '12',
                                                color: 'RoyalBlue'
                                            }
                                        }
                                    }, series: {
                                        point: {
                                            events: {
                                                click: function (e) {
                                                    $('#container').show();
                                                    $('#containers').hide();
                                                }
                                            }
                                        }
                                    }
                                },
                                series: [{
                                    name: 'Total',
                                    colors: '#feeeed',
                                    data: JSON.parse(brandsDataTotal)

                                }, {
                                    name: '订单下达',
                                    colors: '#f47920',
                                    data: JSON.parse(brandsDataAdidas)

                                }, {
                                    name: '干线运输',
                                    colors: '#80752c',

                                    data: JSON.parse(brandsDataNIKE)
                                }, {
                                    name: '到达终端',
                                    colors: '#2a5caa',

                                    data: JSON.parse(brandsDataHilti)
                                }, {
                                    name: '运单签收',
                                    colors: '#ad9b01',
                                    data: JSON.parse(brandsDataAKZO)

                                }]
                            });
                        });
                    }
                }
            }
            })
    };//);
//function getDatas() {
//    $.ajax({
//        type: 'post',
//        url: '/Resource/Report',
//        data: {},
//        cache: false,
//        dataType: 'json',
//        success: function (data) {
//            if (data.CRMShipperCollection.length > 0) {

//            }
//            else {
//                aaa();
//                showMsg("没有数据！", 2000);
//            }
//        },
//        error: function (err) {
//            aaa();
//            showMsg(err.Massage, 3000);
//        }
//    });
//}

//function getChart() {
//    myfunction();

//    $('#container').highcharts({
//        chart: {
//            type: 'column'
//        },
//        title: {
//            text: '运单查询'
//        },
//        subtitle: {
//            text: ''
//        },
//        xAxis: {
//            categories: [
//                'Nike',
//                'Adidas',
//                'Hilter',
//                'Akzon',
//            ],
//            crosshair: true
//        },
//        yAxis: {
//            min: 0,
//            title: {
//                text: ''
//            }
//        },
//        tooltip: {
//            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
//            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
//                '<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
//            footerFormat: '</table>',
//            shared: false,
//            useHTML: false
//        },
//        series: arrSeries
//    });
    //


