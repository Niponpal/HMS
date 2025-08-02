namespace HMS.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public int ExperienceYears { get; set; }
        public string Gender { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; } // Doctor photo
        public string Description { get; set; } // Bio or profile summary
    }
}
