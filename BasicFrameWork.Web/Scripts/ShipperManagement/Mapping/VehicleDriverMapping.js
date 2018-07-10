$(document).ready(function () {

    $("li").click(function () {
        var str = $(this)[0].id;
        var li = this;
        var where = this.children[0].style.color == "red" ? "del" : "ins";

        $.ajax({
            url: "/ShipperManagement/Mapping/AddOrUpdateVehicleDriverMapping",
            type: "POST",

            data: { vehicleno: $("#VehicleNo").val(), drivername: str, where: where },
            success: function (response) {
                if (response == "True") {
                    li.children[0].style.color == "red" ? li.children[0].style.color = "#2e6da4" : li.children[0].style.color = "red";
                    showMsg("提交成功！", 2000);

                }
                else {
                    showMsg("提交失败！", 2000);
                }
            },
            error: function (e) {
                BasicFramework.Alert("失败");
            }
        });
    });

})
