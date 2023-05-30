namespace AutoShop23.Models
{
    public class TechnicianStatus
    {
        //This is a really simple table (lookup, reference tables)
        public int Id { get; set; }
        public string Status { get; set; }
        //each status can have multiple technicians
        //navigation property
        public IEnumerable<Technician> Technicians { get; set; }
    }
}
