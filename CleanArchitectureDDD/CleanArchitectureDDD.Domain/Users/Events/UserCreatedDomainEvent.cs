using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureDDD.Domain.Users.Events
{
    public record UserCreatedEvent(Guid UserId, string UserName) : INotification;
}