$(document).ready(function () {

    $('#btnSubmit').click(function () {
        if ($('#User_Name').val() == "") {
            showMsg('登陆名称不能为空', 2000);
            return false;
        }

        if ($('#User_DisplayName').val() == "") {
            showMsg('显示名称不能为空', 2000);
            return false;
        }

        if ($('#User_ID').val() == '0' && $('#User_Password').val() == '') {
            showMsg('密码不能为空', 2000);
            return false;
        }

        $.send(
            '/System/User/CreateOrUpdate',
            {
                ID: $('#User_ID').val(),
                Name: $('#User_Name').val(),
                DisplayName: $('#User_DisplayName').val(),
                Password: $('#User_Password').val(),
                State: $('#User_State').val(),
                Sex: $('#User_Sex').val(),
                Tel: $('#User_Tel').val(),
                Mobile: $('#User_Mobile').val(),
                Email: $('#User_Email').val(),
                CreateDate: $('#User_CreateDate').val(),
                UserType: $('#User_UserType').val(),
                OriginalPassword: $('#OriginalPassword').val()
            },
            function (response) {
                if (response.Error) {
                    showMsg(response.Error, 2000);
                    return;
                }

                window.location.href = '/System/User/Index';
            },
            function (error) {
                showMsg('系统异常,请联系IT', 2000);
            });

    });

    $('#btnReturn').click(function () {
        window.history.back();
    });

});
