namespace Backend.Models
{
    public class PatientOutputDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<string> Conditions { get; set; }
    }
}
