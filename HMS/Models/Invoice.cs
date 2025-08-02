namespace HMS.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal RoomChrge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal LabTestCharge { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string ImagePath { get; set; } // Scanned copy of invoice
        public string Description { get; set; } // Billing details
    }
}
