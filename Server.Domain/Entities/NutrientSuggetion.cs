namespace Server.Domain.Entities
{
    public class NutrientSuggetion : BaseEntity
    {
        public string NutrientSuggetionName { get; set; }
        public List<NutrientSuggestionAttribute> NutrientSuggestionAttributes { get; set; }
    }
}
