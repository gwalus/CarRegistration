namespace VehicleRegistration.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; } = 2000;
        public string VinNumber { get; set; }
        public string PurchaseDate { get; set; }
        public virtual Person Person { get; set; }
        public virtual RegistrationNumber RegistrationNumber { get; set; }
    }
}
