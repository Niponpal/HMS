namespace HMS.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Shift { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string ImagePath { get; set; } // Photo of the staff
        public string Description { get; set; } // Job responsibility or short bio
    }
}
