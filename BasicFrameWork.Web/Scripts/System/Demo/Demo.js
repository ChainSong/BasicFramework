$(function () {
    $('#showDialog').click(function () {
        showCommonDialog();
    });

    function showCommonDialog() {
        var opts = {
            'title': '通用简单dialog',
            'content': $('#showInDialog').clone().show(),
            'buttons': {
                "确定": function () {
                    $('#returnValFromPopup').val(BasicFramework.Popup.find('#selectValues').val());
                    BasicFramework.Popup.close();
                },
                "取消": function () {
                    BasicFramework.Popup.close();
                }
            },
            'width': '400',//default 400
            'minHeight': '300' //default 300
        };
        BasicFramework.Popup.show(opts);

    }
});

var fileInputClick = function () {
    if ($('#inputExcel').val() === '') {
        BasicFramework.Alert('请选择Excel');
        return false;
    }

    var exp = /.xls$|.xlsx$/;
    var fileInput = $('#inputExcel').clone();
    if (exp.exec($('#inputExcel').val()) === null) {
        BasicFramework.Alert('请选择Excel格式的文件');
        $('#inputExcel').remove();
        $(this).before(fileInput);
        return false;
    }
    //因为本页面已经加载过ajaxFileUpload的文件，所以不用再加载了
    WebPortal.MessageMask.Show("处理中...");
    $.ajaxFileUpload({
        url: '/System/Demo/ExcelInput',
        secureuri: false,
        fileElementId: "inputExcel",
        dataType: 'json',
        data: {},
        success: function (data, status) {
            if (data) {
                var returnHtml = '<table id="exportTable"><thead><tr><th>编号</th><th>显示名称</th><th>名称</th><th>密码</th></tr></thead><tbody>';
                for (var i = 0; i < data.length; i++) {
                    returnHtml += '<tr><td>' + data[i].ID + '</td><td>' + data[i].DisplayName + '</td><td>' + data[i].Name + '</td><td>' + data[i].Password + '</td></td>';
                }
                returnHtml += '</tbody></table>';

                $('#outputExcelDiv').html(returnHtml);

                $('<div><a id="exportLink" href="ExportToExcel">导出</a></div>').appendTo($('#outputExcelDiv'));
            }
            WebPortal.MessageMask.Close();

        },
        error: function (data, status, e) {
            BasicFramework.Alert('导入Excel失败');
            WebPortal.MessageMask.Close();
        }
    });
    return false;
};