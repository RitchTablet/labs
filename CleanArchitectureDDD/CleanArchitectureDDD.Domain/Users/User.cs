using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;
using CleanArchitectureDDD.Domain.Users.Events;

namespace CleanArchitectureDDD.Domain.Users
{
    public class User : Entity
    {
        public User(Guid id, string name, Email email, Password password) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            AddDomainEvent(new UserCreatedEvent(id, name));
        }

        public string? Name { get; private set; }
        public Email? Email { get; private set; }      // Usando el value object Email
        public Password? Password { get; private set; } // Usando el value object Password        
    }
}