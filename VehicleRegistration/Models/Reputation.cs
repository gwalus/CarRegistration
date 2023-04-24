namespace VehicleRegistration.Models
{
    public class Reputation
    {
        public int Id { get; set; }
        public string Opinion { get; set; }
        public virtual RegistrationNumber RegistrationNumber { get; set; }
    }
}
