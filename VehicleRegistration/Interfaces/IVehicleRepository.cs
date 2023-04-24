using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleRegistration.Models;

namespace VehicleRegistration.Interfaces
{
    public interface IVehicleRepository
    {
        Task<bool> AddVehicle(Vehicle vehicle);
        Task<bool> RemoveVehicle(int vehicleId);
        Task<IList<string>> GetPrefixes();
        Task<bool> CheckRegistrationNumber(string number);
        Task<bool> RemoveRegistrationNumber(string number);
        Task<IList<Vehicle>> GetVehiclesForPerson(string pesel);
    }
}
