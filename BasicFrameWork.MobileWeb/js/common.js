function showMsg(msg,time) {
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