using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;

namespace CleanArchitectureDDD.Domain.Reviews
{
    public record Rating
    {
        public int Value { get; init; }

        private Rating(int value)=> Value = value;

        public static Result<Rating> Create(int value)
        {
            if(value < 1 || value > 5)
            {
                return Result.Failure<Rating>(RatingErrors.Invalid);
            }

            return new Rating(value);
        }
    }
}