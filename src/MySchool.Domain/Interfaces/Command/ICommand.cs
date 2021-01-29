using Flunt.Validations;

namespace MySchool.Domain.Interfaces.Command
{
    public interface ICommand: IValidatable
    {
        void Validate();
    }
}
