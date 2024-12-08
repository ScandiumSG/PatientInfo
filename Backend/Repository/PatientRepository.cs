using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class PatientRepository
    {
        private DataContext _context;
        private DbSet<Patient> _dbSet;

        public PatientRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<Patient>();
        }

        public async Task<List<Patient>> GetPatientByName(string name, bool strict=false) 
        {
            List<Patient> matchingPatients;

            if (strict)
            {
                matchingPatients = await _dbSet.Where(e => e.Name == name).ToListAsync();
            }
            else 
            {
                matchingPatients = await _dbSet.Where(e => e.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();
            }

            return matchingPatients;
        }
    }
}
