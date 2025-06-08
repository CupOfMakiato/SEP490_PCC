using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain.Entities
{
    public class SuggestionRule : BaseEntity
    {
        public string WeekSuggest {  get; set; }
        //public Guid TargetNutrientId { get; set; } Chưa cần // (nullable) Nếu là để bổ sung vitamin đặc biệt

        public string Condition { get; set; } //Mô tả điều kiện: ví dụ "thiếu máu", "thiếu sắt"
        public string Note { get; set; } //Ghi chú cho bác sĩ/chuyên gia
        public IEnumerable<Food> Foods { get; set; }
    }
}
