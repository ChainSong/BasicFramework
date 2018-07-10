var ajaxFileUpload = function (fileElementID, hiddenFileID, isMultiple, isReadly, isCoverOld) {
    $('#' + hiddenFileID + '_Table').ajaxStart(function () {
        WebPortal.MessageMask.Show("上传中...");   
    }).ajaxComplete(function () {
        WebPortal.MessageMask.Close();
    });

    $.ajaxFileUpload(
        {
            url: uploadUrl,
            secureurl: false,
            fileElementId: fileElementID,
            dataType: 'json',
            data: { gid: $('#' + hiddenFileID).val(), isMultiple: isMultiple,isCoverOld: isCoverOld },
            success: function (data, status) {
                if (data.msg) {
                    BasicFramework.Alert(data.msg)
                }

                var uploadTable_Tr2 = $('#' + hiddenFileID + '_Table tr:nth-child(2) td');
                if (isMultiple === "False") {
                    $('#' + hiddenFileID).val(data.gid);
                    if (data.aid) {
                        var parsedDate = new Date(parseInt(data.time.substr(6)));
                        var jsDate = new Date(parsedDate); //Date object
                        var attach = '<span class="uploadedSpan" id="attachmentSpan"><a name="download" href="' + downloadUrl + data.aid + '">' + data.anm + '|' + jsDate.Format("yyyy-MM-dd") + '</a>';
                        if (isReadly === "False") {
                            attach += "<a name='delete' class='uploadedRemove' href='#' id='" + data.aid + "'>[删除]</a>";
                        }
                        attach += "</span><br />";
                        uploadTable_Tr2.append(attach);
                    }
                } else {
                    if (data.aids) {
                        uploadTable_Tr2.html();
                        for (var i = 0 ; i < data.aids.length; i++) {
                            var parsedDate = new Date(parseInt(data.times[i].substr(6)));
                            var jsDate = new Date(parsedDate); //Date object
                            var attach = '<span class="uploadedSpan" id="attachmentSpan"><a name="download" href="' + downloadUrl + data.aids[i] + '">' + data.anms[i] + '|' + jsDate.Format("yyyy-MM-dd") + '</a>';
                            if (isReadly === "False") {
                                attach += "<a name='delete' class='uploadedRemove' href='#' id='" + data.aids[i] + "'>[删除]</a>";
                            }
                            attach += "</span><br />";
                            uploadTable_Tr2.append(attach);
                        }
                    }
                }

                if (window.OnUploadedSuccess) {
                    window.OnUploadedSuccess(data);
                }
            },
            error: function (data, status, e) {
                alert(e);
            }
        }
    );
    return false;
};