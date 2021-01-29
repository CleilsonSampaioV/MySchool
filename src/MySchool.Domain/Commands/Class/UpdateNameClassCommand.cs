using Flunt.Notifications;
using Flunt.Validations;
using MySchool.Domain.Interfaces.Command;
using System;

namespace MySchool.Domain.Commands.Class
{
    public class UpdateNameClassCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Turno", "Turno deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 255, "Turno", "Turno deve conter até 255 caracteres")
            );
        }
    }
}
