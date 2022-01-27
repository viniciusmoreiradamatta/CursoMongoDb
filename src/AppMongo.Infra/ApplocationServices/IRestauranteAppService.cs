using AppMongo.Entities;
using AppMongo.ViewModels;

namespace AppMongo.ApplocationServices
{
    public interface IRestauranteAppService
    {
        void Inserir(RestauranteViewModel restaurante);

        Task<IEnumerable<Restaurante>> ObterTodosRestaurantes();

        Restaurante ObterRestaurantePorId(string id);
    }
}