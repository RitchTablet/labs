using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureDDD.Domain.Reviews.Events
{
    public record ReviewCreatedDomainEvent(Guid reviewId) : INotification;
}