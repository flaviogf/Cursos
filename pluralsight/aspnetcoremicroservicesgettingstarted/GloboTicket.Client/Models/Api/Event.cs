using System;

namespace GloboTicket.Client.Models.Api
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
