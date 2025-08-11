namespace HMS.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string EmergencyContact { get; set; }
        public string ImagePath { get; set; } 
        public string Description { get; set; }

        // Navigation propery -onte patiient can have any medicalRecord
        public ICollection<MedicalRecord> MedicalRecords { get; set; }

        // Navigation property - one patient can have many lab tests
        public ICollection<LabTest> LabTests { get; set; }
    }
}
