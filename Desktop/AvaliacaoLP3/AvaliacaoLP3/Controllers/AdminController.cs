using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AvaliacaoLP3.Models;
using AvaliacaoLP3.ViewModels;

namespace AvaliacaoLP3.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static List<LojaViewModel> lojas = new List<LojaViewModel>();

    //private static List<LojaViewModel> lojas = new List<LojaViewModel>{
    //    new LojaViewModel(32, "piso 3", "Tênis Brasil", "Aqui você encontra os tênis", true, "tenis@email.com"),
     //   new LojaViewModel(33, "piso 2", "Lembranças Já", "Vem comprar sua lembrança", true, "lemb@email.com"),
      //  new LojaViewModel(12, "piso 1", "Sorvetinho Gelado", "Sorvetinho Gelado", false, "sorvet@email.com"),
    //};

    public AdminController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult GerenciamentoLojas(){
        return View(lojas);
    }

    public IActionResult DetalheLoja(int id){       
        return View(lojas[id]);
    }

    public IActionResult CadastrarLoja(){   
        return View();
    }

    public IActionResult Cadastro([FromForm] string nome, [FromForm] string email, [FromForm] string categoria, [FromForm] string descricao, [FromForm] int piso){
        
        foreach (var loja in lojas)
        {
            if(nome == loja.Nome){
                ViewData["Nome"] = nome;
                return View();
            }
        }        

        LojaViewModel estabelecimento = new LojaViewModel(lojas.Count(), piso, nome, descricao, categoria, email);
        lojas.Add(estabelecimento);
        return View("CadastrarLoja");
    }

    public IActionResult Deletar(int id){
        
        if(lojas.Count() == 1){
            lojas.Clear();
        }else
            lojas.RemoveAt(id);

        foreach (var loja in lojas)
        {
            loja.Id = lojas.IndexOf(loja);
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}