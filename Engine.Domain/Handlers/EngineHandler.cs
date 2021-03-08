using Engine.Domain.Abstractions;
using Engine.Domain.Abstractions.Dtos;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Handlers
{  /// <summary>
   /// 
   /// </summary>
   /// <seealso cref="IEngineHandler" />
    public class EngineHandler : IEngineHandler
    {
        private readonly IEngineRepository _engineRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompetingOfferChangesHandler"/> class.
        /// </summary>
        /// <param name="engineRepository">The offer changes repository.</param>
        /// <exception cref="ArgumentNullException">productOfferAggregator</exception>
        public EngineHandler(IEngineRepository engineRepository)
        {
            _engineRepository = engineRepository ?? throw new ArgumentNullException(nameof(engineRepository));
        }

        /*   public Task<int> CreateMoteur(Models.Engine moteur)
           {
               throw new NotImplementedException();
           }*/

        public async Task<int> CreateMoteur(Models.Engine moteur)
        {
            if (moteur.code <= 0)
            {
                return 0;
            }

            bool exist = await _engineRepository.GetEngineByCode(moteur.code);


            return exist ? 0 : await _engineRepository.CreateMoteur(moteur);
        }

        ///// <summary>
        ///// Gets the competing offer changes.
        ///// </summary>
        ///// <param name="code">The seller identifier.</param>
        ///// <returns></returns>
        //public async Task<IEnumerable<Models.Engine>> GetEngineChangesAsync(int code)
        //{
        //    IList<IEngineDto> engine = await _engineRepository.GetEngineChangesAsync(code).ConfigureAwait(false);

        //    if (engine == null || !engine.Any())
        //    {
        //        return null;
        //    }

        //    IList<Models.Engine> moteur = new List<Models.Engine>();
        //    foreach (IEngineDto engineDto in engine)
        //    {
        //        await _engineRepository.SetEngineChangesAsync(code, engineDto).ConfigureAwait(false);
        //        moteur.Add(
        //            Models.Engine.Create()
        //                                .FromUpdatedEnginesDto(engineDto));

        //    }

        //    return moteur;
        //}

        //Task<IEnumerable<HandlerEngine>> IHandlerEngine.GetEngineChangesAsync(int code)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
