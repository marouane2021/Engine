using Engine.Domain.Abstractions.Dtos;
using Engine.Domain.Handlers;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions
{
    public interface IEngineHandler
    {
        
        Task<int> CreateMoteur(Models.Engine moteur);
       // Task<IEnumerable<HandlerEngine>> GetEngineChangesAsync(int code);
    }
}
