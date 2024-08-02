namespace CleanArchitectureDDD.Domain.Rentals
{
    public enum RentalStatus
    {
        Pending,      // El alquiler está pendiente de aprobación
        Approved,     // El alquiler ha sido aprobado
        Active,       // El alquiler está actualmente en curso
        Completed,    // El alquiler ha finalizado
        Cancelled,    // El alquiler ha sido cancelado
        Overdue
    }
}