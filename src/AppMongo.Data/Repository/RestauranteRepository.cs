using AppMongo.Context;
using AppMongo.Entities;
using AppMongo.Schemas;
using MongoDB.Driver;

namespace AppMongo.Repository
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private IMongoCollection<RestauranteSchema> restauranteSchema;

        public RestauranteRepository(MongoContext context)
        {
            this.restauranteSchema = context._db.GetCollection<RestauranteSchema>("restaurantes");
        }

        public void Inserir(Restaurante resturante)
        {
            var document = new RestauranteSchema
            {
                Nome = resturante.Nome,
                TipoCozinha = resturante.TipoCozinha,
                EnderecoSchema = new()
                {
                    Cep = resturante.Endereco.Cep,
                    Cidade = resturante.Endereco.Cidade,
                    Logradouro = resturante.Endereco.Logradouro,
                    Numero = resturante.Endereco.Numero,
                    Uf = resturante.Endereco.Uf
                }
            };

            this.restauranteSchema.InsertOne(document);
        }

        public async Task<IEnumerable<Restaurante>> ObterTodosRestaurantes()
        {
            List<Restaurante> listaRestaurante = new();

            await this.restauranteSchema.AsQueryable().ForEachAsync(item => listaRestaurante.Add(item.ConverterParaRestaurante()));

            return listaRestaurante;
        }
    }
}