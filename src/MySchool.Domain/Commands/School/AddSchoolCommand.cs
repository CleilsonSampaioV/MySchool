using Flunt.Notifications;
using MySchool.Domain.Commands.Contract;

namespace MySchool.Domain.Commands.School
{
    public class AddSchoolCommand : Notifiable, ICommand
    {
        public AddSchoolCommand() {}

        public AddSchoolCommand(string name, string zipCode, string address, string complement, string neighborhood, string city, string state, string country)
        {
            Name = name;
            ZipCode = zipCode;
            Address = address;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
        }

        public string Name { get; private set; }
        public string ZipCode { get; private set; }
        public string Address { get; private set; }
        public string Complement { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public void Validate()
        {
            //AddNotifications(new Contract()
            //    .Requires()
            //    .HasMinLen(Name, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
            //    .HasMaxLen(Name, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
            //);
        }
    }
}
