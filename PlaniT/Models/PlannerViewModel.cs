namespace PlaniT.Models
{
    public class PlannerViewModel
    {
        public List<TodayTemplateItem> TodayTemplateItems { get; set; }
        public List<DayCard> DayCards { get; set; }
        public List<FutureVisionItem> FutureVisionItems { get; set; }
    }
}