using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HotelBookingSystem.Model
{   
    public class HotelBookingDbContext : IdentityDbContext<IdentityUser>
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
           : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new RoomConfiguration().Configure(modelBuilder.Entity<Room>());
            new ReservationConfiguration().Configure(modelBuilder.Entity<Reservation>());
            new HotelConfiguration().Configure(modelBuilder.Entity<Hotel>());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
    
}
