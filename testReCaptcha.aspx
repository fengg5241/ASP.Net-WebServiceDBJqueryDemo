<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testReCaptcha.aspx.cs" Inherits="TestWebServiceAndDB.testReCaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
     <script type="text/javascript" src="./Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="https://www.google.com/recaptcha/api.js"></script>
    <script>
        var recaptchaResponse = "";
        var correctCaptcha = function (response) {
            recaptchaResponse = response;
        };

        var login = function () {
            var response = recaptchaResponse;
            $.ajax({
                type: "POST",
                url: "SNTPWebService.asmx/verifyReCaptcha",
                async: false,
               
                data: {
                    response: recaptchaResponse
                },
                success: function (resp) {
                    alert(resp);
                }
            });
        };

        $("#submitButton").click(function () {
           
        })
        
    </script>
</head>
<body>
    
        <div class="g-recaptcha" data-sitekey="6LeO50AUAAAAADX3fY7XJu_rMk_FvvF08SZhODUe" data-callback="correctCaptcha"></div>
    
        <p><button id="submitButton" class="btn btn-primary" onclick="login()">Register</button>
</body>
</html>
