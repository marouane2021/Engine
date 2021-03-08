using Engine.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Engine.Domain.Abstractions.Dtos.Handlers;

namespace EngineApi.Api.Controllers.Engines
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [ApiController]
    [Route("Moteur")]
    public class EnginesController : ControllerBase
    {
        private readonly IEngineHandler _handlerEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnginesController"/> class.
        /// </summary>
        /// <param name="handlerEngine">The handler engine.</param>
        public EnginesController(IEngineHandler handlerEngine)
        {
            _handlerEngine = handlerEngine ?? throw new ArgumentNullException(nameof(handlerEngine));
        }

        /// <summary>
        /// Creates the engine asynchronous.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <returns></returns>
        [HttpPost("CreateEngine")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreateEngineAsync([FromBody] Engine.Domain.Models.Engine engine)
        {
            try
            {
                var id = await _handlerEngine.CreateEngine(engine);

                if (id == 0)
                    return NoContent();

                return StatusCode(StatusCodes.Status201Created, id);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
