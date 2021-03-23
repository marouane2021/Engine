using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IEngineRepository 
    {
        Task<ObjectId> CreateEngine(Models.Engine moteur);
        Task<bool> GetEngineByCode(int code);
        //Task<int> CreateScopes(Models.Scope scope);
        Task<Engine.Domain.Models.Engine> GetEngineById(int code);
        Task<List<Models.Engine >> GetEngines();

    }
}
    
    

