namespace AutoShop23.Models
{
    public class Technician
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeNumber { get; set; }
        //navigation properties
        //each technician has multiple serviceperformed
        public IEnumerable<ServicePerformed> ServicesPerformed { get; set; }

    }
}
