$(document).ready(function () {
    $('#shippersInfoTable').find('#btnEdit').live('click', function () {
        var crmID = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        window.location.href = "/ShipperManagement/Shipper/CreateOrUpdate?id=" + crmID + "&ViewType=2";
    });

   // onclick ="javascript: window.location.href = '/ShipperManagement/Mapping/ShipperVehicleMapping/@shipper.ID'

    $('#btnVehicleAllocate').live('click', function () {
        var id = $(this).attr('data-id');
        var name = $(this).attr('data-name');
        window.location.href = "/ShipperManagement/Mapping/ShipperVehicleMapping?id=" + id + "&name=" +name ;


    });


    $('#attributionName').attr('value', $('#SearchCondition_Attribution').val());
    $('#startPlaceName').attr('value', $('#SearchCondition_StartPlaceNames').val());
    $('#startPlaceID').attr('value', $('#SearchCondition_StartPlaceIDs').val());
    $('#endPlaceName').attr('value', $('#SearchCondition_EndPlaceNames').val());
    $('#endPlaceID').attr('value', $('#SearchCondition_EndPlaceIDs').val());
    $('#coverRegionName').attr('value', $('#SearchCondition_CoverRegionNames').val());
    $('#coverRegionID').attr('value', $('#SearchCondition_CoverRegionIDs').val());

    $('#AttributionClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#SearchCondition_Attribution').val('');
    });

    $('#StartPlaceClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#SearchCondition_StartPlaceIDs').val('');
        $('#SearchCondition_StartPlaceNames').val('');
    });

    $('#EndPlaceClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#SearchCondition_EndPlaceNames').val('');
        $('#SearchCondition_EndPlaceIDs').val('');
    });

    $('#CoverRegionClear').click(function () {
        $(this).prev().find('.RegionName').val('');
        $(this).prev().find('.RegionID').val('');
        $('#SearchCondition_CoverRegionNames').val('');
        $('#SearchCondition_CoverRegionIDs').val('');
    });

    $('#shippersInfoTable').find('#deleteCRMShipper').live('click', function () {
        var shipperID = $(this).attr('data-id');
        var tr = $(this).parent().parent();
        $.send(
            '/ShipperManagement/Shipper/DeleteCRMShipper',
            { id: shipperID },
            function (response) {
                if (response.IsSuccess) {
                    tr.remove();
                }
                BasicFramework.Alert(response.Message);
            },
            function () {
                BasicFramework.Alert("删除承运商失败，请联系IT");
            });
    });

    document.getElementById("attributionName").className = "form-control";
    document.getElementById("startPlaceName").className = "form-control";
    document.getElementById("endPlaceName").className = "form-control";
    document.getElementById("coverRegionName").className = "form-control";



});


function onRegionSelected(rid, rn, treeId) {
    if (treeId === 'attributionTreeKey') {
        $('#SearchCondition_Attribution').val($('#attributionName').attr('value'));
    } else if (treeId === 'startPlaceTreeKey') {
        $('#SearchCondition_StartPlaceNames').val($('#startPlaceName').attr('value'));
        $('#SearchCondition_StartPlaceIDs').val($('#startPlaceID').attr('value'));
    } else if (treeId === 'endPlaceTreeKey') {
        $('#SearchCondition_EndPlaceNames').val($('#endPlaceName').attr('value'));
        $('#SearchCondition_EndPlaceIDs').val($('#endPlaceID').attr('value'));
    } else if (treeId === 'coverRegionTreeKey') {
        $('#SearchCondition_CoverRegionNames').val($('#coverRegionName').attr('value'));
        $('#SearchCondition_CoverRegionIDs').val($('#coverRegionID').attr('value'));
    }

}

function onRegionAutoCompleteSelected(treeId) {
    if (treeId === 'attributionTreeKey') {
        $('#SearchCondition_Attribution').val($('#attributionName').attr('value'));
    } else if (treeId === 'startPlaceTreeKey') {
        $('#SearchCondition_StartPlaceNames').val($('#startPlaceName').attr('value'));
        $('#SearchCondition_StartPlaceIDs').val($('#startPlaceID').attr('value'));
    } else if (treeId === 'endPlaceTreeKey') {
        $('#SearchCondition_EndPlaceNames').val($('#endPlaceName').attr('value'));
        $('#SearchCondition_EndPlaceIDs').val($('#endPlaceID').attr('value'));
    } else if (treeId === 'coverRegionTreeKey') {
        $('#SearchCondition_CoverRegionNames').val($('#coverRegionName').attr('value'));
        $('#SearchCondition_CoverRegionIDs').val($('#coverRegionID').attr('value'));
    }
}


window.onload = function ()
{
    var attributionName = document.getElementById("attributionName");
    var startPlaceName = document.getElementById("startPlaceName");
    var endPlaceName =document.getElementById("endPlaceName");
    var coverRegionName = document.getElementById("coverRegionName");
    removeClass(attributionName, "form-control");
    removeClass(startPlaceName, "form-control");
    removeClass(endPlaceName, "form-control");
    removeClass(coverRegionName, "form-control")
}

function hasClass(elements, cName) {
    return !!elements.className.match(new RegExp("(\\s|^)" + cName + "(\\s|$)"));
}

function removeClass(elements, cName) {
    if (hasClass(elements, cName)) {
        elements.className = elements.className.replace(new RegExp("(\\s|^)" + cName + "(\\s|$)"), " ");
    }
}
