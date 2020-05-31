using Microsoft.EntityFrameworkCore;
using System;

namespace Project01.Models
{
    public static class ModelBuilderExtensions
    {
        public static void SeedEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasData(
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Bob",
                    LastName = "Jeferson",
                    BirthDate = new DateTime(1998, 11, 9)
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Megan",
                    LastName = "Johanson",
                    BirthDate = new DateTime(1996, 3, 25)
                });
            });
        }
    }
}
