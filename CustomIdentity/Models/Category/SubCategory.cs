﻿namespace CustomIdentity.Models.Category
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<Product>? Products { get; set; }
    }
}
