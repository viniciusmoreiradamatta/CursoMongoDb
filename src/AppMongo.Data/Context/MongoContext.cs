using AppMongo.Enuns;
using AppMongo.Schemas;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace AppMongo.Context
{
    public class MongoContext
    {
        public IMongoDatabase _db { get; }

        public MongoContext(IConfiguration configuration)
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["MongoConnection"]));

            var client = new MongoClient(settings);

            _db = client.GetDatabase(configuration["NomeBanco"]);

            MapClasses();
        }

        private void MapClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(RestauranteSchema)))
            {
                BsonClassMap.RegisterClassMap<RestauranteSchema>(c =>
                {
                    c.AutoMap();
                    c.MapIdMember(m => m.Id);
                    c.MapMember(m => m.TipoCozinha).SetSerializer(new EnumSerializer<TipoCozinha>(MongoDB.Bson.BsonType.Int32));
                    c.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}