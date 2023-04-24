using System.Collections.Generic;

namespace VehicleRegistration.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; } = 18;
        public string Pesel { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
