using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IEngineHandler
    {
        public Task<int> CreateEngine(Models.Engine engine);
    }
}
