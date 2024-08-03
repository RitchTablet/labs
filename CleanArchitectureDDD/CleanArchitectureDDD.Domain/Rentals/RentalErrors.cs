using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;

namespace CleanArchitectureDDD.Domain.Rentals
{
    public static class RentalErrors
    {
        public static Error NotFound =  new Error("Rental.NotFound", "The rental id is not found.");
        public static Error Overlap =  new Error("Rental.Overlap", "The rental is taken by other customer.");
        public static Error NotReserved =  new Error("Rental.NotReserved", "The rental is not reserved.");
        public static Error NotConfirmed =  new Error("Rental.NotConfirm", "The rental is not confirmed.");
        public static Error Active =  new Error("Rental.Active", "The rental is active.");
    }
}