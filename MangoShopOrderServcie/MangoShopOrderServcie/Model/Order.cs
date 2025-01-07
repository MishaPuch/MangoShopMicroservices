namespace MangoShopOrderServcie.Model
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public List<int> ProductsId { get; set; }
        public DateTime CreatedDate { get; set; }

        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
    }
}
