
//Função para exibir e esconder a senha do "Modal_Login"

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

//Função para trocar a imagem da "flecha" do dropdown da tela inicial (Anteprojeto)

var ImgFlechaBaixo = "/Imagens/Icon_Flecha.png"
var ImgFlechaCima = "/Imagens/Icon_Flecha2.png"

function trocar() {
    document.getElementById("Flecha").src = ImgFlechaBaixo;
    let aux = ImgFlechaBaixo;
    ImgFlechaBaixo = ImgFlechaCima;
    ImgFlechaCima = aux;
}

//Função para trocar a imagem da "flecha" do dropdown da tela inicial (TCC)

var ImgFlechaBaixo2 = "/Imagens/Icon_Flecha.png"
var ImgFlechaCima2 = "/Imagens/Icon_Flecha2.png"

function trocar2() {
    document.getElementById("Flecha2").src = ImgFlechaBaixo2;
    let aux = ImgFlechaBaixo2;
    ImgFlechaBaixo2 = ImgFlechaCima2;
    ImgFlechaCima2 = aux;
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

var inputNome = document.getElementById('name');
var inputFicheiro = document.getElementById('file');

inputFicheiro.addEventListener('change', function () {
    var nome = this.files[0].name;
    inputNome.value = nome;
});



    function mask(o, f) {
        setTimeout(function () {
            var v = mphone(o.value);
            if (v != o.value) {
                o.value = v;
            }
        }, 1);
        }

    function mphone(v) {
            var r = v.replace(/\D/g, "");
    r = r.replace(/^0/, "");
            if (r.length > 10) {
        r = r.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
            } else if (r.length > 5) {
        r = r.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
            } else if (r.length > 2) {
        r = r.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
            }
    return r;
        }



const BotApro = document.getElementById('BotApro')

BotApro.addEventListener('click', () => {
    enviarApro()

})

function enviarApro() {
    const InpApro = document.getElementById('InpApro').value
    const naoSelecionado = document.getElementById('naoSelecionado')

    if (InpApro == 1) {
        document.getElementById("imgapro").src = "/Imagens/correto.png";
        document.getElementById("ModalAprovado").style.display = "none";
    }

    else if (InpApro == 2) {
        document.getElementById("imgapro").src = "/Imagens/incorreto.png";
        document.getElementById("ModalAprovado").style.display = "none";
    }
    else if (InpApro == 3) {
        naoSelecionado.innerHTML = `<p id="">AAAAAA</p>`
    }
}


function Apro() {
    const InpApro = document.getElementById('InpApro').value
    const naoSelecionado = document.getElementById('naoSelecionado')

    if (InpApro == 1) {
        document.getElementById("imgapro").src = "/Imagens/correto.png";
        
    }

    else if (InpApro == 2) {
        document.getElementById("imgapro").src = "/Imagens/incorreto.png";

    }
    else if (InpApro == 3) {
        console.log('a')
    }
}



function AgendDef() {
    const DefInp = document.getElementById('DefInp').value

    if (DefInp >= 1) {
        document.getElementById("imgapro").src = "/Imagens/correto.png";
    }

    else if (DefInp == 2) {
        document.getElementById("imgapro").src = "/Imagens/incorreto.png";

    }
    else if (DefInp == 3) {
        alert('Não da pra selecionar o 3')
    }
}