namespace HMS.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string Notes { get; set; }
        public string TestResults { get; set; }
        public string NextVisitSuggestion { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImagePath { get; set; } 
        public string Description { get; set; }

        // Foreign key
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
