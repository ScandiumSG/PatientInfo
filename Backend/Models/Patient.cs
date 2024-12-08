namespace Backend.Models
{
    public class Patient
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<string> Conditions { get; set; } = new List<string>();

        /// <summary>
        /// Calculate the age of the person based on current time and the recorded DateOfBirth value.
        /// </summary>
        /// <returns>Int of the calculate age</returns>
        public int CalculateAge() 
        {
            DateTime currentTime = DateTime.Now;

            int PatientAge = currentTime.Year - DateOfBirth.Year;

            if (currentTime < DateOfBirth.AddYears(PatientAge))
            {
                PatientAge--;
            }

            return PatientAge;
        }
    }
}
