using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos
{
    public interface IReadEngineRepository
    {
        //Task<int> CreateEngine(MyReadEngine engine);
        //Task<bool> GetEngineByCode(int code);
        //Task<int> CreateScopes(Models.Scope scope);
        Task<MyReadEngine> GetEngineById(int code);
        //Task<List<MyEngine>> GetEngines();
        //Task<bool> UpdateEngine(int code, MyEngine engine);
        //Task<bool> DeleteEngine(int code);
    }
}
