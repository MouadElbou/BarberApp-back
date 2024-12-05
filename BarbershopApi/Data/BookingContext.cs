    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Sqlite;
    using BarbershopApi.Models;

    namespace BarbershopApi.Data
    {
        public class BookingContext : DbContext
        {
            public DbSet<Booking> Bookings { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=barbershop.db");
        }
    }
