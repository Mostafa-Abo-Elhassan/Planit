namespace PlaniT.Models
{
    public class DayTask
    {
        public int Id { get; set; }
        public string TaskText { get; set; }
        public int DayCardId { get; set; }
        public virtual DayCard DayCard { get; set; }
        public string UserId { get; set; }         // ✅ FK واضح

        public virtual User User { get; set; }

    }

}
