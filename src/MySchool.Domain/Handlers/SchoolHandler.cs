using System;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using MySchool.Domain.Commands;
using MySchool.Domain.Commands.School;
using MySchool.Domain.Interfaces.Command;
using MySchool.Domain.Interfaces.Handler;
using MySchool.Domain.Interfaces.Repositories;

namespace MySchool.Domain.Handlers
{
    public class SchoolHandler : Notifiable,
        IHandler<AddSchoolCommand>,
        IHandler<UpdateAddressSchoolCommand>,
        IHandler<UpdateNameSchoolCommand>,
        IHandler<RemoveSchoolCommand>
    {
        private readonly IRepositorySchool _repositorySchool;
        private readonly IRepositoryClass _repositoryClass;
        public SchoolHandler(IRepositorySchool repositorySchool, IRepositoryClass repositoryClass)
        {
            _repositorySchool = repositorySchool;
            _repositoryClass = repositoryClass;
        }

        public async Task<ICommandResult> Handle(AddSchoolCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            // Verificar se a entidade já está cadastrado
            if (_repositorySchool.Exist(x => x.Name == command.Name))
                AddNotification("Escola", "Já existe escola cadastrada para esse nome");

            if (_repositorySchool.Exist(x => x.Cnpj == command.Cnpj))
                AddNotification("Escola", "Já existe escola cadastrada para esse CNPJ");


            // Gerar as Entidades
            var school = new School(command.Name, command.Cnpj, command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);


            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _repositorySchool.Add(school);

            // Retornar informações
            return new CommandResult(true, "Cadastro realizado com sucesso!", school);
        }

        public async Task<ICommandResult> Handle(UpdateAddressSchoolCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var school = _repositorySchool.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (school == null)
            {
                AddNotification("Escola", "Escola não cadastrada");
            }

            school.UpdateAddress(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);


            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _repositorySchool.Edit(school);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", school);
        }

        public async Task<ICommandResult> Handle(UpdateNameSchoolCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", this);
            }

            var school = _repositorySchool.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (school == null)
            {
                AddNotification("Escola", "Escola não cadastrada");
            }

            school.UpdateName(command.Name);

            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Salvar as Informações
            _repositorySchool.Edit(school);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", school);
        }

        public async Task<ICommandResult> Handle(RemoveSchoolCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
            }

            // Verificar se Documento já está cadastrado
            if (command.Id == Guid.Empty)
            {
                AddNotification("Id", "Parametro inválido.");
            }

            //TODO Aplicata a regra para verificar se já tem turmas cadastradas para a escola
            var classes = _repositoryClass.ListBy(x => x.SchoolId == command.Id).ToList();

            if (classes.Any())
            {
                AddNotification("Escola", "Não é possivel escluir a escola pois a mesma já possui turmas cadastradas.");
            }

            var school = _repositorySchool.GetById(command.Id);

            // Verificar se Escola já está cadastrado
            if (school == null)
            {
                AddNotification("Escola", "Escola não cadastrada");
                return new CommandResult(false, "Dados de entrada in válidos.", this);
            }

            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Escola", this);

            // Escluindo a escola
            _repositorySchool.Remove(school);

            // Retornar informações
            return new CommandResult(true, "Exclusão realizada com sucesso!", null);
        }
    }
}
