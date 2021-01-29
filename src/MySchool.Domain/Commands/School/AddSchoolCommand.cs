using System;
using Flunt.Notifications;
using Flunt.Validations;
using MySchool.Domain.Interfaces.Command;

namespace MySchool.Domain.Commands.School
{
    public class AddSchoolCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 3, "Name", "Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 255, "Name", "Nome deve conter até 255 caracteres")
                .HasMinLen(Cnpj, 14, "Cnpj", "Cnpj inválido")
                .HasMaxLen(Cnpj, 14, "Cnpj", "Cnpj inválido")
            );
        }
    }
}
