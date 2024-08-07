using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;
using CleanArchitectureDDD.Domain.Rentals;
using CleanArchitectureDDD.Domain.Reviews.Events;
using CleanArchitectureDDD.Domain.Users;
using CleanArchitectureDDD.Domain.Vehicles;

namespace CleanArchitectureDDD.Domain.Reviews
{
    public class Review : Entity
    {
        private Review(Guid id, Content content, User user, Vehicle vehicle, Rental rental) : base(id)
        {
            Content = content;
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserId = user.Id;

            Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));
            VehicleId = vehicle.Id;

            Rental = rental ?? throw new ArgumentNullException(nameof(rental));
            RentalId = rental.Id;
        }

        public Content Content { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public Guid RentalId { get; set; }
        public Rental Rental { get; set; }


        public static Result<Review> Create(Rental rental, User user, Vehicle vehicle, Content content)
        {
            if (rental.Status != RentalStatus.Completed)
            {
                return Result.Failure<Review>(RentalErrors.NotComplete);
            }

            var review = new Review(Guid.NewGuid(), content, user, vehicle, rental);
            review.AddDomainEvent(new ReviewCreatedDomainEvent(review.Id));

            return review;
        }

    }
}