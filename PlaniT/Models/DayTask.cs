namespace PlaniT.Models
{
    public class DayTask
    {
        public int Id { get; set; }
        public string TaskText { get; set; }
        public int DayCardId { get; set; }
        public virtual DayCard DayCard { get; set; }
    }

}
