using System.Threading.Tasks;
using Flunt.Notifications;
using MySchool.Domain.Commands;
using MySchool.Domain.Commands.School;
using MySchool.Domain.Interfaces.Command;
using MySchool.Domain.Interfaces.Handler;
using MySchool.Domain.Interfaces.Repositories;
using MySchool.Domain.ValueObjects;

namespace MySchool.Domain.Handlers
{
    public class SchoolHandler : Notifiable, IHandler<AddSchoolCommand>
    {
        private readonly IRepositorySchool _repositorySchool;
        public SchoolHandler(IRepositorySchool repositorySchool)
        {
            _repositorySchool = repositorySchool;
        }

        public async Task<ICommandResult> Handle(AddSchoolCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            // Verificar se Documento já está cadastrado
            if (_repositorySchool.Exist(x => x.Name == command.Name))
                AddNotification("Escola", "Já existe escola cadastrada para esse nome");


            // Gerar os VOs
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as Entidades
            var school = new School(command.Name, command.Cnpj, address);


            // Agrupar as Validações
            AddNotifications(school, address);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", null);

            // Salvar as Informações
            _repositorySchool.Add(school);

            // Retornar informações
            return new CommandResult(true, "Cadastro realizado com sucesso!", school);
        }
    }
}
