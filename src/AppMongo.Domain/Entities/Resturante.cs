using AppMongo.Entities.ValueObjects;
using AppMongo.Enuns;

namespace AppMongo.Entities
{
    public class Resturante
    {
        public Resturante(string id, string nome, TipoCozinha tipoCozinha, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            TipoCozinha = tipoCozinha;
            Endereco = endereco;
        }

        public string Id { get; private set; }
        public string Nome { get; set; }
        public TipoCozinha TipoCozinha { get; set; }
        public Endereco Endereco { get; set; }
    }
}