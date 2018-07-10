$(function () {
    var setting = { view: { selectedMulti: false }, check: { enable: true }, data: { key: { checked: 'isChecked' }, simpleData: { enable: true } } };
    $.fn.zTree.init($('#menuTree'), setting, Menus);
    $("#Role").change(function () {
        Refresh();
    });

    function Refresh() {
        window.location = Url + $("#Role").val();
    }

    $('#submitProjectRoleMenu').click(function () {
        if ($("#Role").val() === "") {
            BasicFramework.Alert("请选择角色");
            return;
        }
        $.send(
            Url,
            { ProjectRoleID: $("#Role").val(), MenuItems: GetCheckedItemIDs() },
            function (response) {
                BasicFramework.Alert(response, Refresh);
            },
            function () {
                BasicFramework.Alert("角色菜单设置失败，请联系IT");
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

