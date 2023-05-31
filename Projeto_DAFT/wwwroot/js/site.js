
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



const BotApro = document.getElementById('BotApro');
const BotaoAgend = document.getElementById('BotaoAgend');
var date = new Date();

let AprovaAgend = 0;

InpApro.addEventListener('input', () => {
    TrocaBotApro()

})

function TrocaBotApro() {
    const InpApro = document.getElementById('InpApro').value;

    if (InpApro == 1) {
        BotApro.setAttribute("data-dismiss", "modal");
        BotApro.setAttribute("type", "submit");
        }

    else if (InpApro == 2) {
        BotApro.setAttribute("data-dismiss", "modal");
        BotApro.setAttribute("type", "submit");


    }
    else if (InpApro == 3) {
        BotApro.removeAttribute("data-dismiss", "modal");
        BotApro.removeAttribute("type", "submit");


    }
}

BotApro.addEventListener('click', () => {
    EstadoApro()

})

function EstadoApro() {
    const InpApro = document.getElementById('InpApro').value
    const naoSelecionado = document.getElementById('naoSelecionado')

    if (InpApro == 1) {
        document.getElementById("imgapro").src = "/Imagens/correto.png";
        naoSelecionado.innerHTML = ``

    }

    else if (InpApro == 2) {
        document.getElementById("imgapro").src = "/Imagens/incorreto.png";
        naoSelecionado.innerHTML = ``

    }
    else {
        naoSelecionado.innerHTML = `<div id="ErroEsta"><p id="naoSelecionado">Selecione uma opção Valida</p> <img id="ImgErroEst"src="/Imagens/Aguardando icon.png"> </div>`

    }
}



DefInp.addEventListener("change",() => {

    Datacorreta()
})

function Datacorreta() {
    var DefInp = document.getElementById('DefInp').valueAsDate;
    var agora = new Date();

    var dia = DefInp.getUTCDate();
    var mes = DefInp.getUTCMonth() + 1;
    var ano = DefInp.getUTCFullYear();

    var datadigitada = dia+'-'+mes+'-'+ano;


    var diaat = agora.getUTCDate() - 1;
    var mesat = agora.getUTCMonth() + 1;
    var anoat = agora.getUTCFullYear();

    

    var dataatual = diaat +'-'+ mesat+'-'+anoat;

    if (DefInp >= agora) {
       
        BotaoAgend.setAttribute("data-dismiss", "modal");
        BotaoAgend.setAttribute("type", "submit");
       
    } else {
        BotaoAgend.setAttribute("type", "button");
        BotaoAgend.removeAttribute("data-dismiss", "modal");
        
    }

    

    
}


BotaoAgend.addEventListener("click", () => {

    EnviarAgend()
})

function EnviarAgend() {
    const naoSelecionado = document.getElementById('testeteste')

    if (BotaoAgend.type == 'submit') {
        document.getElementById("imgagen").src = "/Imagens/correto.png";
        naoSelecionado.innerHTML = ``

    }
    else {
        document.getElementById("imgagen").src = "/Imagens/Aguardando icon.png";
        document.getElementById("BotaoAgend").removeAttribute("data - dismiss", "modal");
        naoSelecionado.innerHTML = `<div id="ErroData"><p id="testeteste">Selecione uma data superior</p> <img id="ImgDataErro"src="/Imagens/Aguardando icon.png"> </div>`

    }
}


const BotAnt = document.getElementById("BotProxAnteEnviar");

BotAnt.addEventListener("click", () => {

    AdicionadoS()
})

function AdicionadoS() {
    const naoSelecionado = document.getElementById("AdicionaComSuc");
    const Inputteste = document.getElementById("validationCustomteste");

    if (Inputteste >= 0) {
        naoSelecionado.innerHTML = `<div><p id="AdicionaComSuc">Adicionado com Sucesso</p></div>`
    }


}