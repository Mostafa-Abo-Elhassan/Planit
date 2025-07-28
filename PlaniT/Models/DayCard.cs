namespace PlaniT.Models
{
    public class DayCard
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        public virtual ICollection<DayTask> Tasks { get; set; }
    }
}
