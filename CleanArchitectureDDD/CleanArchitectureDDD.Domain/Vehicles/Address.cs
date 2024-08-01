using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.Domain.Vehicles
{
    public record Address(
        string Street,
        string City,
        string State,
        string PostalCode,
        string Country
    );
}