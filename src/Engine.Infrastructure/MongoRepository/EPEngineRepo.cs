using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Engine.Infrastructure.MongoRepository
{

    public class EPEngineRepo : IEngineRepository//IEngineEPRepo
    {
        private BestOfferApi _configuration;
        private readonly IHttpClientFactory _clientFactory;
        public EPEngineRepo(BestOfferApi myConfiguration, IHttpClientFactory clientFactory)
        {
            _configuration = myConfiguration;
            _clientFactory = clientFactory;
        }

        public Task<ObjectId> CreateEngine(MyEngine moteur)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEngine(int code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEngineByCode(int code)
        {
            throw new NotImplementedException();
        }

        public Task<MyEngine> GetEngineById(int code)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MyEngine>> GetEngines()
        {
            List<MyEngine> engines = new List<MyEngine>();
            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = _configuration.BaseAddress;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("AllEngines");

                if (res.IsSuccessStatusCode)
                {
                    var response  = await res.Content.ReadAsStringAsync();
                    if (response == null)
                        throw new ArgumentNullException();
                    engines = JsonConvert.DeserializeObject<List<MyEngine>>(response);

                }   
            }
            return engines;
        }

        public Task<bool> UpdateEngine(int code, MyEngine engine)
        {
            throw new NotImplementedException();
        }
    }
}
