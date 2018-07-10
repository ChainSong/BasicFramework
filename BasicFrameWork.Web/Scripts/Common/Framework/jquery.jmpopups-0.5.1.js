/**
* jmpopups
* Copyright (c) 2009 Otavio Avila (http://otavioavila.com)
* Licensed under GNU Lesser General Public License
* 
* @docs http://jmpopups.googlecode.com/
* @version 0.5.1
* 
*/


(function ($) {
    var openedObjects = [];
    var popupLayerScreenLocker = false;
    var focusableElement = [];
    var setupJqueryMPopups = {
        screenLockerBackground: "#000",
        screenLockerOpacity: "0.25"
    };

    $.setupJMPopups = function (settings) {
        setupJqueryMPopups = jQuery.extend(setupJqueryMPopups, settings);
        return this;
    };

    //inThisPage 一般传false，这样会在最上一级父窗口打开弹出窗，以保证所有弹出窗同属于一个父窗口，这样才能显示比上一个窗口大的新窗口。
    //inThisPage = true 的话，则强制在本页面打开。 
    //当传入了target时，则只能在本页面打开。
    $.openPopupLayer = function (settings, inThisPage) {

        if (typeof (settings.name) != "undefined" && !checkIfItExists(settings.name)) {

            settings = jQuery.extend({
                width: "auto",
                height: "auto",
                parameters: {},
                target: "",
                url: "",
                innerIFrame: false,
                success: function () { },
                error: function () { },
                beforeClose: function () { },
                afterClose: function () { },
                reloadSuccess: null,
                cache: false
            }, settings);

            if (settings.innerIFrame) {  //在当前页的IFrame中打开，一般用于数据维护页面列表编辑切换模式

                openInnerIFrame(settings, true);
                return this;
            }
            //如果是打开div，则必须只能在当前窗口打开
            else if (inThisPage || (settings.target && settings.target.length > 0)) {

                loadPopupLayerContent(settings, true);
                return this;
            }
            else {

                var parentWnd = parent;

                for (var i = 0; i < 10; i++) {
                    parentWnd = parent;
                }

                return $.openPopupLayer(settings, true);
            }
        }

        return null;
    };


    $.closePopupLayer = function (name, force, a, b, c, d, e) {

        if (openedObjects.length == 0) {
            if (parent.$.closePopupLayer && parent.location != window.location)
                parent.$.closePopupLayer(name, force, a, b, c, d, e);
        }

        if (name) {
            for (var i = 0; i < openedObjects.length; i++) {
                if (openedObjects[i].name == name) {

                    var thisPopup = openedObjects[i];

                    openedObjects.splice(i, 1);

                    thisPopup.beforeClose();

                    if (thisPopup.innerIFrame) { //如果是以innerIFrame方式打开的
                        $("#innerIFrame_" + name).remove();

                        thisPopup.afterClose(a, b, c, d, e);
                    }
                    else {
                        $("#popupLayer_" + name).fadeOut(200, function () {

                            //inline方式打开的，将div放回原来的地方
                            if (thisPopup.target && thisPopup.target.length > 0) {
                                $("#" + thisPopup.target).append($("#popupInlineDiv").children());
                            }

                            $("#popupLayer_" + name).remove();

                            //                        focusableElement.pop();

                            //                        if (focusableElement.length > 0) {
                            //                            $(focusableElement[focusableElement.length - 1]).focus();
                            //                        }

                            hideScreenLocker(name);

                            if (a === undefined && b === undefined && c === undefined && d === undefined && e === undefined) {

                            }
                            else {
                                thisPopup.afterClose(a, b, c, d, e);
                            }

                        });
                    }

                    break;
                }
            }
        } else {
            if (openedObjects.length > 0) {
                var wnd = openedObjects[openedObjects.length - 1];
                //如果是模式窗口，没有传入名字，没有使用强制模式时，不能删除
                if (!wnd.modal || force)
                    $.closePopupLayer(wnd.name, force, a, b, c, d, e);
            }
        }
    };

    $.popupLayerCallback = function (name, a, b, c, d, e) {

        if (openedObjects.length == 0) {
            if (parent.$.popupLayerCallback && parent.location != window.location)
                return parent.$.popupLayerCallback(name, a, b, c, d, e);
        }

        if (name) {
            for (var i = 0; i < openedObjects.length; i++) {
                if (openedObjects[i].name == name) {

                    var thisPopup = openedObjects[i];

                    if (a === undefined && b === undefined && c === undefined && d === undefined && e === undefined) {

                    }
                    else {
                        return thisPopup.afterClose(a, b, c, d, e);
                    }

                    break;
                }
            }
        } else {
            if (openedObjects.length > 0) {
                var wnd = openedObjects[openedObjects.length - 1];
                return $.popupLayerCallback(wnd.name, a, b, c, d, e);
            }
        }
    };


    $.reloadPopupLayer = function (name, callback) {
        if (name) {
            for (var i = 0; i < openedObjects.length; i++) {
                if (openedObjects[i].name == name) {
                    if (callback) {
                        openedObjects[i].reloadSuccess = callback;
                    }

                    loadPopupLayerContent(openedObjects[i], false);
                    break;
                }
            }
        } else {
            if (openedObjects.length > 0) {
                $.reloadPopupLayer(openedObjects[openedObjects.length - 1].name);
            }
        }

        return this;
    };

    function setScreenLockerSize() {
        if (popupLayerScreenLocker) {
            $('#popupLayerScreenLocker').height($(document).height() + "px");
            $('#popupLayerScreenLocker').width($(document.body).outerWidth(true) + "px");
        }
    }

    function checkIfItExists(name) {
        if (name) {
            for (var i = 0; i < openedObjects.length; i++) {
                if (openedObjects[i].name == name) {
                    return true;
                }
            }
        }
        return false;
    }

    function showScreenLocker() {
        if ($("#popupLayerScreenLocker").length) {
            if (opendPopupCount() == 1) {
                popupLayerScreenLocker = true;
                document.body.parentNode.style.overflow = "hidden";
                setScreenLockerSize();
                $('#popupLayerScreenLocker').fadeIn();
            }

//            if ($.browser.msie && $.browser.version < 7) {
//                $("select:not(.hidden-by-jmp)").addClass("hidden-by-jmp hidden-by-" + openedObjects[openedObjects.length - 1].name).css("visibility", "hidden");
//            }

            $('#popupLayerScreenLocker').css("z-index", 999 + (openedObjects.length - 1) * 2); //parseInt(openedObjects.length == 1 ? 999 : $("#popupLayer_" + openedObjects[openedObjects.length - 2].name).css("z-index")) + 1));
        } else {
            $("body").append("<div id='popupLayerScreenLocker'><!-- --></div>");
            $("#popupLayerScreenLocker").css({
                position: "absolute",
                background: setupJqueryMPopups.screenLockerBackground,
                left: "0",
                top: "0",
                opacity: setupJqueryMPopups.screenLockerOpacity,
                display: "none"
            });
            showScreenLocker();

            $("#popupLayerScreenLocker").click(function () {
                $.closePopupLayer();
            });
        }
    }

    function hideScreenLocker(popupName) {
        if (opendPopupCount() == 0) {
            popupLayerScreenLocker = false;
            $('#popupLayerScreenLocker').fadeOut(200, function () { document.body.parentNode.style.overflow = "auto"; });

        } else {
            $('#popupLayerScreenLocker').css("z-index", 999 + (openedObjects.length - 1) * 2); //parseInt($("#popupLayer_" + openedObjects[openedObjects.length - 1].name).css("z-index")) - 1);
        }

//        if ($.browser.msie && $.browser.version < 7) {
//            $("select.hidden-by-" + popupName).removeClass("hidden-by-jmp hidden-by-" + popupName).css("visibility", "visible");
//        }
    }

    function setPopupLayersPosition(popupElement, animate) {
        if (popupElement) {
            if (popupElement.width() < $(window).width()) {
                var leftPosition = (document.documentElement.offsetWidth - popupElement.width()) / 2;
            } else {
                var leftPosition = document.documentElement.scrollLeft + 5;
            }

            if (popupElement.height() < $(window).height()) {
                var topPosition = document.documentElement.scrollTop + ($(window).height() - popupElement.height()) / 2;
            } else {
                var topPosition = document.documentElement.scrollTop + 5;
            }

            var positions = {
                left: leftPosition + "px",
                top: topPosition + "px"
            };

            if (!animate) {
                popupElement.css(positions);
            } else {
                popupElement.animate(positions, "slow");
            }

            setScreenLockerSize();
        } else {
            for (var i = 0; i < openedObjects.length; i++) {
                setPopupLayersPosition($("#popupLayer_" + openedObjects[i].name), false);
            }
        }
    }

    function showPopupLayerContent(popupObject, newElement, target) {
        var idElement = "popupLayer_" + popupObject.name;

        if (newElement) {
            showScreenLocker();

            $("body").append("<div id='" + idElement + "'><div id='" + idElement + "_title' style='position:absolute;background-color:#eee;height:28px;padding:0;top:-28px;left:-1px;text-align:right;'><span style='display:inline-block;padding:5px 10px 0 0;'><a href='javascript:;' onclick='closePopup();'>关闭</a><span></div><!-- --></div>");

            var zIndex = 1000 + (openedObjects.length - 1) * 2; //parseInt(openedObjects.length == 1 ? 1000 : $("#popupLayer_" + openedObjects[openedObjects.length - 2].name).css("z-index")) + 2;
        } else {
            var zIndex = $("#" + idElement).css("z-index");
        }

        var popupElement = $("#" + idElement);
        var titleElement = $("#" + idElement + '_title');

        popupElement.css({
            visibility: "hidden",
            width: popupObject.width == "auto" ? "" : popupObject.width + "px",
            height: popupObject.height == "auto" ? "" : popupObject.height + "px",
            position: "fixed",
            "z-index": zIndex
        });

        titleElement.css({
            width: popupObject.width == "auto" ? "" : popupObject.width + "px",
            border: "1px solid #333",
            "border-bottom": "none"
        });

        //        var linkAtTop = "<a href='#' class='jmp-link-at-top' style='position:absolute; left:-9999px; top:-1px;'>&nbsp;</a><input class='jmp-link-at-top' style='position:absolute; left:-9999px; top:-1px;' />";
        //        var linkAtBottom = "<a href='#' class='jmp-link-at-bottom' style='position:absolute; left:-9999px; bottom:-1px;'>&nbsp;</a><input class='jmp-link-at-bottom' style='position:absolute; left:-9999px; top:-1px;' />";

        //        popupElement.html(linkAtTop + data + linkAtBottom);

        var inlineDiv = $("<div id='popupInlineDiv' style='padding:10px;'></div>");
        inlineDiv.append($("#" + target).children());

        popupElement.append(inlineDiv);

        setPopupLayersPosition(popupElement);

        popupElement.css("display", "none");
        popupElement.css("visibility", "visible");
        popupElement.css("background-color", "#fff");
        popupElement.css("border", "1px solid #333");
        popupElement.css("border-top", "none");

        if (newElement) {
            popupElement.fadeIn();
        } else {
            popupElement.show();
        }

        /*
        $("#" + idElement + " .jmp-link-at-top, " +
        "#" + idElement + " .jmp-link-at-bottom").focus(function () {
        $(focusableElement[focusableElement.length - 1]).focus();
        });

        var jFocusableElements = $("#" + idElement + " a:visible:not(.jmp-link-at-top, .jmp-link-at-bottom), " +
        "#" + idElement + " *:input:visible:not(.jmp-link-at-top, .jmp-link-at-bottom)");

        if (jFocusableElements.length == 0) {
        var linkInsidePopup = "<a href='#' class='jmp-link-inside-popup' style='position:absolute; left:-9999px;'>&nbsp;</a>";
        popupElement.find(".jmp-link-at-top").after(linkInsidePopup);
        focusableElement.push($(popupElement).find(".jmp-link-inside-popup")[0]);
        } else {
        jFocusableElements.each(function () {
        if (!$(this).hasClass("jmp-link-at-top") && !$(this).hasClass("jmp-link-at-bottom")) {
        focusableElement.push(this);
        return false;
        }
        });
        }

        $(focusableElement[focusableElement.length - 1]).focus();
        */

        popupObject.success();

        if (popupObject.reloadSuccess) {
            popupObject.reloadSuccess();
            popupObject.reloadSuccess = null;
        }
    }

    function showIFrame(popupObject, newElement) {
        var idElement = "popupLayer_" + popupObject.name;

        if (newElement) {
            showScreenLocker();

            $("body").append("<div id='" + idElement + "'><div id='" + idElement + "_title' style='position:absolute;background-color:#eee;height:28px;padding:0;top:-28px;left:-1px;text-align:right;'><span style='display:inline-block;padding:5px 10px 0 0;'><a href='javascript:;' onclick='closePopup();'>关闭</a><span></div><iframe frameborder='0' width='100%' height='100%' hspace='0' src='" + popupObject.url + "'></iframe><!-- --></div>");

            var zIndex = 1000 + (openedObjects.length - 1) * 2; //parseInt(openedObjects.length == 1 ? 1000 : $("#popupLayer_" + openedObjects[openedObjects.length - 2].name).css("z-index")) + 2;
        } else {
            var zIndex = $("#" + idElement).css("z-index");
        }

        var popupElement = $("#" + idElement);
        var titleElement = $("#" + idElement + '_title');

        popupElement.css({
            visibility: "hidden",
            width: popupObject.width == "auto" ? "" : popupObject.width + "px",
            height: popupObject.height == "auto" ? "" : popupObject.height + "px",
            position: "fixed",
            "z-index": zIndex
        });

        titleElement.css({
            width: popupObject.width == "auto" ? "" : popupObject.width + "px",
            border: "1px solid #333",
            "border-bottom": "none"
        });

        var linkAtTop = "<a href='#' class='jmp-link-at-top' style='position:absolute; left:-9999px; top:-1px;'>&nbsp;</a><input class='jmp-link-at-top' style='position:absolute; left:-9999px; top:-1px;' />";
        var linkAtBottom = "<a href='#' class='jmp-link-at-bottom' style='position:absolute; left:-9999px; bottom:-1px;'>&nbsp;</a><input class='jmp-link-at-bottom' style='position:absolute; left:-9999px; top:-1px;' />";

        //popupElement.html(linkAtTop + data + linkAtBottom);

        setPopupLayersPosition(popupElement);

        popupElement.css("display", "none");
        popupElement.css("visibility", "visible");
        popupElement.css("background-color", "#fff");
        popupElement.css("border", "1px solid #333");
        popupElement.css("border-top", "none");

        if (newElement) {
            popupElement.fadeIn();
        } else {
            popupElement.show();
        }

        /*
        $("#" + idElement + " .jmp-link-at-top, " +
        "#" + idElement + " .jmp-link-at-bottom").focus(function () {
        $(focusableElement[focusableElement.length - 1]).focus();
        });

        var jFocusableElements = $("#" + idElement + " a:visible:not(.jmp-link-at-top, .jmp-link-at-bottom), " +
        "#" + idElement + " *:input:visible:not(.jmp-link-at-top, .jmp-link-at-bottom)");

        if (jFocusableElements.length == 0) {
        var linkInsidePopup = "<a href='#' class='jmp-link-inside-popup' style='position:absolute; left:-9999px;'>&nbsp;</a>";
        popupElement.find(".jmp-link-at-top").after(linkInsidePopup);
        focusableElement.push($(popupElement).find(".jmp-link-inside-popup")[0]);
        } else {
        jFocusableElements.each(function () {
        if (!$(this).hasClass("jmp-link-at-top") && !$(this).hasClass("jmp-link-at-bottom")) {
        focusableElement.push(this);
        return false;
        }
        });
        }

        $(focusableElement[focusableElement.length - 1]).focus();
        */

        popupObject.success();

        if (popupObject.reloadSuccess) {
            popupObject.reloadSuccess();
            popupObject.reloadSuccess = null;
        }
    }

    function loadPopupLayerContent(popupObject, newElement) {
        if (newElement) {
            openedObjects.push(popupObject);
        }

        if (popupObject.target && popupObject.target.length > 0) {
            showPopupLayerContent(popupObject, newElement, popupObject.target); //$("#" + ).html());
        } else {
            showIFrame(popupObject, newElement);
            //            $.ajax({
            //                url: popupObject.url,
            //                data: popupObject.parameters,
            //                cache: popupObject.cache,
            //                dataType: "html",
            //                method: "GET",
            //                success: function (data) {
            //                    showPopupLayerContent(popupObject, newElement, data);
            //                },
            //                error: popupObject.error
            //            });
        }
    }

    function openInnerIFrame(settings, newElement) {
        if (newElement) {
            openedObjects.push(settings);
        }

        showInnerIFrame(settings, newElement);
    }

    //显示为页面内部的一个IFrame
    function showInnerIFrame(settings, newElement) {
        var idElement = "innerIFrame_" + settings.name;

        if (newElement) {

            $("#" + settings.target).html("");
            $("#" + settings.target).append("<div id='" + idElement + "'><iframe frameborder='0' width='100%' height='100%' scrolling='no' useParentMsgBar hspace='0' src='" + settings.url + "'></iframe><!-- --></div>");
        }

        var popupElement = $("#" + idElement);

        popupElement.css({
            visibility: "hidden",
            width: "auto",
            height: "auto"
        });

        popupElement.css("visibility", "visible");

        $('iframe', popupElement).each(function () {

            function resizeHeight(iframe) {

                //var $body = $(iframe, window.top.document).contents().find('body');

                var $body = $(iframe).contents().find('body');

                var newHeight = $body[0].scrollHeight;

                iframe.style.height = newHeight + 'px';

            }

            $(this).load(function () {

                //设置高度最小为400px
                this.style.height = '400px';

                resizeHeight(this);

                var iframe = this;

                setInterval(function () { resizeHeight(iframe); }, 2000);

            });

        });

    }

    function opendPopupCount() {
        var count = 0;
        $.each(openedObjects, function (idx, obj) {

            if (!obj.innerIFrame)
                count++;

        });

        return count;
    }

    $(window).resize(
        function () {
            setTimeout(function () {
                setScreenLockerSize();
                setPopupLayersPosition();
            }, 200);
        });

    $(document).keydown(function (e) {
        if (e.keyCode == 27) {
            $.closePopupLayer();
        }
    });
})(jQuery);