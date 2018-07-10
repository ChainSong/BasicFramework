$(document).ready(function () {
    $('#driversInfoTable').find('#UpdateCRMDriver').live('click', function () {
        var crmID = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        window.location.href = "/ShipperManagement/Driver/CreateOrUpdate?id=" + crmID + "&type=3";
        //$.send(
        //    '/CRM/Crm/CrmBasView2',
        //    { id: crmID });

    });

    $('#driversInfoTable').find('#deleteCRMDriver').live('click', function () {
        var driverID = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        $.send(
            '/ShipperManagement/Driver/DeleteCRMDriver',
            { id: driverID },
            function (response) {
                if (response.IsSuccess) {
                    tr.remove();
                }
                BasicFramework.Alert(response.Message);
            },
            function () {
                BasicFramework.Alert("删除司机信息失败，请联系IT");
            });
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

});