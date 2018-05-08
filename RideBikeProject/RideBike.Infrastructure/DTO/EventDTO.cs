using System;

namespace RideBike.Infrastructure.DTO
{
    public class EventDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateTime { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> ImageId { get; set; }
        public long TypeId { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public int Remain => GetDays(DateTime);

        private static int GetDays(DateTime date)
        {
            DateTime today = DateTime.Today;
            int remain = date.Day - today.Day;
            if (today > date.AddDays(remain)) remain--;
            return remain;
        }

        public string Date => GetDate(DateTime);

        private static string GetDate(DateTime date)
        {
            return date.Date.ToString();
        }
    }
}
