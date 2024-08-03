using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Vehicles;

namespace CleanArchitectureDDD.Domain.Rentals.Interfaces
{
    public interface IRentalRepository
    {
        Task<Rental?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> IsOverlappingAsync(Vehicle vehicle, RentalPeriod rentalPeriod, CancellationToken cancellationToken = default);
        Task<bool> IsOverlappingAsync(Guid vehicleId, RentalPeriod rentalPeriod, CancellationToken cancellationToken = default);
        void Add(Rental rental);

    }
}