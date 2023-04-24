using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRegistration.Interfaces;
using VehicleRegistration.Models;

namespace VehicleRegistration.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOpinionToRegistrationNumber(string number, string opinion)
        {
            var registrationNumber = await _context.RegistrationNumbers
                .Include(x => x.Reputations)
                .FirstOrDefaultAsync(x => x.Number == number.TrimEnd());          

            if(registrationNumber != null)
            {
                registrationNumber.Reputations.Add(new Reputation { Opinion = opinion });
            }
            return await SaveChangesAsync();
        }

        public async Task<IList<string>> GetOpinionsForRegistrationNumber(string number)
        {
            var rep = await _context.Reputations
                .Include(x => x.RegistrationNumber)
                .Where(r => r.RegistrationNumber.Number == number)
                .Select(x => x.Opinion)
                .ToListAsync();

            return rep;
        }

        public async Task<Person> GetPersonByPesel(string pesel)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.Pesel == pesel);
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
