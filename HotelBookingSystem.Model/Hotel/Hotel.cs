﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem.Model
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string? OwnerId { get; set; }
        public User? Owner { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
