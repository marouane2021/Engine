using App.Metrics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Engine.Domain.Abstractions;
using Engine.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EngineApi.Api.Bootstrap;
using System.Collections.Generic;
using MongoDB.Driver.Core.Servers;
using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using Engine.Domain.Abstractions.Dtos.Handlers;
using Microsoft.Extensions.Logging;
using Engine.Domain.Handlers;

namespace EngineApi.Api.Controllers.MoteurTestController
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [ApiController]
    [Route("Moteur")]
    public class EngineController : ControllerBase
    {
        private readonly IEngineRepository _engineRepository;

       // private readonly ILogger<HandlerEngine> __logger;
        private readonly IEngineHandler _handlerEngine;
        private readonly ILogger<EngineController> _logger;
        // private readonly IActiveEngineHandler _activeEngineHandler;
        //private object activeEngineHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormationTestController"/> class.
        /// </summary>
        /// <param name="test">The test.</param>
        /// 
        /// <summary>
        /// Initializes a new instance of the <see cref="CompetingOfferChangesController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="handlerEngine">The competing offer handler.</param>
        /// <param name="activeEngineHandler">The active seller handler</param>
        public EngineController(ILogger<EngineController> logger,
            IEngineHandler handlerEngine, IEngineRepository engineRepository)
        {
            // __logger = (ILogger<HandlerEngine>)(logger ?? throw new ArgumentNullException(nameof(logger)));
            _handlerEngine = handlerEngine ?? throw new ArgumentNullException(nameof(handlerEngine));
            _engineRepository = engineRepository;
            //  _activeEngineHandler = (IActiveEngineHandler)(activeEngineHandler ?? throw new ArgumentNullException(nameof(handlerEngine))); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moteur"></param>
        /// <returns></returns>
        [HttpPost("CreateMoteur")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreateMoteurAsync([FromBody] Engine.Domain.Models.Engine moteur)
        {
            var n = await _engineRepository.CreateMoteur(moteur);

            try
            { 
                var id = await _handlerEngine.CreateMoteur(moteur);

                if (id == 0)
                    return NoContent();

                return StatusCode(StatusCodes.Status201Created, id);
            }
            catch
            {
                //Ici on peux logger notre exception (regarder la classe BestOfferApi et faire Pareil)
                //On peut spécifier le retour associé ou throw une exception
                return StatusCode(StatusCodes.Status205ResetContent);

                //_logger.LogError(new StructuredLog(ex));
            }
        }
//        [HttpGet("Engine/{code}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status204NoContent)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
//        public async Task<ActionResult<IEnumerable<Engine.Domain.Models.Engine>>> GetEngineChangesAsync([FromRoute] int code)
//        {
//            try
//            {
//                if (!await _activeEngineHandler.CheckIsEngineActive(code))
//                {
//                    return StatusCode(StatusCodes.Status403Forbidden);
//}
//                IEnumerable<HandlerEngine> offerChanges = await _handlerEngine.GetEngineChangesAsync(code).ConfigureAwait(false);

//                if (offerChanges == null || !offerChanges.Any())
//                {
//                    return NoContent();
//                }
//                return Content(System.Text.Json.JsonSerializer.Serialize(offerChanges, new JsonSerializerOptions
//                {
//                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//                }), "application/vnd.restful+json; charset =utf-8");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, ex.Message);
//                throw;
//            }
//        }


    }
}
