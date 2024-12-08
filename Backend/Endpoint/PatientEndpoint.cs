using Backend.Models;
using Backend.Repository;
using Backend.Services;
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
            endpointGroup.MapPost("/search/", SearchPatientRecords);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(IRepository<Patient> repo) 
        {
            List<Patient> patients = await repo.GetAll();

            List<PatientOutputDTO> output = patients.Select((p) => ModelToDTOConverter.ConvertPatientToDTO(p)).ToList();
            return TypedResults.Ok(output);
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
            PatientOutputDTO output = ModelToDTOConverter.ConvertPatientToDTO(patient);
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

            Patient? savedPatient = await repo.Create(patient);

            return TypedResults.Created($"{savedPatient?.Id}");
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdatePatient(IRepository<Patient> repo, PatientUpdateModel inputPatient) 
        {
            Patient? dbPatient = await repo.GetSpecific(inputPatient.Id);

            if (dbPatient == null) 
            {
                return TypedResults.NotFound();
            }

            dbPatient.Name = inputPatient.Name ?? dbPatient.Name;
            dbPatient.DateOfBirth = inputPatient.DateOfBirth ?? dbPatient.DateOfBirth;
            dbPatient.Conditions = inputPatient?.Conditions ?? dbPatient.Conditions;

            Patient? updatedPatient = await repo.Update(dbPatient);
            return TypedResults.Created($"/{updatedPatient?.Id}");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeletePatient(IRepository<Patient> repo, Guid id) 
        {
            Patient? dbPatient = await repo.GetSpecific(id);
            if (dbPatient == null) 
            {
                return TypedResults.NotFound();
            }

            Patient? deletedPatient = await repo.Delete(dbPatient);

            if (deletedPatient == null) 
            {
                return TypedResults.NotFound();
            }

            PatientOutputDTO output = ModelToDTOConverter.ConvertPatientToDTO(deletedPatient);
            return TypedResults.Ok(output);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> SearchPatientRecords(PatientRepository repo, SearchRecordsModel search) 
        {
            List<Patient> matchingPatients = await repo.GetPatientByName(search.Name);

            List<PatientOutputDTO> output = matchingPatients.Select((p) => ModelToDTOConverter.ConvertPatientToDTO(p)).ToList();
            return TypedResults.Ok(output);
        }
    }
}
