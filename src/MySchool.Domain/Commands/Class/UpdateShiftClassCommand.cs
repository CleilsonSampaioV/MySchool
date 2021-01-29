using Flunt.Notifications;
using Flunt.Validations;
using MySchool.Domain.Interfaces.Command;
using System;

namespace MySchool.Domain.Commands.Class
{
    public class UpdateShiftClassCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Shift { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Shift, 3, "Turno", "Turno deve conter pelo menos 3 caracteres")
                .HasMaxLen(Shift, 255, "Turno", "Turno deve conter até 255 caracteres")
            );
        }
    }
}
