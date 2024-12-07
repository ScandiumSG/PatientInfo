namespace Backend.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<string> Conditions { get; set; } = new List<string>();
    }
}
