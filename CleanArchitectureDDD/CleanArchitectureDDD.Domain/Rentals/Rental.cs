using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;
using CleanArchitectureDDD.Domain.Rentals.Events;
using CleanArchitectureDDD.Domain.Rentals.Services;
using CleanArchitectureDDD.Domain.Shared;
using CleanArchitectureDDD.Domain.Users;
using CleanArchitectureDDD.Domain.Vehicles;

namespace CleanArchitectureDDD.Domain.Rentals
{
    public class Rental : Entity
    {

        private Rental(Guid id, Guid userId, Guid vehicleId, RentalStatus status, RentalPeriod rentalPeriod,
               Money rentalPeriodPrice, Money maintenancePrice, Money totalPrice,
               User? user = null, Vehicle? vehicle = null)
    : base(id)
        {
            // Asignación de IDs primero
            UserId = userId;
            VehicleId = vehicleId;

            // Asignación de otros campos
            Status = status;
            RentalPeriod = rentalPeriod ?? throw new ArgumentNullException(nameof(rentalPeriod));
            RentalPeriodPrice = rentalPeriodPrice ?? throw new ArgumentNullException(nameof(rentalPeriodPrice));
            MaintenancePrice = maintenancePrice ?? throw new ArgumentNullException(nameof(maintenancePrice));
            TotalPrice = totalPrice ?? throw new ArgumentNullException(nameof(totalPrice));
            User = user;
            Vehicle = vehicle;
        }

        // Estado del alquiler
        public RentalStatus Status { get; set; }
        public RentalPeriod RentalPeriod { get; set; }

        // Dinero
        public Money RentalPeriodPrice { get; set; }
        public Money MaintenancePrice { get; set; }
        public Money TotalPrice { get; set; }


        // Llave foránea hacia User
        public Guid UserId { get; set; }
        public User? User { get; set; }

        // Llave foránea hacia Vehicle
        public Guid VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        // TODO: Add correctly PriceService... 
        public static Rental Reserve(Guid userId, Vehicle vehicle, RentalPeriod rentalPeriod, PriceService priceService)
        {

            // Usar el servicio de precios para calcular los costos
            Money rentalPeriodPrice = priceService.CalculateRentalPeriodPrice(rentalPeriod, vehicle);
            Money maintenancePrice = priceService.CalculateMaintenancePrice(vehicle);
            Money totalPrice = rentalPeriodPrice + maintenancePrice;

            // Crea y retorna una nueva instancia de Rental con estado "Reserved"
            var rental = new Rental(
                id: Guid.NewGuid(),          // Genera un nuevo ID único para el alquiler
                userId: userId,              // ID del usuario que hace la reserva
                vehicleId: vehicle.Id,        // ID del vehículo reservado
                status: RentalStatus.PendingApprove, // Estado del alquiler
                rentalPeriod: rentalPeriod,  // Período del alquiler
                rentalPeriodPrice: rentalPeriodPrice, // Precio del período de alquiler
                maintenancePrice: maintenancePrice,   // Precio de mantenimiento
                totalPrice: totalPrice       // Precio total
            );


            vehicle.RentalStartDate = rentalPeriod.StartDate;
            vehicle.RentalEndDate = rentalPeriod.EndDate;

            rental.AddDomainEvent(new RentalReserveDomainEvent(rental.Id));

            return rental;
        }

        public Result Approve(DateTime utcnoew)
        {
            if (Status != RentalStatus.PendingApprove)
            {
                return Result.Failure(RentalErrors.NotPendingApproved);
            }

            Status = RentalStatus.Approved;

            AddDomainEvent(new RentalApproveDomainEvent(Id));

            return Result.Success();
        }

        public Result Confirm(DateTime utcnoew)
        {
            if (Status != RentalStatus.Approved)
            {
                return Result.Failure(RentalErrors.NotApproved);
            }

            Status = RentalStatus.Active;

            AddDomainEvent(new RentalConfirmDomainEvent(Id));

            return Result.Success();
        }


        public Result Complete(DateTime utcnoew)
        {
            if (Status != RentalStatus.Active)
            {
                return Result.Failure(RentalErrors.NotActive);
            }

            Status = RentalStatus.Completed;

            AddDomainEvent(new RentalCompleteDomainEvent(Id));

            return Result.Success();
        }

        public Result Reject(DateTime utcnoew)
        {
            if (Status != RentalStatus.PendingApprove)
            {
                return Result.Failure(RentalErrors.NotPendingApproved);
            }

            Status = RentalStatus.Reject;

            AddDomainEvent(new RentalRejectDomainEvent(Id));

            return Result.Success();
        }

        public Result Cancel(DateTime utcnoew)
        {
            if (Status == RentalStatus.Active)
            {
                return Result.Failure(RentalErrors.Active);
            }

            if (Status != RentalStatus.Approved)
            {
                return Result.Failure(RentalErrors.NotApproved);
            }

            Status = RentalStatus.Cancelled;

            AddDomainEvent(new RentalCancelDomainEvent(Id));

            return Result.Success();
        }
    }
}