namespace MangoShopUserService.Model.ApiRequest
{
    public class UserApiRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
        public int PermissionId { get; set; }
    }
}
