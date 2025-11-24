const form = document.querySelector("form");
const usuario = document.getElementById("usuario");
const senha = document.getElementById("senha");
const erro = document.querySelector(".erro");

form.addEventListener("submit", e => {
    if (usuario.value.trim() === "" || senha.value.trim() === "") {
        e.preventDefault();
        erro.textContent = "Preencha usuário e senha.";
    }
});
