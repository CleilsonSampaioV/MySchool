using MySchool.Domain.Commands.Contract;

namespace MySchool.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
