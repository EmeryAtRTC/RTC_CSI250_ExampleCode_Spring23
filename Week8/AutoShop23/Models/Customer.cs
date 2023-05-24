namespace AutoShop23.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        //navigation properties
        //A customer can have many vehicles
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
