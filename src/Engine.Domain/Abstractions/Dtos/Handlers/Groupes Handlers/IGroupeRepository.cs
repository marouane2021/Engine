using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers
{
    public interface IGroupeRepository
    {
        Task<int> CreateGroupe(Groupe groupe);
        Task<bool> GetGroupeByCode(int groupeId);
        Task<Groupe> GetGroupeById(int groupeId);
        Task<List<Groupe>> GetGroupes();
        Task<bool> UpdateGroupe(int groupeId, Groupe groupe);
        Task<bool> DeleteGroupe(int groupeId);
    }
}
