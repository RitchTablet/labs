using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureDDD.Domain.Abstractions;

namespace CleanArchitectureDDD.Domain.Reviews
{
    public static class RatingErrors
    {
        public static Error Invalid =  new Error("Rating.Invalid", "Ranting is invalid.");
    }
}