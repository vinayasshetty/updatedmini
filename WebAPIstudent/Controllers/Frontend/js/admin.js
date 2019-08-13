var xhrR = new XMLHttpRequest();

xhrR.addEventListener("readystatechange", ajaxReadHandler);



var xhrC = new XMLHttpRequest();

xhrC.addEventListener("readystatechange", ajaxCreateHandler);



window.onload = function () {

    document.getElementById("loginbtn_id").addEventListener("click", clickHandler);

};

function ajaxReadHandler(evt) {

    if (evt.target.readyState === 4 && evt.target.status === 200) {

        alert(xhrR.responseText);

    }

}



function ajaxCreateHandler(evt) {

    if (evt.target.readyState === 4 && evt.target.status === 200) {



        alert(xhrC.responseText);



    };

}



function clickHandler() {

    var user = {

        "username": document.getElementById("username_id").value,

        "password": document.getElementById("password_id").value

       

    }

    console.log(user);

    xhrC.open("post", "http://localhost:52778/api/WebAPIstudent/VerifyLogin", true);

    xhrC.setRequestHeader("Content-Type", "application/json");

    xhrC.send(JSON.stringify(user));

}