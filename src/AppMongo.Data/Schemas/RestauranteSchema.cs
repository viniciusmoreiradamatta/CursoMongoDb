using AppMongo.Entities;
using AppMongo.Entities.ValueObjects;
using AppMongo.Enuns;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppMongo.Schemas
{
    public class RestauranteSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nome { get; set; }
        public TipoCozinha TipoCozinha { get; set; }
        public EnderecoSchema EnderecoSchema { get; set; }

        public Restaurante ConverterParaRestaurante()
        {
            var endereco = new Endereco(this.EnderecoSchema.Logradouro, this.EnderecoSchema.Numero, this.EnderecoSchema.Cidade, this.EnderecoSchema.Uf, this.EnderecoSchema.Cep);
            
            var restaurante = new Restaurante(this.Id, this.Nome, this.TipoCozinha, endereco);

            return restaurante;
        }
    }
}