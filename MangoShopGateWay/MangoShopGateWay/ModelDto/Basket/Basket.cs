namespace MangoShopGateWay.ModelDto.Basket
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; } = 1;
    }
}
