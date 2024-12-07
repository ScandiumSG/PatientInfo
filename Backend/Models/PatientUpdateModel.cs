namespace Backend.Models
{
    public class PatientUpdateModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public List<string> Conditions { get; set; } = new List<string>();
    }
}
