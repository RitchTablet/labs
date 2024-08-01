using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.Domain.Users
{
    public record Password(string HashedValue);
}