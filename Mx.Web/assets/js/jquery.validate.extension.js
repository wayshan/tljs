var opts = null;

function GetRemoteInfo(postUrl, data) {
    var remote = {
        type: "POST",
        async: false,
        url: postUrl,
        dataType: "xml",
        data: data,
        dataFilter: function (dataXML) {
            var result = new Object();
            result.Result = jQuery(dataXML).find("Result").text();
            result.Msg = jQuery(dataXML).find("Msg").text();
            if (result.Result == "-1") {
                result.Result = false;
                return result;
            }
            else {
                result.Result = result.Result == "1" ? true : false;
                return result;
            }
        }
    };
    return remote;
}

function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
} 