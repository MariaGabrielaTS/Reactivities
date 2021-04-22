using System;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; } // Use of guid to have the possibility to create from the server side or client side
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}