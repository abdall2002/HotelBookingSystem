using HotelBookingSystem.Model;

namespace HotelBookingSystem.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        // ربط المالك
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        // ربط المدير
        public string ManagerId { get; set; }
        public User Manager { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }

}
