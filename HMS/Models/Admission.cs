namespace HMS.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public DateTime AdmitDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public decimal AdvancePayment { get; set; }
        public string DischargeStatus { get; set; }
        public string DoctorRemarks { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; } // Test report or admit paper
        public string Description { get; set; } // Any special notes

        // Foreign key (one-to-one)

        public int HospitalRoomId { get; set; }

        // Navigation property
        public HospitalRoom HospitalRoom { get; set; }
    }
}
