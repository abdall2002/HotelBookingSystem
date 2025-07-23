using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Model
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasOne(u => u.ManagedHotel)
                .WithMany()
                .HasForeignKey(u => u.ManagedHotelId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
