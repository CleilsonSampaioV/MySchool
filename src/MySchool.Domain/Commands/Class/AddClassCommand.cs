using Flunt.Notifications;
using Flunt.Validations;
using MySchool.Domain.Interfaces.Command;
using System;

namespace MySchool.Domain.Commands.Class
{
    public class AddClassCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Shift { get; set; }
        public string Degree { get; set; }
        public string SchoolId { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 255, "Name", "Nome deve conter até 255 caracteres")

                 .HasMinLen(Shift, 3, "Turno", "Turno deve conter pelo menos 3 caracteres")
                .HasMaxLen(Shift, 255, "Turno", "Turno deve conter até 255 caracteres")

                 .HasMinLen(Degree, 3, "Grau", "Grau deve conter pelo menos 3 caracteres")
                .HasMaxLen(Degree, 255, "Grau", "Grau deve conter até 255 caracteres")
            );
        }
    }
}
