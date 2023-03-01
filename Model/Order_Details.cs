namespace LiqourStore.Model
{
    public class Order_Details
    {
        public int Id { get; set; }
        public int customer_ID { get; set; }
        public string Shipping_Address { get; set; }
        public int Total_Cost { get; set; }
        public int Ordered_Date { get; set; }
    }
}
