$(document).ready(function () {
    $('#insertTransportationLine').click(function () {
        if ($('#Name').val() === '') {
            BasicFramework.Alert('请输入客户名称');
            return;
        }
    });


    $('#resultTable').find('.deleteCRMShipperCooperation').live('click', function () {
        var id = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        $.send(
            '/ShipperManagement/Shipper/DeleteCRMShipperCooperation',
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