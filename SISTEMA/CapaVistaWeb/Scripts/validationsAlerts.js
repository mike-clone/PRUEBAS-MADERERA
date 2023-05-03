//function validateLogin(idLogin) {
//    var username = document.getElementById("username").value;
//    var password = document.getElementById("password").value;
//    const dUsername = document.getElementById("username_alert");
//    const dPassword = document.getElementById("password_alert");
//    const formulario = document.getElementById(idLogin);
    
//    dUsername.style.display = "none";
//    dPassword.style.display = "none";
//    if (username == "") {
//        dUsername.innerText = "Username is required"
//        dUsername.style.display = "block";
//    }
//    if (password == "") {
//        dPassword.innerText = "Password is required"
//        dPassword.style.display = "block";
//    }

//    if (username != "" && password != "") {
//        formulario.submit();
//    }

//}

// Example starter JavaScript for disabling form submissions if there are invalid fields
(() => {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    const forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')
        }, false)
    })
})()