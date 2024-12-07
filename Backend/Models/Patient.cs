namespace Backend.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<string> Conditions { get; set; } = new List<string>();

        public int CalculateAge() 
        {
            DateTime currentTime = DateTime.Now;

            int PatientAge = 0;

            if (currentTime.Month >= DateOfBirth.Month && currentTime.Day >= DateOfBirth.Day) 
            {
                PatientAge = currentTime.Year - DateOfBirth.Year;
            } 
            else 
            {
                PatientAge = currentTime.Year - DateOfBirth.Year - 1;
            }

            return PatientAge;
        }
    }
}
