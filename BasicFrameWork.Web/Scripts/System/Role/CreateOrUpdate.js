$(document).ready(function () {

    $('#btnSubmit').click(function () {
        if ($('#Role_Name').val() == "") {
            showMsg('角色名称不能为空', 2000);
            return false;
        }

        $.send(
            '/System/Role/CreateOrUpdate',
            {
                id: $('#Role_ID').val(),
                Name: $('#Role_Name').val(),
                Description: $('#Role_Description').val(),
                State: $('#Role_State').val(),
                CreateDate: $('#Role_CreateDate').val()
            },
            function (response) {
                if (response.Error) {
                    showMsg(response.Error, 2000);
                    return;
                }

                window.location.href = '/System/Role/Index';
            },
            function (error) {
                showMsg('系统异常,请联系IT', 2000);
            });

    });

    $('#btnReturn').click(function () {
        window.history.back();
    });

});
