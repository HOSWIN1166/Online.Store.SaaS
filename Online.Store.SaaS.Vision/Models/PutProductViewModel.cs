﻿namespace Online.Store.SaaS.Vision.Models
{
    public class PutProductViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Description { get; set; }
    }
}
