const password = document.getElementById('password');
const check = document.getElementById('check');


function showHide() {
    if (password.type == 'password') {
        password.setAttribute('type', 'text');
        check.classList.add('hide')
    }
    else {
        password.setAttribute('type', 'password');
        check.classList.remove('hide');
    }
}

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
