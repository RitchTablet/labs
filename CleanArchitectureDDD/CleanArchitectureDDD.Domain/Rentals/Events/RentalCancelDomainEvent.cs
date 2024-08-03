using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureDDD.Domain.Rentals.Events
{
    public record RentalCancelDomainEvent(Guid rentalId) : INotification;
}