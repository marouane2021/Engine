using Engine.Domain.Abstractions.Dtos;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions
{
   public interface IEngineRepository 
    {
        Task<int> CreateMoteur(Models.Engine moteur);
        //Task<IList<IEngineDto>> GetEngineChangesAsync(int code);

        ///// <summary>
        ///// Sets the offer change as read.
        ///// </summary>
        ///// <param name="sellerId">The seller identifier.</param>
        ///// <param name="updatedProductOffer">The updated product offer.</param>
        ///// <returns></returns>
        //Task SetEngineChangesAsync(int code, IEngineDto updatedProductOffer);
        Task<bool> GetEngineByCode(int code);
    }
}
    
    

