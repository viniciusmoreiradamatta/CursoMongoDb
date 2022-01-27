using AppMongo.ApplocationServices;
using AppMongo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppMongo.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class RestauranteController : ControllerBase
{
    private readonly IRestauranteAppService restauranteAppService;

    public RestauranteController(IRestauranteAppService restauranteAppService)
    {
        this.restauranteAppService = restauranteAppService;
    }

    [HttpPost]
    public IActionResult Inserir(RestauranteViewModel vm)
    {
        this.restauranteAppService.Inserir(vm);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var todosRestaurantes = await this.restauranteAppService.ObterTodosRestaurantes();

        return Ok(todosRestaurantes);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult ObterRestaurantePorId(string id)
    {
        var restaurante = this.restauranteAppService.ObterRestaurantePorId(id);

        return Ok(restaurante);
    }
}