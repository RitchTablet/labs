using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureDDD.Domain.Rentals
{
    public record RentalPeriod
    {
        private RentalPeriod()
        {}

        public DateOnly StartDate { get; init; }
        public DateOnly EndDate { get; init; }
        public int DurationInDays => EndDate.DayNumber - StartDate.DayNumber;

        public static RentalPeriod Create(DateOnly startDate, DateOnly endDate)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            return new RentalPeriod()
            {
                StartDate = startDate,
                EndDate = endDate,
            };
        }

    }
}