$(document).ready(function () {
    $('#StartPlaceClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#StartPlaceName').val('');
        $('#StartPlaceID').val('');
    });

    $('#EndPlaceClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#EndPlaceName').val('');
        $('#EndPlaceID').val('');
    });

    $('#CoverRegionClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#CoverRegionName').val('');
        $('#CoverRegionID').val('');
    });

    $('#insertTransportationLine').click(function () {
        if ($('#StartPlaceID').val() === '') {
            BasicFramework.Alert('请选择起运地');
            return;
        }

        if ($('#EndPlaceID').val() === '') {
            BasicFramework.Alert('请选择目的地');
            return;
        }

        $.send(
            '/ShipperManagement/Shipper/InsertCRMShipperTransportationLine',
            { id: $('#CRMShipperID').val(), StartPlaceID: $('#StartPlaceID').val(), StartPlaceName: $('#StartPlaceName').val(), EndPlaceID: $('#EndPlaceID').val(), EndPlaceName: $('#EndPlaceName').val(), CoverRegionID: $('#CoverRegionID').val(), CoverRegionName: $('#CoverRegionName').val(), Period: $('#Period').val() },
            function (response) {
                if (response.IsSuccess) {
                    var table = $('#resultTable');
                    var lines = jQuery.parseJSON(response.Lines);
                    for (var i = 0; i < lines.length; i++) {
                        var rowStr = "<tr data-id='" + lines[i].ID + "'></tr>";
                        var row = $(rowStr);
                        var td = "<td>" + lines[i].StartCityName + "</td><td>" + lines[i].EndCityName + "</td><td>" + lines[i].CoverRegionName + "</td><td>" + lines[i].Period + "</td><td><a id='deleteCRMShipper' class='deleteCRMShipperTransportationLine' data-id='" + lines[i].ID + "' href='#'>删除</a>";
                        row.append($(td));
                        table.append(row);
                        $('#EndPlaceName').val('');
                        $('#EndPlaceID').val('');
                        $('#StartPlaceName').val('');
                        $('#StartPlaceID').val('');
                        $('#CoverRegionID').val('');
                        $('#CoverRegionName').val('');
                        $('#Period').val('');
                        $('#startPlaceName').attr('value', '');
                        $('#startPlaceID').attr('value', '');
                        $('#endPlaceName').attr('value', '');
                        $('#endPlaceID').attr('value', '');
                        $('#coverRegionID').attr('value', '');
                        $('#coverRegionName').attr('value', '');
                        $('#Period').attr('value', '');
                    }
                } else {
                    BasicFramework.Alert(response.Message);
                }
            },
            function () {
                BasicFramework.Alert("删除失败，请联系IT");
            });
    });


    $('#resultTable').find('.deleteCRMShipperTransportationLine').live('click', function () {
        var id = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        $.send(
            '/ShipperManagement/Shipper/DeleteCRMShipperTransportationLine',
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

function onRegionSelected(rid, rn, treeId) {
    if (treeId === 'startPlaceTreeKey') {
        $('#StartPlaceName').val($('#startPlaceName').attr('value'));
        $('#StartPlaceID').val($('#startPlaceID').attr('value'));
    } else if (treeId === 'endPlaceTreeKey') {
        $('#EndPlaceName').val($('#endPlaceName').attr('value'));
        $('#EndPlaceID').val($('#endPlaceID').attr('value'));
    } else if (treeId === 'coverRegionTreeKey') {
        $('#CoverRegionName').val($('#coverRegionName').attr('value'));
        $('#CoverRegionID').val($('#coverRegionID').attr('value'));
    }
}

function onRegionAutoCompleteSelected(treeId) {
    if (treeId === 'startPlaceTreeKey') {
        $('#StartPlaceName').val($('#startPlaceName').attr('value'));
        $('#StartPlaceID').val($('#startPlaceID').attr('value'));
    } else if (treeId === 'endPlaceTreeKey') {
        $('#EndPlaceName').val($('#endPlaceName').attr('value'));
        $('#EndPlaceID').val($('#endPlaceID').attr('value'));
    } else if (treeId === 'coverRegionTreeKey') {
        $('#CoverRegionName').val($('#coverRegionName').attr('value'));
        $('#CoverRegionID').val($('#coverRegionID').attr('value'));
    }
}
