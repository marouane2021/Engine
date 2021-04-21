using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Domain.Handlers
{
    /// </summary>
    /// <seealso cref="IEngineHandler" />
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

        public async Task<Result> CreateEngine(MyEngine engine)
        {
            var result = new Result();
            var errorList = new List<string>();
            var x = ValidateFields(engine, errorList);
            errorList.AddRange(x);

            if (errorList.Count != 0)
            {
                result.Errors = errorList;
                return result;
            }
            bool exist = await _engineRepository.GetEngineByCode(engine.Code);
            if (exist)
            {
                errorList.Add($"Moteur Exist");
                result.Errors = errorList;
                return result;
            }
            result.Id= await _engineRepository.CreateEngine(engine);

            return result;
        }

        private static List<string> ValidateFields(MyEngine engine, List<string> errorList)
        {
            if(engine == null)
            {
                errorList.Add($"Engine is null");

            }
            if (engine.Code <= 0)
            {
                errorList.Add($"Code not accepted, try again ");
            }
            foreach (var scope in engine.Scopes)
            {
                if (scope.ScopeId <= 0)
                {
                    errorList.Add($"scope code is not accepted, try again");
                }
            }
            foreach (var input in engine.InputFields)
            {
                if (input.InputId <= 0)
                    errorList.Add($"InputFields code is not accepted, try again");
                else
                {
                    foreach (var parameter in input.Parameters)
                    {
                        if (parameter.ScopeParameterId <= 0)
                            errorList.Add($"Parameters code is not accepted, try again");
                    }
                }
            }
            return errorList;
        }
        public async Task<MyEngine> GetEngineById(int code)
        {
            var engines = await _engineRepository.GetEngineById(code).ConfigureAwait(false);

            if (engines == null)
                return null;

            return engines;
        }
        public async Task<List<MyEngine>> GetEngines()
        {
            return await _engineRepository.GetEngines();
        }
        public async Task<bool> UpdateEngine(int code, MyEngine engine)
        {
            if (engine == null)
            {
                return false;
            }

            return await _engineRepository.UpdateEngine(code, engine);
        }
        public async Task<bool> DeleteEngine(int code)
        {
            return await _engineRepository.DeleteEngine(code);
        }
    }
}