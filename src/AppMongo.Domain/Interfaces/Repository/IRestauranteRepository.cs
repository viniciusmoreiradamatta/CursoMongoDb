using AppMongo.Entities;

namespace AppMongo.Repository
{
    public interface IRestauranteRepository
    {
        void Inserir(Restaurante resturante);

        Task<IEnumerable<Restaurante>> ObterTodosRestaurantes();
    }
}