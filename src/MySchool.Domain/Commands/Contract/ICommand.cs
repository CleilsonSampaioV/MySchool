using Flunt.Validations;

namespace MySchool.Domain.Commands.Contract
{
    public interface ICommand: IValidatable
    {
        void Validate();
    }
}
