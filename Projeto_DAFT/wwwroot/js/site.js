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
