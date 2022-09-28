using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Calculadora.Models;

namespace Calculadora.Controllers;

public class CadastroController : Controller
{
    

    private readonly ILogger<CadastroController> _logger;

    public CadastroController(ILogger<CadastroController> logger)
    {
        _logger = logger;
    }

    public IActionResult Registrar()
    {
        return View();
    }    

    public IActionResult UserRegister([FromForm] string nome, [FromForm] string email, [FromForm] string senha){

        var user = new UserModel()
        {
            Nome = nome,
            Email = email,
            Senha = senha
        };

        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}