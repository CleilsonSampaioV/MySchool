using Flunt.Notifications;
using Flunt.Validations;
using MySchool.Domain.Interfaces.Command;
using System;

namespace MySchool.Domain.Commands.Class
{
    public class RemoveClassCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
            );
        }
    }
}
