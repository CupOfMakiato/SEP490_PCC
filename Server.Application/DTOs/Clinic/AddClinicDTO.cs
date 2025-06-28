namespace Server.Application.DTOs.Clinic
{
    public class AddClinicDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public bool IsInsuranceAccepted { get; set; }
    }
}
