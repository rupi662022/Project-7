

function LogIn(username, password, successLogInCB, errorLogInCB) {
    $.ajax({

        url: "https://taskyam.israports.co.il/TaskYamWebAPI/api/Account/Login",
        type: 'POST',
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: { "UserName": username, "Password": password },
        dataType: 'json',
        success: successLogInCB,
        error: errorLogInCB
        
    })


}




function GetAjaxCall(APIURL, token, successCB, errorCB) {

    $.ajax({
        url: "https://taskyam.israports.co.il/TaskYamWebAPI/" + APIURL,
        type: "GET",
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        headers: { "X-Session-Token": token },
        success: successCB,
        error: errorCB

    })

}