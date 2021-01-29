using System.Threading.Tasks;
using MySchool.Domain.Commands;
using MySchool.Domain.Interfaces.Command;

namespace MySchool.Domain.Interfaces.Handler
{
    public interface IHandler<T> where T : ICommand
    {
       Task<ICommandResult> Handle(T command);
    }
}
