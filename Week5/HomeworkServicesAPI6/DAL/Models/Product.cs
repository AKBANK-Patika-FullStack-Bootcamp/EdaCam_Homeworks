namespace DAL.Models
{
    public class Product
    {
        public int Id{ get; set; }
        public string? Name{ get; set; }

        public double Price { get; set; }
        public string? Barcode { get; set; }

        public string? Weight { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int BrandId { get; set; }
    }
}