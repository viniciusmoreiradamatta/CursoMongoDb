﻿using AppMongo.Entities;

namespace AppMongo.ViewModels
{
    public class RestauranteViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public int TipoCozinha { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
    }
}