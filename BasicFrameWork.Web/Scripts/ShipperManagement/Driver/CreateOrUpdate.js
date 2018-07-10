$(document).ready(function () {

    $('#submitButton').click(function () {
        if (checkInput()) {
            return true;
        } else {
            return false;
        }
    });

    $('#btnReturn').click(function () {
        window.location.href = "/ShipperManagement/Driver/Index";
            
    })
             

     //$('#returnButton').live('click', function () {
     //    window.location.href = '/ShipperManagement/DriverManagement/Index?useSession=true';

     //});

     //$('#returnbutton').live('click', function () {
     //    window.location.href = '/ShipperManagement/DriverManagement/Index';
     //});

    //查询返回
     $('#returnButton').live('click', function () {
         window.location.href = '/ShipperManagement/Driver/Index?MenuID=1014';
        // window.history.back();
     });

    ////提交返回
    // $('#returnbutton').live('click', function () {
    //     window.location.href = '/shippermanagement/driverManagement/Index';
    // });
});


   



//输入信息
var checkInput = function () {
    if ($('#Driver_DriverName').val() == "") {
        BasicFramework.Alert("请输入司机姓名");
        return false;
    }
    

    if ($('#Driver_DriverBirthday').val() == "") {
        BasicFramework.Alert("请选择出生日期");
        return false;
    }

    if ($('#Driver_DriverPhone').val() == "") {
        BasicFramework.Alert("请输入联系电话");
        return false;
    }

    if ($('#Driver_DriverStartServeForRunbowDate').val() == "") {
        BasicFramework.Alert("请选择开始为虹迪服务时间");
        return false;
    }

    if ($('#Driver_DriverIDCard').val() == "") {
        BasicFramework.Alert("请输入身份证号码");
        return false;
    }
    if ($('#Driver_DriverIDCard').val().length != 15 && $('#Driver_DriverIDCard').val().length != 18) {
        BasicFramework.Alert("请输入正确的15位或者18位身份证号码");
        return false;
    }

    if ($('#Driver_DriverCardNo').val() == "") {
        BasicFramework.Alert("请输入驾驶证档案号");
        return false;
    }

    if ($('#Driver_DriverLogisticsCompany').val() == "") {
        BasicFramework.Alert("请输入物流公司");
        return false;
    }


    if ($('#Driver_DriverLogisticsContactPerson').val() == "") {
        BasicFramework.Alert("请输入物流公司联系人");
        return false;
    }

    

    if ($('#Driver_DriverLogisticsCompanyContactPhone').val() == "") {
        BasicFramework.Alert("请输入物流公司联系电话");
        return false;
    }

    if ($('#Driver_DriverCarNo').val() == "") {
        BasicFramework.Alert("请输入驾驶车辆牌号");
        return false;
    }
    if ($('#Driver_DriverCarNo').val().length > 7 || $('#Driver_DriverCarNo').val().length < 7){
        BasicFramework.Alert("请输入正确的车辆牌号");
        return false;
    }

    if ($('#Driver_DriverRegistrationNo').val() == "") {
        BasicFramework.Alert("请输入司机登记号");
        return false;
    }

    if ($('#Driver_DriverRegistrationCardSignedAddress').val() == "") {
        BasicFramework.Alert("请输入登记证签发地");
        return false;
    }

    if ($('#Driver_DriverNextYearCheckDate').val() == "") {
        BasicFramework.Alert("请选择下次年审日期");
        return false;
    }

    if ($('#Driver_DriverFirstTimeGetCardDate').val() == "") {
        BasicFramework.Alert("请选择初次驾照领证日期");
        return false;
    }

    if ($('#Driver_DriverNextYearCheckBodyDate').val() == "") {
        BasicFramework.Alert("请选择下次体检日期");
        return false;
    }

    if ($('#Driver_DriverServiceArea').val() == "") {
        BasicFramework.Alert("请输入服务区域");
        return false;
    }


    if ($('#Driver_DriverMainRoute').val() == "") {
        BasicFramework.Alert("请输入主要行驶路线");
        return false;
    }

    
    return true;
}

//联系电话
$(function () {
    $('#Driver_DriverPhone').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
    $('#Driver_DriverPhone').attr({ maxlength: "11" });
});

//身份证号码
$(function () {
    
////    if ($('#CreateDriver_DriverIDCard').val().length == 15 || $('#CreateDriver_DriverIDCard').val().length == 18) {
////        return true;
////    }
////    else {
////        alert("请输入正确的身份证号码");
////        return false;
////    }
    $('#Driver_DriverIDCard').attr({ maxlength: "18" });
});


////限制物流公司输入为文字
//$(function () {
//    $('#CreateDriver_DriverLogisticsCompany').keyup(function () {
//        this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
//    })
//});

//物流公司联系电话
$(function () {
    $('#Driver_DriverLogisticsCompanyContactPhone').keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '')
    });
    //$('#CreateDriver_DriverLogisticsCompanyContactPhone').attr({ maxlength: "11" });
});

////限制司机姓名为文字
//$(function () {
//$('#CreateDriver_DriverName').keyup(function () {
//    this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
//})
//});

////登记证签发地
//$(function () {
//    $('#CreateDriver_DriverRegistrationCardSignedAddress').keyup(function () {
//        this.value = this.value.replace(/[^\u4E00-\u9FA5]/, '')
//    })
//});