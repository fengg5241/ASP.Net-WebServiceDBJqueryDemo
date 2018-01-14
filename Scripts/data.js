$(document).ready(function () {

    $.ajax({
        type: "POST",
        url: "SNTPWebService.asmx/searchLightInfo",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(result);
            
        }
    });
});