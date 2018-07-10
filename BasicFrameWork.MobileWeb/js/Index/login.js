var pid = "";

////if (document.getElementById("txtUser").value != "")
//{
//    document.getElementById("txtUser").focus();
//}

function login() {
    var user = document.getElementById("txtUser");
    var pwd = document.getElementById("txtPwd");
  
    if (user.value == "") {
        showMsg("请输入用户名！",2000);
        return;
    }
    if (pwd.value == "") {
        showMsg("请输入密码！", 2000);
        return;
    }
    if (pid == "") {
        showMsg("该账户没有分配项目！", 2000);
        return;
    }

    /*ajax请求登陆*/
    $.ajax({
        type: 'post',
        url: '/Login/CheckLogin?name=' + user.value + '&pwd=' + pwd.value + '&pid=' + pid,
        data: {},
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.flag.toString() == "1") {
                window.location.href = "/Index/Index";
            }
            else {
                showMsg(data.msg, 2000);
                user.value = "";
                pwd.value = "";
                pid = "";
            }
        },
        error: function () {
            showMsg("请求出错！", 2000);
        }
    });
    
}

function checkUser(obj) {
    pid = "";
    var user = obj.value;
    if (user == "") {
        showMsg("请输入用户名！", 2000);
        return;
    }
    $.ajax({
        type: 'post',
        url: '/Login/CheckUser?user='+user,
        data: {},
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.flag.toString() == "1") {
                pid = data.pid;
            }
            else {
                showMsg(data.msg, 2000);
                obj.value = "";
            }
        },
        error: function () {
            showMsg("请求出错！", 2000);
        }
    });
}
