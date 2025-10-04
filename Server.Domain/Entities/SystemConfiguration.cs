using Server.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities
{
    public class SystemConfiguration
    { 
        public double BaseCalories { get; set; }
        public double AdditionalCalories { get; set; } //50 - 250 - 450
        public float? MaxEnergyPercentage { get; set; }
        public float? MinEnergyPercentage { get; set; }
        //g/day
        public float? MaxValuePerDay { get; set; }
        public float? MinValuePerDay { get; set; }
        //g/kg/day
        public string Unit { get; set; }
        public double Amount { get; set; }
        public float? MinAnimalProteinPercentageRequire { get; set; }
        public int Type { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public double AmountPerUnit { get; set; } // lượng dinh dưỡng trong 1 đơn vị thực phẩm (g)
        public double TotalWeight { get; set; }   // trọng lượng kể cả thải bỏ (g)
        public bool IsActive { get; set; } = true;
    }
}
