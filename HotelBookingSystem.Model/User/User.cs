using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelBookingSystem.Model
{
    public class User : IdentityUser
    {
        public ICollection<Hotel> OwnedHotels { get; set; } = new List<Hotel>();

        public int? ManagedHotelId { get; set; }
        public Hotel? ManagedHotel { get; set; }
    }
}
