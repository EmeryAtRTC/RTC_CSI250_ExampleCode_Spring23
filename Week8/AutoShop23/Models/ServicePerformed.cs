﻿namespace AutoShop23.Models
{
    public class ServicePerformed
    {
        public int Id { get; set; }
        public int TechnicianId { get; set; }
        public int VehicleId { get; set; }
        public int ServiceStatusId { get; set; }
        public DateTime TimePerformed { get; set; }
        public string Notes { get; set; }
        //navigation property
        public Technician Technician { get; set; }
        public Vehicle Vehicle { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}
