function popou(url) {
    var img = document.getElementsByTagName('img')[0]

    getNaturalWidth(img);

    function getNaturalWidth(img) {

        var image = new Image()

        image.src = img.src

        var naturalWidth = image.width;
        var naturalHeight = image.height;


        document.getElementById("pictrue").src = url;
        $("#pictrue").attr("Width", 248)
        $("#pictrue").attr("Height", (naturalHeight * 250) / naturalWidth)
        openPopup("", true, 250, (naturalHeight * 250) / naturalWidth, null, "pupupss", null,setTop);

    }
}

function setTop() {
    $("#pictrue").parent().parent().css("top", "100px");
}
 
//关闭div
$("#pupupss").click(function () {
    closePopup("pupupss");
    document.getElementById("pictrue").src = "";
})
function closeimage() {
    closePopup("pupupss");
    document.getElementById("pictrue").src = "";
}

