namespace PlaniT.Models
{
    public class TodayTemplateItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }         // ✅ FK واضح

        public virtual User User { get; set; }

    }






}
