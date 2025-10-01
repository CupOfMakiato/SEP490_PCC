namespace Server.Application.DTOs.Payment
{
    public class PeriodDto
    {
        public string Type { get; set; } // "Month","Quarter","Year"
        public int Value { get; set; }
        public int Year { get; set; }
    }
}
