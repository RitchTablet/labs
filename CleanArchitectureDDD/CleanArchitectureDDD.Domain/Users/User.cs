using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;

namespace CleanArchitectureDDD.Domain.Users
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
        }

        public string? Name { get; set; }
        public Email? Email { get; set; }      // Usando el value object Email
        public Password? Password { get; set; } // Usando el value object Password        
    }
}