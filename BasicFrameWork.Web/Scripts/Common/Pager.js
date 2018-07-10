$(function () {
    var initialize = function () {
        pageIndex = parseInt(pageIndex);
        pageCount = parseInt(pageCount);

        if (pageCount > 0) {
            $('#pager_pageIndex').text(pageIndex + 1);
            $('#pager_pageCount').text(pageCount)
            $('#pager').show();
        }

        if (pageIndex == 0) {
            $('div#pager span.first, div#pager span.prev').hide();
        }

        if (pageIndex == pageCount - 1) {
            $('div#pager span.next, div#pager span.last').hide();
        }

        if (pageIndex === 0 && pageCount === 0) {
            $('div#pager').hide();
        }
    }

    var setup = function () {
        var form = null;
        if (formID) {
            form = document.getElementById(formID);
        } else {
            form = document.forms[0];
        }

        if (pageIndexItemID) {
            $('#' + pageIndexItemID).val(pageIndexItemID)
            $(form).submit();
        } else {
            var input = $('<input type="hidden" name="PageIndex" id="PageIndex" value="' + pageIndex + '" />');
            $(form).append(input).submit();
        }
    }

    $('div#pager span.prev').click(function () {
        pageIndex -= 1;
        setup();
    })
    $('div#pager span.next').click(function () {
        pageIndex += 1;
        setup();
    })
    $('div#pager span.first').click(function () {
        pageIndex = 0;
        setup();
    })
    $('div#pager span.last').click(function () {
        pageIndex = pageCount - 1;
        setup();
    })

    $('div#pager input[type="text"]').keypress(function (event) {
        var keycode = event.keycode ? event.keycode : event.which;
        if (keycode == '13') {
            var value = parseInt($(this).val());
            if (!isNaN(value) && value > 0 && value <= pageCount && value != pageIndex + 1) {
                pageIndex = value - 1;
                setup();
            }
        }
    });

    initialize();
});