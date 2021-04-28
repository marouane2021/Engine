using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers
{
    public interface IGroupeHandler
    {
        public Task<Result> CreateGroupe(Groupe groupe);
        public Task<Groupe> GetGroupeById(int groupeId);
        public Task<List<Groupe>> GetGroupes();
        public Task<bool> UpdateGroupe(int groupeId, Groupe groupe);
        public Task<bool> DeleteGroupe(int groupeId);
    }
}
