using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IEngineRepository 
    {
        Task<int> CreateEngine(Models.Engine moteur);
        Task<bool> GetEngineByCode(int code);
    }
}
    
    

