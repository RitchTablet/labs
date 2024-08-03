using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Shared;
using CleanArchitectureDDD.Domain.Vehicles;

namespace CleanArchitectureDDD.Domain.Rentals.Services
{
    public class PriceService
    {
        public Money CalculateRentalPeriodPrice(RentalPeriod rentalPeriod, Vehicle vehicle)
        {
            if (vehicle?.RentalPricePerDay == null || vehicle.RentalPricePerDay?.Amount == null)
            {
                throw new ArgumentException("Rental price per day must be specified for the vehicle.");
            }

            var resultPrice = vehicle.RentalPricePerDay.Amount * rentalPeriod.DurationInDays;
            var currency = vehicle?.RentalPricePerDay?.Currency;

            return new Money(resultPrice, currency);
        }

        // Método para calcular el precio de mantenimiento
        public Money CalculateMaintenancePrice(Vehicle vehicle)
        {
            if (vehicle?.RentalPricePerDay == null || vehicle.RentalPricePerDay?.Amount == null)
            {
                throw new ArgumentException("Rental price per day must be specified for the vehicle.");
            }

            if (vehicle?.MaintenancePricePerDay == null || vehicle.MaintenancePricePerDay?.Amount == null)
            {
                throw new ArgumentException("Maintenance price per day must be specified for the vehicle.");
            }

            var resultPrice = vehicle.RentalPricePerDay.Amount * vehicle.MaintenancePricePerDay.Amount;
            var currency = vehicle?.RentalPricePerDay?.Currency;

            return new Money(resultPrice, currency);
        }
    }
}