using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext: DbContext
    {
        public required DbSet<Patient> Patients { get; set; }
    }
}
