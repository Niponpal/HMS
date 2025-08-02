namespace HMS.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string MedicineName { get; set; }
        public string Manufacturer { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int StockQuantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public string UsageInstructions { get; set; }
        public DateTime AddedDate { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; } // Medicine package photo
        public string Description { get; set; } // Purpose or warning info
    }
}
