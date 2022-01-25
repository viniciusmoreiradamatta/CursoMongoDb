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
    }
}