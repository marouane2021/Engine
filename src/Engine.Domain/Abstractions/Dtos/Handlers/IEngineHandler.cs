using Engine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IEngineHandler
    {
        public Task<Result> CreateEngine(MyEngine engine);
        public Task<MyEngine> GetEngineById(int code);
      public  Task<List<MyEngine>> GetEngines();
       public Task<bool> UpdateEngine(int code, MyEngine engine);
       public  Task<bool> DeleteEngine(int code);
    }
}
