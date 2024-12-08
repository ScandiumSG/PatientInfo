using Backend.Models;

namespace Backend.Services
{
    public static class ModelToDTOConverter
    {
        public static PatientOutputDTO ConvertPatientToDTO(Patient model) 
        { 
            PatientOutputDTO output = new PatientOutputDTO() 
            { 
                Id = model.Id,
                Name = model.Name,
                Conditions = model.Conditions,
                Age = model.CalculateAge()
            };

            return output;
        }
    }
}
