using Flunt.Notifications;
using MySchool.Domain.Commands;
using MySchool.Domain.Interfaces.Command;
using MySchool.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MySchool.Domain.Queries
{
    public class ClassQueries : Notifiable, ICommandResult
    {
        private readonly IRepositoryClass _repositoryClass;
        public ClassQueries(IRepositoryClass repositoryClass)
        {
            _repositoryClass = repositoryClass;
        }

        public async Task<ICommandResult> GetAllClassBySchoolId(Guid id)
        {
            var listOfClasses = _repositoryClass.ListBy(x=>x.SchoolId == id).ToList();

            if (listOfClasses.Any())
            {
                return new CommandResult(true, "Dados obtidos com sucesso!", listOfClasses);
            }
            return new CommandResult(false, "Dados não encontrados!", null);
        }

        public async Task<ICommandResult> GetAll()
        {
            var listOfClasses = _repositoryClass.ListOrderedBy(x => x.Name, true).ToList();


            if (listOfClasses.Any())
            {
                return new CommandResult(true, "Dados obtidos com sucesso!", listOfClasses);
            }
            return new CommandResult(false, "Dados não encontrados!", null);
        }

        public async Task<ICommandResult> Get(Guid id)
        {
            var classSchool = _repositoryClass.GetById(id);

            return classSchool != null ? new CommandResult(true, "Dados obtidos com sucesso com sucesso!", classSchool)
                                       : new CommandResult(false, "Dados não encontrados!", null);
        }
    }
}
