using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Model
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");
            builder.HasKey(r => r.Id);

            builder.Property(r => r.GuestName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.GuestPhone)
                .HasMaxLength(20);

            builder.Property(r => r.CheckInDate)
                .IsRequired();

            builder.Property(r => r.CheckOutDate)
                .IsRequired();

            builder.HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
