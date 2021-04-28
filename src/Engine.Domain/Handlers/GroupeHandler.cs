using Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Handlers
{
    public class GroupeHandler : IGroupeHandler
    {

        private readonly IGroupeRepository _groupeRepository;
        public GroupeHandler(IGroupeRepository groupeRepository)
        {
            _groupeRepository = groupeRepository ?? throw new ArgumentNullException(nameof(groupeRepository));
        }
        public async Task<Result> CreateGroupe(Groupe groupe)
        {
            var result = new Result();
            var errorList = new List<string>();
            var x = ValidateFields(groupe, errorList);
            errorList.AddRange(x);

            if (errorList.Count != 0)
            {
                result.Errors = errorList;
                return result;
            }
            bool exist = await _groupeRepository.GetGroupeByCode(groupe.GroupId);
            if (exist)
            {
                errorList.Add($"Groupe Exist");
                result.Errors = errorList;
                return result;
            }
            result.GroupId = await _groupeRepository.CreateGroupe(groupe);
            return result;
        }
        private static List<string> ValidateFields(Groupe groupe, List<string> errorList)
        {
            if (groupe == null)
            {
                errorList.Add($"Scope is null");

            }
            if (groupe.GroupId <= 0)
            {
                errorList.Add($"Groupe Id not accepted, try again ");
            }
            return errorList;
        }

        public async Task<bool> DeleteGroupe(int groupeId)
        {
            return await _groupeRepository.DeleteGroupe(groupeId);
        }

        public async Task<Groupe> GetGroupeById(int groupeId)
        {

            var groupe = await _groupeRepository.GetGroupeById(groupeId).ConfigureAwait(false);

            if (groupe == null)
                return null;

            return groupe;
        }

        public async Task<List<Groupe>> GetGroupes()
        {
            return await _groupeRepository.GetGroupes();
        }

        public async Task<bool> UpdateGroupe(int groupeId, Groupe groupe)
        {
            if (groupe == null)
            {
                return false;
            }

            return await _groupeRepository.UpdateGroupe(groupeId, groupe);
        }
    }
}
