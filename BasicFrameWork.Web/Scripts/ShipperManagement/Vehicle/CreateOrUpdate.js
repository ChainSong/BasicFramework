$(document).ready(function () {

    //挂车选择
    $('select[id=Vehicle_CarType]').live('change', function () {
        if ($("#Vehicle_CarType").val() == '挂车') {
            $("#guache").show();
        } else {
            $("#guache").hide();
        }
    });

    if ($("#Vehicle_CarType").val() == "挂车") {
        $("#guache").show();
    } else {
        $("#guache").hide();
    }


    //提交
    $('#submitButton').click(function () {
        if (checkInput()) {
            return true;
        } else {
            return false;
        }
    });

    //查询返回
    $('#returnButton').live('click', function () {
        //window.location.href = '/ShipperManagement/Vehicle/Index?useSession=true';
        // window.location.href = "/ShipperManagement/Vehicle/Index";
        window.location.href = "/ShipperManagement/Vehicle/Index?MenuID=1013";
    });
    $('rtnButton').live('click', function () {
        window.history.back();
    });


    $('#driverView').on('click', function () {
        window.location.href = "/ShipperManagement/Driver/Index?CarNo=" + $('#Vehicle_CarNo')[0].value;
    });
    //<a href ="/ShipperManagement/Driver/Index?CarNo="+@driver.VehicleNo+"type=1">@driver.DriverName</a>
    

});


//输入信息
var checkInput = function () {

    //判断车牌号码是否为空
    if ($('#Vehicle_CarNo').val() == "") {
        BasicFramework.Alert("请输入车牌号码");
        return false;
    }

    //限制输入的车牌号码为7位
    if ($('#Vehicle_CarNo').val().length < 7 || $('#Vehicle_CarNo').val().length > 7) {
        BasicFramework.Alert("请输入正确的7位车牌号码");
        return false;
    }
    
    //判断营运证号是否为空
    if ($('#Vehicle_RunNo').val() == "") {
        BasicFramework.Alert("请输入营运证号");
        return false;
    }
    //判断车型编码是否为空 你
    if ($('#Vehicle_CarTypeNo').val() == "") {
        BasicFramework.Alert("请输入车型编码");
        return false;
    }
    //判断车辆VIN是否为空
    if ($('#Vehicle_CarVin').val() == "") {
        BasicFramework.Alert("请输入车辆VIN");
        return false;
    }
    if ($('#Vehicle_CarVin').val().length < 17) {
        BasicFramework.Alert("请输入正确的17位车辆VIN")
        return false;
    }

    //判断物流公司是否为空
    if ($('#Vehicle_LogisticCompany').val() == "") {
        BasicFramework.Alert("请输入物流公司");
        return false;
    }
    //判断物流公司安全专员联系电话是否为空
    if ($('#Vehicle_SecurityContactNum').val() == "") {
        BasicFramework.Alert("请输入物流公司安全专员联系电话");
        return false;
    }

    //判断已行驶公里数是否为空
    if ($('#Vehicle_DrivedJourney').val() == "") {
        BasicFramework.Alert("请输入已行驶公里数");
        return false;
    }

    if ($('#Vehicle_DrivedJourney').val() == 0) {
        BasicFramework.Alert("请输入已行驶公里数");
        return false;
    }
    //判断资质是否为空
    if ($('#Vehicle_Qualify').val() == "") {
        BasicFramework.Alert("请输入资质");
        return false;
    }


    //判断车身颜色是否为空
    if ($('#Vehicle_CarBodyColor').val() == "") {
        BasicFramework.Alert("请输入车身颜色");
        return false;
    }
    //判断生产厂家是否为空
    if ($('#Vehicle_Manufacturer').val() == "") {
        BasicFramework.Alert("请输入生产厂家");
        return false;
    }

    //判断整备质量是否为空
    if ($('#Vehicle_EntireCarWeight').val() == "") {
        BasicFramework.Alert("请输入整备质量");
        return false;
    }

    if ($('#Vehicle_EntireCarWeight').val() == 0) {
        BasicFramework.Alert("请输入整备质量");
        return false;
    }

    if ($('#Vehicle_BoardlotDate').val() == "") {
        BasicFramework.Alert("请选择上牌日期");
        return false;
    }

    if ($('#Vehicle_NextYearCheckDate').val() == "") {
        BasicFramework.Alert("请选择下次年检日期");
        return false;
    }

    if ($('#Vehicle_StartServiceDate').val() == "") {
        BasicFramework.Alert("请选择加入虹迪服务时间");
        return false;
    }

    if ($('#Vehicle_InsuranceEndDate').val() == "") {
        BasicFramework.Alert("请选择保险有效截至日期");
        return false;
    }

    return true;
}






//联系电话为数字且最大长度为11位
$(function () {
    $('#Vehicle_SecurityContactNum').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
    $('#Vehicle_SecurityContactNum').attr({ maxlength: "11" });
});

//已行驶公里数
$(function () {
    $('#Vehicle_DrivedJourney').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
});

//整备质量
$(function () {
    $('#Vehicle_EntireCarWeight').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
});

//限制资质输入为文字
$(function () {
    $('#Vehicle_Qualify').keyup(function () {
        this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
    })
});

////限制物流公司输入为文字
//$(function () {
//    $('#CRMVehicle_LogisticCompany').keyup(function () {
//        this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
//    })
//});

//限制车身颜色输入为文字
$(function () {
    $('#Vehicle_CarBodyColor').keyup(function () {
        this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
    })
});

////限制生产厂家输入为文字
//$(function () {
//    $('#CRMVehicle_Manufacturer').keyup(function () {
//        this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
//    })
//});


//车辆VIN为17位
$(function () {

    $('#Vehicle_CarVin').attr({ maxlength: "17" });

});

//核载为数字
$(function () {
    $('#Vehicle_LoadWeight').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
});

//核定人数为数字
$(function () {
    $('#Vehicle_LoadPerson').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
});

//总质量
$(function () {
    $('#Vehicle_TotalWeight').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
});

//牵引总质量
$(function () {
    $('#Vehicle_TractionWeight').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
});


