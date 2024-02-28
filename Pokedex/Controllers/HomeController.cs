using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) {
        _logger = logger;
    }

    public IActionResult Index () {

        // Pokemon pikachu = new Pokemon();
        
        // pikachu.Numero = 25;
        // pikachu.Nome   = "Pikachu";
        // pikachu.Imagem = "img/pokemons/025.png";
        // pikachu.Tipo.Add("Elétrico");

        // Pokemon raichu = new () {
        //     Numero = 26,
        //     Nome   = "Raichu",
        //     Imagem = "img/pokemons/026.png",
        //     Tipo   = ["Elétrico"]
        // };

        // return View(raichu);

        List<Pokemon> pokemons = [];

        using(StreamReader leitor = new("Data\\pokemons.json")) {
            
            string dados = leitor.ReadToEnd();
            pokemons     = JsonSerializer.Deserialize <List<Pokemon>>(dados);
        }

        List<Tipo> tipos = [];

        using (StreamReader leitor = new("Data\\tipos.json")) {
            
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize <List<Tipo>>(dados);
        }

        ViewData["Tipos"] = tipos;

        return View(pokemons);
    }

    public IActionResult Privacy () {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error () {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
