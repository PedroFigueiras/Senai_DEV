using MongoDB.Driver;
using senai.MedicalGroup.webApi.Domains;
using senai.MedicalGroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.MedicalGroup.webApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacoes;

        public LocalizacaoRepository()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SP");
            _localizacoes = database.GetCollection<Localizacao>("mapas");

        }
        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacoes.InsertOne(novaLocalizacao);
        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacoes.Find(localizacao => true).ToList();
        }
    }
}
