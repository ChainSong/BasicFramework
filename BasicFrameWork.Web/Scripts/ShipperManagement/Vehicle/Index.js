$(document).ready(function () {
    //var start = document.getElementById("start_BoardlotTime");
    //start.style.width = "40%";

    //$("#start_BoardlotTime").css("width", "40%");


    $('#VeDrMapping').live('click', function () {
        var da = $(this).attr('data-id');
        window.location.href = "/ShipperManagement/Mapping/VehicleDriverMapping/" + da;


    })
    //onclick = "javascript : window.location.href = '/ShipperManagement/Mapping/VehicleDriverMapping/@item.ID'"


    //编辑
    $('#vehiclesInfoTable').find('#UpdateVehicle').live('click', function () {
        var crmID = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        window.location.href = "/ShipperManagement/Vehicle/CreateOrUpdate?id=" + crmID + "&type=3";
    });
 
    $('#searchButton').click(function () {
        $("#PageIndex").val('0');
        setPageControlVal();
    });

    $('.calendarRange').each(function (index) {
        var id = $(this).attr('id');
        var pref = id.split('_')[0];
        var actualID = id.split('_')[1];
        var descID = 'SearchCondition_';
        if (pref === 'start') {
            descID += 'Start' + actualID;
        }
        else {
            descID += 'End' + actualID;
        }
        $(this).val($('#' + descID).val());
    });
    var setPageControlVal = function () {
        $('.calendarRange').each(function (index) {
            var id = $(this).attr('id');
            var pref = id.split('_')[0];
            var actualID = id.split('_')[1];
            var descID = 'SearchCondition_';
            if (pref === 'start') {
                descID += 'Start' + actualID;
            }
            else {
                descID += 'End' + actualID;
            }
            $('#' + descID).val($(this).val());
        });
    }

    //删除
    $('#vehiclesInfoTable').find('#deleteVehicle').live('click', function () {
        if (confirm("您确认删除此车辆？")) {
            var vehicleID = $(this).attr('data-id');
            var tr = $(this).parent().parent();
            $.send(
                '/ShipperManagement/Vehicle/DeleteCRMVehicle',
                { id: vehicleID },
                function (response) {
                    if (response.IsSuccess) {
                        tr.remove();
                    }
                    BasicFramework.Alert(response.Message);
                },
                function () {
                    BasicFramework.Alert("删除车辆信息失败，请联系IT");
                });
        }
    });


   

});



 