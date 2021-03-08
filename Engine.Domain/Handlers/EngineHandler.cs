using Engine.Domain.Abstractions;
using System;
using System.Threading.Tasks;

namespace Engine.Domain.Handlers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Engine.Domain.Abstractions.IEngineHandler" />
    public class EngineHandler : IEngineHandler
    {
        private readonly IEngineRepository _engineRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineHandler"/> class.
        /// </summary>
        /// <param name="engineRepository">The engine repository.</param>
        public EngineHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository ?? throw new ArgumentNullException(nameof(engineRepository));
        }

        public async Task<int> CreateEngine(Models.BIS.Engine engine)
        {
            if (engine.Code <= 0)
            {
                return 0;
            }

            bool exist = await _engineRepository.GetEngineByCode(engine.Code);


            return exist ? 0 : await _engineRepository.CreateMoteur(engine);
        }
    }
}
