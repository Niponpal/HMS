namespace HMS.Models
{
    public class LabTest
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public string TestResult { get; set; }
        public string Status { get; set; }
        public decimal TestFee { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; } // Report image
        public string Description { get; set; } // Test result summary
    }
}
