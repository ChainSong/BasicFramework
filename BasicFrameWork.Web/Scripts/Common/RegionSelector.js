var _regiondata_ = {body: $(document.body)};

var setting = {
    async:{
        enable: true,
        url: "/System/Region/GetChildRegions",
        type: "get",
        autoParam: ["id"]
    },
    callback:{
        onClick: onClick
    },
    view:{
        showIcon: true,
        showLine: true,
        dblClickExpand: false,
        expandSpeed: false
    }
};

function onClick(e, treeId, treeNode){
    var zTree = $.fn.zTree.getZTreeObj(_regiondata_.active.panel),
        nodes = zTree.getSelectedNodes(),
        v = "", rid = "";
    nodes.sort(function(a,b){ return a.id - b.id;});

    for(var i = 0; i < nodes.length; i++){
        v += nodes[i].name + ",";
        rid += nodes[i].id + ",";
    }

    if (v.length > 0){
        v = v.substring(0, v.length - 1);
    }

    if (rid.length > 0){
        rid = rid.substring(0, rid.length - 1);
    }

    _regiondata_.active.txtRegionName.attr("value", v);
    _regiondata_.active.txtRegionID.attr("value", rid);
    window.onRegionSelected && window.onRegionSelected(rid, v, treeId, _regiondata_.active);
}

function getArgs(elem){
    var key = elem.attr('globalID');
    var o = _regiondata_[key];
    if(!o){
        return null;
    }

    if(!o.init){
        $.fn.zTree.init($('#' + o.panel), setting, o.startRegion);
        var p = $(elem).parent(".RegionSelector");
        o.txtRegionName = p.find('.RegionName');
        o.txtRegionID = p.find('.RegionID');
        o.menuContent = p.find('.menuContent');
        o.init = true;
    }

    return o;
}

function showMenu(elem){
    elem = $(elem);

    var o = getArgs(elem);

    if(!o){
        return ;
    }

    if(_regiondata_.active){
        hideMenu();
    }

    o.menuContent.slideDown('fast');
    _regiondata_.active = o;
    _regiondata_.body.bind("mousedown", onBodyDown);
}

function hideMenu(){
    _regiondata_.active.menuContent.fadeOut("fast");
    _regiondata_.active = null;
    _regiondata_.body.unbind("mousedown", onBodyDown);
}

function onBodyDown(event) {
    if (!(event.target.name == "menuContent" || $(event.target).parents(".menuContent").length > 0)) {
        hideMenu();
    }
}

function autoComplete(elem) {
    elem = $(elem);
    elem.autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/System/Region/GetRegionByName",
                type: "POST",
                dataType: "json",
                data: { name: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Text, value: item.Text, data: item }
                    }));
                }
            });
        },
        select: function (event, ui) {
            var globalID = $(this).attr('globalID');
            var regionName = $(this).parent().parent().find('.RegionName');
            var regionID = $(this).parent().parent().find('.RegionID');
            if (regionName && regionID) {
                regionName.attr("value", ui.item.data.Text);
                regionID.attr("value", ui.item.data.Value);
            }
            window.onRegionAutoCompleteSelected && window.onRegionAutoCompleteSelected(globalID);
        }
    });
}
