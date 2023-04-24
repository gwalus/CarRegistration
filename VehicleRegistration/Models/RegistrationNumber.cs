using System.Collections.Generic;

namespace VehicleRegistration.Models
{
    public class RegistrationNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public virtual ICollection<Reputation> Reputations { get; set; }
    }
}
