using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CleanArchitectureDDD.Domain.Rentals.Events
{
    public record RentalRejectDomainEvent(Guid rentalId) : INotification;
}