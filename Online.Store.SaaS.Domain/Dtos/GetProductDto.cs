namespace Online.Store.SaaS.Domain.Dtos
{
    public class GetProductDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }
    }
}
