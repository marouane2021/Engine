using System.Threading.Tasks;

namespace Engine.Domain.Abstractions
{
    public interface IEngineHandler
    {
        public Task<int> CreateEngine(Models.BIS.Engine engine);
    }
}
