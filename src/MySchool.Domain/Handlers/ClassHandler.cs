using Flunt.Notifications;
using MySchool.Domain.Commands;
using MySchool.Domain.Commands.Class;
using MySchool.Domain.Entities;
using MySchool.Domain.Interfaces.Command;
using MySchool.Domain.Interfaces.Handler;
using MySchool.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace MySchool.Domain.Handlers
{
    public class ClassHandler : Notifiable, IHandler<AddClassCommand>
                                           , IHandler<UpdateShiftClassCommand>
                                           , IHandler<UpdateNameClassCommand>
                                           , IHandler<RemoveClassCommand>
    {
        private readonly IRepositoryClass _repositoryClass;
        public ClassHandler(IRepositoryClass repositoryClass)
        {
            _repositoryClass = repositoryClass;
        }

        public async Task<ICommandResult> Handle(AddClassCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            // Verificar se a entidade já está cadastrado
            if (_repositoryClass.Exist(x => x.Name == command.Name && x.SchoolId == command.SchoolId && x.Shift == command.Shift && x.Degree == command.Degree))
                AddNotification("Turma", "Já existe uma turma cadastrada com esse nome");


            // Gerar as Entidades
            var schoolClass = new Class(command.Name, command.Shift, command.Degree, command.SchoolId);

            // Agrupar as Validações
            AddNotifications(schoolClass);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da turma", this);

            // Salvar as Informações
            _repositoryClass.Add(schoolClass);

            // Retornar informações
            return new CommandResult(true, "Cadastro realizado com sucesso!", schoolClass);
        }

        public async Task<ICommandResult> Handle(UpdateShiftClassCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var schoolClass = _repositoryClass.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (schoolClass == null)
            {
                AddNotification("Turma", "Turma não cadastrada");
            }

            schoolClass.UpdateShift(command.Shift);

            // Agrupar as Validações
            AddNotifications(schoolClass);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Turma", this);

            // Salvar as Informações
            _repositoryClass.Edit(schoolClass);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", schoolClass);
        }

        public async Task<ICommandResult> Handle(UpdateNameClassCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            var school = _repositoryClass.GetById(command.Id);

            // Verificar se Documento já está cadastrado
            if (school == null)
            {
                AddNotification("Turma", "Turma não cadastrada");
            }

            school.UpdateName(command.Name);

            // Agrupar as Validações
            AddNotifications(school);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro da Turma", this);

            // Salvar as Informações
            _repositoryClass.Edit(school);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", school);
        }

        public async Task<ICommandResult> Handle(RemoveClassCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Dados de entrada in válidos.", null);
            }

            // Verificar se Documento já está cadastrado
            if (command.Id == Guid.Empty)
            {
                AddNotification("Id", "Parametro inválido.");
            }

            var schoolClass = _repositoryClass.GetById(command.Id);

            if (schoolClass == null)
            {
                AddNotification("Turma", "Turma não cadastrada");
            }

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar a exclusão da Turma", this);

            // Escluindo a escola
            _repositoryClass.Remove(schoolClass);

            // Retornar informações
            return new CommandResult(true, "Alteração realizada com sucesso!", null);
        }
    }
}
