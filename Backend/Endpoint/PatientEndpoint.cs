using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Patient> repo) 
        {
            List<Patient> patients = await repo.GetAll();

            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetSpecific(IRepository<Patient> repo, Guid id) 
        {
            Patient? patient = await repo.GetSpecific(id);

            if (patient == null) 
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(patient); 
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository<Patient> repo, PatientCreateModel inputPatient) 
        {
            Patient patient = new Patient() {
                Id = new Guid(),
                Name = inputPatient.Name,
                DateOfBirth = inputPatient.DateOfBirth,
                Conditions = inputPatient?.Conditions?.Count > 0 ? inputPatient.Conditions : new List<string>()
            };

            Patient savedPatient = await repo.Create(patient);

            return TypedResults.Created($"{savedPatient.Id}");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> UpdatePatient(IRepository<Patient> repo, PatientUpdateModel inputPatient) 
        {
            Patient dbPatient = await repo.GetSpecific(inputPatient.Id);

            Patient updatedPatientObject = new Patient() 
            {
                Id = inputPatient.Id,
                Name = inputPatient.Name ?? dbPatient.Name,
                DateOfBirth = inputPatient.DateOfBirth ?? dbPatient.DateOfBirth,
                Conditions = inputPatient?.Conditions ?? dbPatient.Conditions
            };

            Patient updatedPatient = await repo.Update(updatedPatientObject);
            return TypedResults.Created($"/{updatedPatient.Id}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeletePatient(IRepository<Patient> repo, Guid id) 
        {
            Patient? deletedPatient = await repo.Delete(id);

            if (deletedPatient == null) 
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(deletedPatient);
        }
    }
}
