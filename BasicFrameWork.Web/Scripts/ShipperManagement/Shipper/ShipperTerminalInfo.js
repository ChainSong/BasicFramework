$(document).ready(function () {    
    $('#TerminalWareHouseArea').keyup(function () {
        var val = parseInt($(this).val());
        if (val) {
            if (val <= 300) {
                $('#TerminalWareHouseAreaRange').val('300以内');
            } else if (val > 300 && val <= 500) {
                $('#TerminalWareHouseAreaRange').val('300-500');
            } else if (val > 500 && val <= 800) {
                $('#TerminalWareHouseAreaRange').val('500-800');
            } else if (val > 800 && val <= 1000) {
                $('#TerminalWareHouseAreaRange').val('800-1000');
            } else if (val > 1000 && val <= 1500) {
                $('#TerminalWareHouseAreaRange').val('1000-1500');
            } else if (val > 1500 && val <= 2000) {
                $('#TerminalWareHouseAreaRange').val('1500-2000');
            } else if (val > 2000) {
                $('#TerminalWareHouseAreaRange').val('2000以上');
            }
        } else {
            $('#TerminalWareHouseAreaRange').val('');
        }
    });

    $('#resultTable').find('.deleteCRMShipperTerminalInfo').live('click', function () {
        var id = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        $.send(
            '/ShipperManagement/ShipperManagement/DeleteCRMShipperTerminalInfo',
            { id: id },
            function (response) {
                if (response.IsSuccess) {
                    tr.remove();
                } else {
                    BasicFramework.Alert(response.Message);
                }
            },
            function () {
                BasicFramework.Alert("删除失败，请联系IT");
            });
    });

    $('#return').click(function () {
        var id = $('#CRMShipperID').val();
        var ViewType = $('#ViewType').val();
        window.location.href = '/ShipperManagement/Shipper/CreateOrUpdate/' + id + '?ViewType=' + ViewType;
    });
});