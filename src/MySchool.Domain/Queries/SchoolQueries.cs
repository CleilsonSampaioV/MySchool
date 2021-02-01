using Flunt.Notifications;
using MySchool.Domain.Commands;
using MySchool.Domain.Interfaces.Command;
using MySchool.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Domain.Queries
{
    public class SchoolQueries : Notifiable, ICommandResult
    {
        private readonly IRepositorySchool _repositorySchool;
        public SchoolQueries(IRepositorySchool repositorySchool)
        {
            _repositorySchool = repositorySchool;
        }

        public async Task<ICommandResult> GetAll()
        {
            var listOfSchools = _repositorySchool.ListOrderedBy(x=>x.Name, true).ToList();

            return listOfSchools != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", listOfSchools) : new CommandResult(false, "Dados não encontrados!", null);
        }

        public async Task<ICommandResult> Get(Guid id)
        {
            var school = _repositorySchool.GetById(id);

            return school != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", school) : new CommandResult(false, "Dados não encontrados!", null);
        }
    }
}
