using MySchool.Domain.Interfaces.Command;

namespace MySchool.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool success, string message, object data)
        {
             this.Success = success;
            this.Message = message;
            this.Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; private set; }
    }
}
