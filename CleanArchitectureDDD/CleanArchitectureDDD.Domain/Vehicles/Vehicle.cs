using CleanArchitectureDDD.Domain.Abstractions;

namespace CleanArchitectureDDD.Domain.Vehicles
{
    public class Vehicle : Entity
    {
        public Vehicle(Guid id) : base(id)
        {
            Accessories = new List<Accessory>();
        }

        // Propiedades básicas
        public string? Make { get; set; } // Marca del vehículo
        public string? Model { get; set; } // Modelo del vehículo
        public int Year { get; set; } // Año del vehículo
        public string? Color { get; set; } // Color del vehículo
        public string? VIN { get; set; } // Número de identificación del vehículo (VIN)

        // Propiedades adicionales
        public string? LicensePlate { get; set; } // Placa del vehículo
        public string? Owner { get; set; } // Propietario del vehículo
        public double Mileage { get; set; } // Kilometraje del vehículo
        public EngineType EngineType { get; set; } // Tipo de motor (e.g., gasolina, diesel, eléctrico)
        public TransmissionType Transmission { get; set; } // Tipo de transmisión (e.g., manual, automática)
        public DateTime LastServiceDate { get; set; } // Fecha del último servicio
        public bool IsOperational { get; set; } // Indicador de si el vehículo está operativo


         // Propiedades para alquiler
        public Money? RentalPricePerDay { get; set; } // Precio de alquiler por día
        public bool IsAvailableForRent { get; set; } // Indicador de si el vehículo está disponible para alquiler
        public DateOnly? RentalStartDate { get; set; } // Fecha de inicio del alquiler
        public DateOnly? RentalEndDate { get; set; } // Fecha de finalización del alquiler
        public string? RenterName { get; set; } // Nombre del arrendatario
        public Money? MaintenancePricePerDay { get; set; } // Precio de mantenimiento por día

         // Lista de accesorios
        public List<Accessory> Accessories { get; set; } // Lista de accesorios

        // Dirección del vehículo
        public Address? Address { get; set; } // Ubicación del vehículo

    }
}
