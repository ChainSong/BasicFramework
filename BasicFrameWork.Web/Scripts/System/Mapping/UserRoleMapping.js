var GetUserRole = function (userName) {
    if (userName == '') {
        return;
    }

    $.send(
        '/System/Mapping/GetRoleIDByUserName',
        { userName: userName },
           function (response) {
               $('.checkForSelect[data-id=' + response + ']').attr('checked', 'checked');
           },
           function () {
               showMsg('获取用户角色失败,请联系IT', 2000);
           });
}

var ClearCheckbox = function () {
    $('.checkForSelect').removeAttr('checked');
}


$(document).ready(function () {
    GetUserRole($('#UserName').val());

    $('#UserName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/System/User/GetApplicationUsersByUserName?userName=" + request.term,
                type: "Get",
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Text, value: item.Text, data: item }
                    }));
                }
            });
        },
        select: function (event, ui) {
            $('#UserID').val(ui.item.data.Value);
            $('#UserName').val(ui.item.data.Text);
            ClearCheckbox();
            GetUserRole($('#UserName').val());

        }
    }).keyup(function () {
        if ($(this).val() === '') {
            $('#UserID').val('');
        }

        ClearCheckbox();
        GetUserRole($('#UserName').val());
    });

    $('.checkForSelect').click(function () {
        if ($(this).attr("checked") === "checked") {
            $('.checkForSelect').removeAttr('checked');
            $(this).attr('checked', 'checked');
        }
    });

    $('#btnSubmit').click(function () {
        var userName = $('#UserName').val();

        if (userName == '') {
            showMsg('用户名称不能为空', 2000);
            return;
        }

        var roleID = '0';

        $('.checkForSelect').each(function (index) {
            if ($(this).attr('checked') === 'checked') {
                roleID = $(this).attr('data-id');
            }
        });

        $.send(
            '/System/Mapping/SetUserRole',
            { userName: userName, roleID: roleID },
               function (response) {
                   showMsg(response, 2000);
               },
               function () {
                   showMsg('用户角色设置有误,请联系IT', 2000); 
               });
    });
});
