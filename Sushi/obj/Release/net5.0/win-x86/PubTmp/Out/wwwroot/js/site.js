////// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
////// for details on configuring this project to bundle and minify static web assets.

////// Write your JavaScript code.
//console.log("connectded")
//$(document).ready(function () {

//    $(".navbutton").click(function () {

//        if ($(".navbutton").text() == "☰") {
//            $(".navbutton").text("🞬");
//        } else {
//            $(".navbutton").text("☰");
//        }

//        $("li").toggle("slow");
//    });
//});


function HighLightLogin () {
    document.getElementById('h1reg').onmouseover = function (e) {
        let color = '#' + Math.floor(Math.random() * 16777215).toString(16);
        let colorString = '0 0 0.75rem ' + color;
        document.getElementById("h1reg").style.boxShadow = colorString;
    }
    document.getElementById('register_img').onmouseover = function (e) {
        let color = '#' + Math.floor(Math.random() * 16777215).toString(16);
        let colorString = '0 0 0.75rem ' + color;
        document.getElementById("register_img").style.boxShadow = colorString;
    }
}

function HideScrollbar() {
    var style = document.createElement("style");
    style.innerHTML = `
     body::-webkit-scrollbar {width: 0rem;}`;
    document.head.appendChild(style);
}
var pageName = window.location.pathname.split("/").pop();
console.log(pageName);

switch (pageName) {
    case "":
        HideScrollbar();
        break;
    case "Register":
    case "Login":
        HighLightLogin();
        break;
    default:
}
