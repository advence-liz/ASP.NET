
/*
$.get(
    "RequestPage.aspx",
    { "token": "ajax" },
    function (data) {
    $("#dataShow").text(data);
    }
);*/
window.fire = () =>   $.ajax({
    type: "Get",
    url: "api/Values/Get",


    success: function (data) {
        window.console.dir(data);
    }
});
var requestJson = JSON.stringify({ startId: 1, itemcount: 3 });
$.ajax({
    url: 'http://localhost/api/values/post',
    data: requestJson,
    type: "post",
    dataType: "json",
    contentType: "application/json;",
    success: function (data) {
       console.dir(data)
    }
});
$(function () {
    function ajaxEvent() {
        return $.ajax({
            url: "Home/QueryUser",
            data: { "user": new Date().getTime() },
            dataType: "json",
            type: "post",
            timeout: 2000
        });
    }

    function longPolling() {
        var defer = ajaxEvent();
        defer.done(ajaxSuccess(defer.success)).done(ajaxError(defer.error));
    }

    function ajaxSuccess(success) {
        success(function (result, textStatus) {
            $("#logs").append("[userId: " + result.userId
                + " message: " + result.message + " state: " + textStatus + " ]<br/>");
            if (textStatus == "success") {
                setTimeout(function () {
                    longPolling();
                }, 1000);
            }
        });
    }

    function ajaxError(error) {
        error(function (XMLHttpRequest, textStatus, errorThrown) {
            $("#logs").append("[ state: " + textStatus
                + " error: " + errorThrown + " ]<br/>");
            setTimeout(function () {
                longPolling();
            }, 1000);
        });
    }

    $("input:first").click(function () {
        longPolling();
    });
});