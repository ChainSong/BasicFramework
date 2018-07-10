$(document).ready(function () {
    $('#attributionName').attr('value', $('#Shipper_Attribution').val());

    $('#btnReturn').live('click', function () {
        window.location.href = "/ShipperManagement/Shipper/Index?MenuID=1010";
    });

    $('#vehicleView').on("click",function () {
        window.location.href = "/ShipperManagement/Vehicle/Index?MenuID=1010&id=" + $("#Shipper_ID")[0].value;
        //$.send(
        //  '/ShipperManagement/Mapping/VehicleView',
        //  { id: id, shippername :shippername},
        //     function (response) {
        //     }
        //     )

        //$.ajax({
        //    url: "/ShipperManagement/Mapping/VehicleView",
        //    type: "Get",
        //    data: {
        //        id: "",
        //        shippername: $("#Shipper_Name")[0].value
        //    },
        //    async: "false",
        //    success: function (data) {

        //    },
        //    error: function (msg) {
        //        showMsg("有错误~！", 2000);
        //    }
        //});

    });

    //document.getElementById("CRMShipper_DateTime1").className = "calendarRange form-control";
     
    //document.getElementById("CRMShipper_DateTime2").className = "calendarRange form-control";
    //document.getElementById("CRMShipper_DateTime3").className = "calendarRange form-control";

    //document.getElementById("attributionName").className = "form-control";

    var rating = $('#Shipper_Rating').val();
    var recommended = $('#Shipper_Recommended').val();

    if (rating === '') {
        rating = 0;
    }

    if (recommended === '') {
        recommended = 0;
    }

    var ratingOptions = {
        max: 5,
        value: rating,
        enabled: $('#ViewType').val() == '0' ? false : true,
        after_click: function (ret) {
            $('#Shipper_Rating').val(ret.number);
        }
    };

    var recommendedOptions = {
        max: 5,
        value: recommended,
        enabled: $('#ViewType').val() == '0' ? false : true,
        after_click: function (ret) {
            $('#Shipper_Recommended').val(ret.number);
        }
    };

    $('#RatingDiv').rater(ratingOptions);

    $('#RecommendedDiv').rater(recommendedOptions);

    $('#AttributionClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#Shipper_Attribution').val('');
    });

    //$('#returnButton').click(function () {
    //    window.location.href = '/ShipperManagement/ShipperManagement/Index?useSession=true';
    //});

    $('#Shipper_RegisteredCapital').keyup(function () {
        var val = parseInt($(this).val());
        if (val) {
            if (val <= 100) {
                $('#Shipper_RegisteredCapitalRange').val('100万以内');
            } else if (val > 100 && val <= 300) {
                $('#Shipper_RegisteredCapitalRange').val('100万-300万');
            } else if (val > 300 && val <= 500) {
                $('#Shipper_RegisteredCapitalRange').val('300万-500万');
            } else if (val > 500 && val <= 800) {
                $('#Shipper_RegisteredCapitalRange').val('500万-800万');
            } else if (val > 800 && val <= 1200) {
                $('#Shipper_RegisteredCapitalRange').val('800万-1200万');
            } else if (val > 1200 && val <= 2000) {
                $('#Shipper_RegisteredCapitalRange').val('1200万-2000万');
            } else if (val > 2000) {
                $('#Shipper_RegisteredCapitalRange').val('2000万以上');
            }
        } else {
            $('#Shipper_RegisteredCapitalRange').val('');
        }
    });

    $('#Shipper_AnnualTurnover').keyup(function () {
        var val = parseInt($(this).val());
        if (val) {
            if (val <= 500) {
                $('#Shipper_AnnualTurnoverRange').val('500万以内');
            } else if (val > 500 && val <= 800) {
                $('#Shipper_AnnualTurnoverRange').val('500万-800万');
            } else if (val > 800 && val <= 1200) {
                $('#Shipper_AnnualTurnoverRange').val('800万-1200万');
            } else if (val > 1200 && val <= 2000) {
                $('#Shipper_AnnualTurnoverRange').val('1200万-2000万');
            } else if (val > 2000 && val <= 5000) {
                $('#Shipper_AnnualTurnoverRange').val('2000万-5000万');
            } else if (val > 5000 && val <= 10000) {
                $('#Shipper_AnnualTurnoverRange').val('5000万-1亿');
            } else if (val > 10000) {
                $('#Shipper_AnnualTurnoverRange').val('1亿以上');
            }
        } else {
            $('#Shipper_AnnualTurnoverRange').val('');
        }
    });

    $('#Shipper_WarehouseArea').keyup(function () {
        var val = parseInt($(this).val());
        if (val) {
            if (val <= 300) {
                $('#Shipper_WarehouseAreaRange').val('300以内');
            } else if (val > 300 && val <= 500) {
                $('#Shipper_WarehouseAreaRange').val('300-500');
            } else if (val > 500 && val <= 800) {
                $('#Shipper_WarehouseAreaRange').val('500-800');
            } else if (val > 800 && val <= 1000) {
                $('#Shipper_WarehouseAreaRange').val('800-1000');
            } else if (val > 1000 && val <= 1500) {
                $('#Shipper_WarehouseAreaRange').val('1000-1500');
            } else if (val > 1500 && val <= 2000) {
                $('#Shipper_WarehouseAreaRange').val('1500-2000');
            } else if (val > 2000) {
                $('#Shipper_WarehouseAreaRange').val('2000以上');
            }
        } else {
            $('#Shipper_AnnualTurnoverRange').val('');
        }
    });

    $('#Shipper_TrunkOfVehicle').keyup(function () {
        var val = parseInt($(this).val());
        if (val) {
            if (val <= 8) {
                $('#Shipper_TrunkOfVehicleRange').val('8辆以下');
            } else if (val > 8 && val <= 12) {
                $('#Shipper_TrunkOfVehicleRange').val('8辆-12辆');
            } else if (val > 12 && val <= 18) {
                $('#Shipper_TrunkOfVehicleRange').val('12-18辆');
            } else if (val > 18 && val <= 25) {
                $('#Shipper_TrunkOfVehicleRange').val('18-25辆');
            } else if (val > 25) {
                $('#Shipper_TrunkOfVehicleRange').val('25辆以上');
            } 
        } else {
            $('#Shipper_AnnualTurnoverRange').val('');
        }
    });

    $('#Shipper_DeliveryOfVehicle').keyup(function () {
        var val = parseInt($(this).val());
        if (val) {
            if (val <= 8) {
                $('#Shipper_DeliveryOfVehicleRange').val('8辆以下');
            } else if (val > 8 && val <= 12) {
                $('#Shipper_DeliveryOfVehicleRange').val('8辆-12辆');
            } else if (val > 12 && val <= 18) {
                $('#Shipper_DeliveryOfVehicleRange').val('12-18辆');
            } else if (val > 18 && val <= 25) {
                $('#Shipper_DeliveryOfVehicleRange').val('18-25辆');
            } else if (val > 25) {
                $('#Shipper_DeliveryOfVehicleRange').val('25辆以上');
            }
        } else {
            $('#Shipper_AnnualTurnoverRange').val('');
        }
    });

    $('#submitButton').click(function () {
        if ($('#ViewType').val() === '1' && $('#Shipper_Name').val() === '') {
            BasicFramework.Alert('请输入企业名称');
            return false;
        }
    });
});

function onRegionSelected(rid, rn, treeId) {
    $('#Shipper_Attribution').val($('#attributionName').attr('value'));
}

function onRegionAutoCompleteSelected(globalID) {
    $('#Shipper_Attribution').val($('#attributionName').attr('value'));
}