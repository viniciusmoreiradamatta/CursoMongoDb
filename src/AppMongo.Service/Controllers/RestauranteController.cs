using AppMongo.ApplocationServices;
using AppMongo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppMongo.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class RestauranteController : ControllerBase
{
    private readonly IRestauranteAppService _restauranteAppService;

    public RestauranteController(IRestauranteAppService restauranteAppService)
    {
        _restauranteAppService = restauranteAppService;
    }

    [HttpPost]
    public IActionResult Inserir(RestauranteViewModel vm)
    {
        _restauranteAppService.Inserir(vm);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var todosRestaurantes = await _restauranteAppService.ObterTodosRestaurantes();

        return Ok(todosRestaurantes);
    }
}