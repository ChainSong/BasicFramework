function closePopup(a, b, c, d, e, name, force) {
    if (force == undefined)
        force = true;

    $.closePopupLayer(name, force, a, b, c, d, e);
}
function IsNullOrEmpty(obj) {
    try {
        if (obj.length == 0) {
            return true;
        }

        return false;
    }
    catch (e) {
        if (!obj) {
            return true;
        }

        if (typeof obj == "undefined") {
            return true;
        }

        if (typeof obj == "string" && trimStr(obj) == "") {
            return true;
        }

        if (typeof obj == "number" && isNaN(obj))
            return true;

        return false;
    }
}
//获取一个随机整数
function randomNumber(digits) {
    return Math.round((Math.random() + 1) * Math.pow(10, digits - 1));
}
function openPopup(name, modal, width, height, url, target, afterClose) {

    if (IsNullOrEmpty(name))
        name = randomNumber(5);

    $.openPopupLayer({
        name: name,
        modal: modal,
        width: width,
        height: height,
        target: target,
        url: url,
        afterClose: afterClose
    }, false);
}