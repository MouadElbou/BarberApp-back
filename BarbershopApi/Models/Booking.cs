namespace BarbershopApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Service { get; set; }
        public string Barber { get; set; }
        public DateTime Date { get; set; }
        public string TimeSlot { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}