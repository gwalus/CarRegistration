using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleRegistration.Interfaces;
using VehicleRegistration.Models;

namespace VehicleRegistration.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _dataContext;

        public VehicleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            await _dataContext.Vehicles.AddAsync(vehicle);
            return await SaveChangesAsync();
        }

        public async Task<bool> CheckRegistrationNumber(string number)
        {
            return await _dataContext.Prefixes.AnyAsync(p => p.Name.Equals(number));
        }

        public async Task<IList<string>> GetPrefixes()
        {
            return await _dataContext.Prefixes.Select(p => p.Name).ToListAsync();
        }

        public async Task<IList<Vehicle>> GetVehiclesForPerson(string pesel)
        {
            return await _dataContext.Vehicles
                .Include(x => x.RegistrationNumber)
                .Include(x => x.Person)
                .Where(x => x.Person.Pesel == pesel)
                .Select(x => new Vehicle
                {
                    Brand = x.Brand,
                    Model = x.Model,
                    ProductionYear = x.ProductionYear,
                    PurchaseDate = x.PurchaseDate,
                    VinNumber = x.VinNumber,
                    RegistrationNumber = x.RegistrationNumber
                })
                .ToListAsync();
        }

        public async Task<bool> RemoveRegistrationNumber(string number)
        {
            var registrationNumber = await _dataContext.RegistrationNumbers.FirstOrDefaultAsync(r => r.Number == number);

            if (registrationNumber != null)
            {
                _dataContext.RegistrationNumbers.Remove(registrationNumber);
            }

            return await SaveChangesAsync();
        }

        public async Task<bool> RemoveVehicle(int vehicleId)
        {
            var vehicle = await _dataContext.Vehicles.SingleOrDefaultAsync(v => v.Id == vehicleId);

            _dataContext.Vehicles.Remove(vehicle);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
