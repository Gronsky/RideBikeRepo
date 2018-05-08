using System;

namespace RideBike.Infrastructure.DTO
{
    public class EventUserDTO
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long UserId { get; set; }
        public Nullable<long> BikeId { get; set; }
    }
}
