namespace Online.Store.SaaS.Domain.Models.Domains
{
    public class Product
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int UnitPrice { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
