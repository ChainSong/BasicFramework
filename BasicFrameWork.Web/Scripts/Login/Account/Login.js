function showMsg(msg, time) {
    document.getElementsByClassName("popMsg")[0].innerText = msg;
    document.getElementsByClassName("popMsg")[0].style.display = "block";
    setTimeout(hideMsg, time);
}

function hideMsg() {
    document.getElementsByClassName("popMsg")[0].style.display = "none";
}

var pid = "";

function login() {
    var user = document.getElementById("txtUser");
    var pwd = document.getElementById("txtPwd");
    if (user.value == "") {
        showMsg("请输入用户名！", 2000);
        return false;
    }
    if (pwd.value == "") {
        showMsg("请输入密码！", 2000);
        return false;
    }

    return true;
}

