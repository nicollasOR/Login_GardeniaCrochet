using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Login.Services;
using Login.Data;
using Login.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _contexto;

        public LoginController(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(string email, string senha)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.Erro = "Email e/ou senha incorretos!";
                return View("Index");
            }



            byte[] senhaDigitadaHASH = HashServico.GerarHashBytes(senha);

            var cliente = _contexto.Cliente2.FirstOrDefault(cliente2 => cliente2.Email == email);
            if(cliente == null)
            {
                ViewBag.Erro = "Email incorreto";
                return View("Index");
            }

            if(!(cliente.SenhaHash.SequenceEqual(senhaDigitadaHASH)))
            {
                ViewBag.Erro = "email e/ou senha incorretos";
                return View("Index");
            }

            HttpContext.Session.SetString("Cliente2Nome", cliente.NomeCompleto);
            HttpContext.Session.SetInt32("Cliente2ID", cliente.IdCliente);

            return RedirectToAction("Index", "Home");
        }

        // public 
        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}