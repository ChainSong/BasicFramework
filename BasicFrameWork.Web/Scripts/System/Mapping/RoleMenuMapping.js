$(function () {
    var setting = {
        view: { selectedMulti: false },
        check: { enable: true },
        data: {
            key: { checked: 'isChecked' },
            simpleData: { enable: true }
        },
        view: {
            fontCss: {
                color: "#666",
                'font-size': '25px'
            },
            showIcon: false
        }
    };

    $.fn.zTree.init($('#menuTree'), setting, Menus);

    $("#RoleID").change(function () {
        var roleID = $(this).val();

        if (roleID == '') {
            roleID = '0';
        }

        $.send(
            '/System/Mapping/GetRoleMenuJsonString',
            {
                id: roleID
            },
            function (response) {
                var menu = JSON.parse(response);
                $.fn.zTree.init($('#menuTree'), setting, menu);
            },
            function (error) {
                showMsg('系统异常,请联系IT', 2000);
            });
    });

    function Refresh() {
        window.location = Url + $("#Role").val();
    }

    $('#submitRoleMenu').live('click',function () {
        if ($("#RoleID").val() === "") {
            showMsg('请选择角色', 2000);
            return;
        }
        $.send(
            '/System/Mapping/SetRoleMenu',
            { roleID: $("#RoleID").val(), MenuItems: GetCheckedItemIDs() },

            function (response) {
                showMsg('角色菜单设置成功', 2000);
            },

            function () {
                showMsg('系统异常,请联系IT', 2000);
            });
    });

    function GetCheckedItemIDs() {
        var ids = [];
        $.each($.fn.zTree.getZTreeObj("menuTree").getCheckedNodes(), function (i, o) {
            ids.push(o.id);
        });
        return ids;
    }
});

