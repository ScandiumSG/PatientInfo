using Backend.Models;
using Backend.Repository;

namespace Backend.Endpoint
{
    public static class PatientEndpoint
    {
        public static void PatientEndpointConfiguration(this WebApplication app) {
            var endpointGroup = app.MapGroup("/patient/");

            endpointGroup.MapGet("/", GetAll);
            endpointGroup.MapGet("/{id}", GetSpecific);
            endpointGroup.MapPost("/", CreatePatient);
            endpointGroup.MapPut("/", UpdatePatient);
            endpointGroup.MapDelete("/{id}", DeletePatient);
        }

        public static IResult GetAll() 
        {
            return TypedResults.Ok();
        }

        public static IResult GetSpecific(int id) 
        { 
            return TypedResults.Ok(); 
        }

        public static IResult CreatePatient(IRepository<Patient> repo) 
        {
            return TypedResults.Ok();
        }

        public static IResult UpdatePatient(IRepository<Patient> repo) 
        {
            return TypedResults.Ok();
        }

        public static IResult DeletePatient(IRepository<Patient> repo) 
        {
            return TypedResults.Ok();
        }
    }
}
