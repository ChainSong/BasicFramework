if (!window.jQuery) $ = { fn: {} };

$.send = function (url, data, success, error) {
    jQuery.ajax({
        url: url,
        type: "post",
        contentType: "application/json;charset=utf-8",
        data: data ? JSON.stringify(data) : '',
        success: success,
        error: error
    });
};

BasicFramework = window.BasicFramework || {};
//Runbow.TWS = window.Runbow.TWS || {};
BasicFramework.Popup = window.BasicFramework.Popup || {
    show: function (options) {
        var _popup = $('#tws-popup');
        var _opts = $.extend({
            color: "#000000",
            content: [],
            buttons: [],
            displayLoading: false,
            close: null,
            type: "normal",
            title:""
        }, options);

        $("#dialog:ui-dialog").dialog("destroy");

        var width = _opts.width === "" ? 400 : _opts.width;
        var minHeight = _opts.minHeight === "" ? 300 : _opts.minHeight;
        _popup.dialog({
            width: width,
            minHeight: minHeight,
            modal: true,
            title: _opts.title,
            buttons: _opts.buttons,
            beforeClose: _opts.close,
            open: function () { }
        }).data("options", _opts);

        $("#popup-content").html('');
        $.each(_opts.content, function (index, element) {
            $("#popup-content").append(element);
        });
    },
    close: function () {
        $("#tws-popup").dialog("destroy");
    },
    getOptions: function () {
        return $("#tws-popup").data("options");
    },
    find: function (selector) {
        return $("#tws-popup").find(selector);
    }
};

BasicFramework.Alert = function (message,callback) {
    var opts = {
        'title': '提示',
        'content': message,
        'buttons': {
            "确定": function () {
                BasicFramework.Popup.close();
                if (callback) {
                    callback();
                }
            }
        },
        'width': '300',
        'minHeight': '200'
    };
    BasicFramework.Popup.show(opts);
}

Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

Date.prototype.addDays = function (d) {
    this.setDate(this.getDate() + d);
};

Date.prototype.addWeeks = function (w) {
    this.addDays(w * 7);
};

Date.prototype.addMonths = function (m) {
    var d = this.getDate();
    this.setMonth(this.getMonth() + m);
    if (this.getDate() < d)
        this.setDate(0);
};

Date.prototype.addYears = function (y) {
    var m = this.getMonth();
    this.setFullYear(this.getFullYear() + y);
    if (m < this.getMonth()) {
        this.setDate(0);
    }
};

/*-----------------------------------------------Chaomin--------------------------------------*/
function showMsg(msg, time) {
    document.getElementsByClassName("popMsg")[0].innerText = msg;
    document.getElementsByClassName("popMsg")[0].style.display = "block";
    setTimeout(hideMsg, time);
}

function hideMsg() {
    document.getElementsByClassName("popMsg")[0].style.display = "none";
}

function showMask() {
    document.getElementsByClassName("mask")[0].style.display = "block";
    document.documentElement.style.overflow = 'hidden';
    document.body.style.overflow = 'hidden';//手机版设置这个。
}

function hideMask() {
    document.getElementsByClassName("mask")[0].style.display = "none";
    document.documentElement.style.overflow = 'visible';
    document.body.style.overflow = 'visible';//手机版设置这个。
}



parent.document.getElementById("myIframe").style.display = "none";

$(document).ready(function () {
    var canAdd = $('#CanAdd').val();
    var canDelete = $('#CanDelete').val();
    var canEdit = $('#CanEdit').val();
    var canExport = $('#CanExport').val();

    if (canAdd == 'false') {
        $('.AddButton').hide();
    }

    if (canEdit == 'false') {
        $('.EditButton').hide();
    }

    if (canDelete == 'false') {
        $('.DeleteButton').hide();
    }

    if (canExport) {
        $('.ExportButton').hide();
    }
});
