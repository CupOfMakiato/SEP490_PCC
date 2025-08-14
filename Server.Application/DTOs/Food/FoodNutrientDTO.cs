using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs.Food
{
    public class FoodNutrientDTO
    {
        public string NutrientName { get; set; }
        // Tên chất dinh dưỡng: "Protein", "Glucid", "Vitamin B6"...

        public Guid NutrientId { get; set; }
        // ID định danh chất dinh dưỡng (liên kết tới bảng Nutrient trong DB)

        public double NutrientEquivalent { get; set; }
        // 1 đơn vị quy đổi ra bao nhiêu gram chất này 
        // (ví dụ: 1 thìa đường ≈ 12g glucid)

        public string Unit { get; set; }
        // Đơn vị đo cho lượng dinh dưỡng: "g", "mg", "µg", "kcal"...

        public double AmountPerUnit { get; set; }
        // Lượng chất dinh dưỡng trong 1 đơn vị thực phẩm (g, mg, kcal...) 
        // Ví dụ: 100g gạo chứa 76.2g glucid

        public double TotalWeight { get; set; }
        // Trọng lượng thực phẩm trước khi chế biến (bao gồm phần bỏ đi) - g

        public string FoodEquivalent { get; set; }
        // Quy đổi thực phẩm ra tên dễ hiểu: "1 bát cơm", "1 quả chuối"
    }
}
