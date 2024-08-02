using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;
using CleanArchitectureDDD.Domain.Rentals.Events;
using CleanArchitectureDDD.Domain.Rentals.Services;
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
        public static Rental Reserve(Guid userId, Guid vehicleId, RentalPeriod rentalPeriod, PriceService priceService)
        {
            // TODO: test vehicle
            var vehicle = new Vehicle(new Guid());

            // Usar el servicio de precios para calcular los costos
            Money rentalPeriodPrice = priceService.CalculateRentalPeriodPrice(rentalPeriod, vehicle);
            Money maintenancePrice = priceService.CalculateMaintenancePrice(vehicle);
            Money totalPrice = rentalPeriodPrice + maintenancePrice;

            // Crea y retorna una nueva instancia de Rental con estado "Reserved"
            var rental = new Rental(
                id: Guid.NewGuid(),          // Genera un nuevo ID único para el alquiler
                userId: userId,              // ID del usuario que hace la reserva
                vehicleId: vehicleId,        // ID del vehículo reservado
                status: RentalStatus.Approved, // Estado del alquiler
                rentalPeriod: rentalPeriod,  // Período del alquiler
                rentalPeriodPrice: rentalPeriodPrice, // Precio del período de alquiler
                maintenancePrice: maintenancePrice,   // Precio de mantenimiento
                totalPrice: totalPrice       // Precio total
            );


            rental.AddDomainEvent(new RentalReserveDomainEvent(rental.Id));

            return rental;
        }
    }
}