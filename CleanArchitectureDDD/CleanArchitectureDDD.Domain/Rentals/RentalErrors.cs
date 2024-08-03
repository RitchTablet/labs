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
        public static Error NotPendingApproved =  new Error("Rental.NotPendingApproved", "The rental is not pending for approved.");
        public static Error NotApproved =  new Error("Rental.NotApproved", "The rental is not approved.");
        public static Error Active =  new Error("Rental.Active", "The rental is active.");
    }
}