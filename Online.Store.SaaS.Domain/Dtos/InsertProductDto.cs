namespace Online.Store.SaaS.Domain.Dtos
{
    public class InsertProductDto
    {
        public string? Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }
    }
}
