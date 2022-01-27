using AppMongo.Entities;
using AppMongo.Entities.ValueObjects;
using AppMongo.Enuns;
using AppMongo.Repository;
using AppMongo.ViewModels;

namespace AppMongo.ApplocationServices
{
    public class RestauranteAppService : IRestauranteAppService
    {
        private readonly IRestauranteRepository restauranteRepository;

        public RestauranteAppService(IRestauranteRepository restauranteRepository)
        {
            this.restauranteRepository = restauranteRepository;
        }

        public void Inserir(RestauranteViewModel restaurante)
        {
            _ = Enum.TryParse(restaurante.TipoCozinha.ToString(), out TipoCozinha tipo);

            var novoRestaurante = new Restaurante(Guid.NewGuid().ToString(), restaurante.Nome, tipo,
                                                 new Endereco(restaurante.Logradouro, restaurante.Numero,
                                                              restaurante.Cidade, restaurante.Uf, restaurante.Cep));

            this.restauranteRepository.Inserir(novoRestaurante);
        }

        public async Task<IEnumerable<Restaurante>> ObterTodosRestaurantes() => await this.restauranteRepository.ObterTodosRestaurantes();

        public Restaurante ObterRestaurantePorId(string id) => this.restauranteRepository.ObterRestaurantePorId(id);
    }
}