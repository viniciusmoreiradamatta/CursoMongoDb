using AppMongo.Entities;
using AppMongo.Entities.ValueObjects;
using AppMongo.Enuns;
using AppMongo.Repository;
using AppMongo.ViewModels;

namespace AppMongo.ApplocationServices
{
    public interface IRestauranteAppService
    {
        void Inserir(RestauranteViewModel restaurante);
    }

    public class RestauranteAppService : IRestauranteAppService
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public RestauranteAppService(IRestauranteRepository restauranteRepository)
        {
            _restauranteRepository = restauranteRepository;
        }

        public void Inserir(RestauranteViewModel restaurante)
        {
            _ = Enum.TryParse(restaurante.TipoCozinha.ToString(), out TipoCozinha tipo);

            var novoRestaurante = new Resturante(Guid.NewGuid().ToString(), restaurante.Nome, tipo,
                                                 new Endereco(restaurante.Logradouro, restaurante.Numero,
                                                              restaurante.Cidade, restaurante.Uf, restaurante.Cep));

            _restauranteRepository.Inserir(novoRestaurante);
        }
    }
}