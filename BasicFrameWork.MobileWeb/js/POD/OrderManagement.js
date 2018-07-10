$(function () {
    window.onload = init;
    function init()
    {
        var PageIndex = document.getElementById("PageIndex").value;
        var PageCount = document.getElementById("PageCount").value;
        if (PageCount > PageIndex)
        {
            $("#fo").show();
        };
    }
    $("#searchButton").click(function () {
        $.ajax({
            type: 'post',
            url: '/POD/OrderManagement',
            data: {
                conditions: $("#txt_search").val()
            },
            cache: false,
            dataType: 'json',
            success: function (data) {
                if (data.PageCount > (data.PageIndex+1)) {
                    $("#fo").show();
                } else {
                    $("#fo").hide();
                }
                if (data.orderManagementInfo .length> 0) {
                    $("#PageIndex").val(data.PageIndex);
                    var html = $("#Evaluation").render(data.orderManagementInfo);
                    $("#dataList")["empty"]();
                    $("#dataList")["append"](html);
                }
                else {
                    showMsg("没有数据！", 2000);
                }
            },
            error: function (err) {
                showMsg(err.Massage, 3000);
            }
        });
    })
})
//$(".form_datetime").datetimepicker({
//    format: "dd MM yyyy - hh:ii"
//});
function pullUpAction()
{
    $.ajax({
        type: 'post',
        url: '/POD/OrderManagement',
        data: {
            conditions: $("#txt_search").val(),
            PageIndex: parseInt($("#PageIndex").val()) + 1,
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.orderManagementInfo.length > 0) {
                $("#PageIndex").val(data.PageIndex);
                var html= $("#Evaluation").render(data.orderManagementInfo);
                //$("#datas")["empty"]();
                $("#dataList")["append"](html);
            }
            else {
                showMsg("没有数据！", 2000);
            }
        },
        error: function (err) {
            showMsg(err.Massage, 3000);
        }
    });
}

function Photo(id)
{
  //  var Id = $(id).parent().parent().parent().parent().attr('id');
    window.location.href = '/POD/WaybillPhoto?Id=' + id;
}
function RouteGPS(id) {
    //   var Id = $(id).parent().parent().parent().parent().attr('id');
    window.location.href = '/POD/RouteGPS?Id=' + id;
}
 
function details(Id) {
    window.location.href = '/POD/PODInformation?Id=' + Id;
}