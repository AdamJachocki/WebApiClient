namespace WebAPI.Models
{
    public class Order: DbItem
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public DateTimeOffset OrderDate { get; set; }
    }
}
