using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleRegistration.Models;

namespace VehicleRegistration.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonByPesel(string pesel);
        Task<bool> AddOpinionToRegistrationNumber(string number, string opinion);
        Task<IList<string>> GetOpinionsForRegistrationNumber(string number);
    }
}
