using System;
using Flunt.Notifications;
using Flunt.Validations;
using MySchool.Domain.Interfaces.Command;

namespace MySchool.Domain.Commands.School
{
    public class UpdateSchoolCommand : Notifiable, ICommand
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
                .HasMinLen(Street, 3, "Rua", "Rua deve conter pelo menos 3 caracteres")
                .HasMaxLen(Street, 255, "Name", "Rua deve conter até 255 caracteres")
                .HasMinLen(Number, 1, "Número", "Número deve conter pelo menos 3 caracteres")
                .HasMaxLen(Number, 20, "Número", "Número deve conter até 20 caracteres")
                .HasMinLen(Neighborhood, 1, "Bairro", "Bairro deve conter pelo menos 3 caracteres")
                .HasMaxLen(Neighborhood, 100, "Bairro", "Bairro deve conter até 100 caracteres")

                .HasMinLen(City, 3, "Cidade", "Cidade deve conter pelo menos 3 caracteres")
                .HasMaxLen(City, 255, "Cidade", "Cidade deve conter até 255 caracteres")

                .HasMinLen(State, 3, "Estado", "Estado deve conter pelo menos 3 caracteres")
                .HasMaxLen(State, 100, "Estado", "Estado deve conter até 100 caracteres")

                .HasMinLen(Country, 3, "Pais", "Pais deve conter pelo menos 3 caracteres")
                .HasMaxLen(Country, 20, "Pais", "Pais deve conter até 255 caracteres")
            );
        }
    }
}
