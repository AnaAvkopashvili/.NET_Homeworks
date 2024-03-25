﻿namespace PizzaRestaurant.API.infrastructure.Models.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}