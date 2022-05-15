// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function ($) {
    "use strict"; var input = $('.validate-input .input100'); $('.validate-form').on('submit', function () {
        var check = true; for (var i = 0; i < input.length; i++) { if (validate(input[i]) == false) { showValidate(input[i]); check = false; } }
        return check;
    }); $('.validate-form .input100').each(function () { $(this).focus(function () { hideValidate(this); }); }); function validate(input) {
        if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') { if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) { return false; } }
        else { if ($(input).val().trim() == '') { return false; } }
    }
    function showValidate(input) { var thisAlert = $(input).parent(); $(thisAlert).addClass('alert-validate'); }
    function hideValidate(input) { var thisAlert = $(input).parent(); $(thisAlert).removeClass('alert-validate'); }
})(jQuery);

function myFunction() {
    var x = document.getElementById("myInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function showGif() {
    var x = document.querySelector(".gif");
    var audio = document.getElementById("audio");
    x.classList.add('visible');
    audio.play();
}
function showLoader() {
    var x = document.querySelector(".body");
    var y = document.querySelector(".limiter");
    var b = document.querySelector(".page-main");
    x.style.transition = 'all 0.3s ease';
    b.classList.add('loading');
    y.classList.add('hidden');
    x.classList.add('visible');
}
function hideLoader() {
    var x = document.querySelector(".body");
    var y = document.querySelector(".limiter");
    var b = document.querySelector(".page-main");
    var z = document.querySelector(".loader-container");
    var a = document.querySelector(".limiter-body");
    z.classList.add("slide-out-fwd-right");
    setTimeout(() => {
        b.classList.remove('loading');
        y.classList.remove('hidden');
        x.classList.add('hidden');
        a.classList.add('visible');
    },900)
    
}
function onLogin() {
    window.onhashchange = function () {
        x = document.querySelector(".toggler-btn")
        x.checked = false;
        showLoader();
    }
}
function changeBackground() {
    var b = document.querySelector(".page-main");
    b.classList.add('gradient-anim');
}
window.addEventListener('load', function () {
    showLoader();
    setTimeout(() => {
        hideLoader();
        setTimeout(() => {
            changeBackground();
        }, 700)
    }, 3500)
    
});
function sendMoneyRequest() {
    let input = document.querySelector('.input-card-number');
    let moneyAmountInput = document.querySelector('.money-amount');
    let e = document.querySelector(".parent-control")
    var value = e.options[e.selectedIndex].value;
    input.value = parseInt(value);
    console.log(value);
    moneyAmountInput.addEventListener('input', (e) => {
        console.log(moneyAmountInput, e)
    });
    //form.addEventListener("click", function () {
    //    form.submit();
    //});
   
}

sendMoneyRequest()
async function moneyPostRequest() {
    let input = document.querySelector('.input-card-number');
    let moneyAmountInput = document.querySelector('.money-amount');
    let objToSend = {
        accNumber: parseInt(input.value),
        moneyAmount: parseInt(moneyAmountInput.value)
    }
    console.warn(moneyAmountInput)
    console.log('obj to send', objToSend)
    let response = await fetch('/Home/LoginForm', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(objToSend)
    });
}
