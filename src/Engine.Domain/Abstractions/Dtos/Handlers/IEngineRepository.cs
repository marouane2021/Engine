using Engine.Domain.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IEngineRepository 
    {
        Task<ObjectId> CreateEngine(MyEngine moteur);
        Task<bool> GetEngineByCode(int code);
        Task<MyEngine> GetEngineById(int code);
        Task<List<MyEngine>> GetEngines();
        Task<bool> UpdateEngine(int code, MyEngine engine);
        Task<bool> DeleteEngine(int code);

    }
}
    
    

