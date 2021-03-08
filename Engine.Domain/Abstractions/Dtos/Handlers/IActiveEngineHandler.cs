using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers
{
    public interface IActiveEngineHandler
    {/// <summary>
     /// Check if the seller is active
     /// </summary>
     /// <param name="code">The seller identifier</param>
     /// <returns>True if the seller is active, otherwise false</returns>
        Task<bool> CheckIsEngineActive(int code);
    }
}
