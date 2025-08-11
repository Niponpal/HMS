namespace HMS.Models
{
    public class HospitalRoom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public decimal RoomChargesPerDay { get; set; }
        public string Floor { get; set; }
        public int Capacity { get; set; }
        public int OccupiedBeds { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ImagePath { get; set; } // Room image

        // Navigation property (one-to-one)
        public Admission Admission { get; set; }

    }
}
