namespace CustomIdentity.Models.Category
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }
    }
}
