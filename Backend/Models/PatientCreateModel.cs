namespace Backend.Models
{
    public class PatientCreateModel
    {

        public required string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<string> Conditions { get; set; } = new List<string>();
    }
}
