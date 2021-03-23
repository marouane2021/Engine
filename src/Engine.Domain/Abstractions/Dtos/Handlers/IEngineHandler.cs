using Engine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IEngineHandler
    {
        public Task<Result> CreateEngine(Models.Engine engine);
        //public Task<bool> CheckIsEngineActive(int code);
        public Task<Models.Engine> GetEngineById(int code);
      public  Task<List<Models.Engine>> GetEngines();

    }
}
