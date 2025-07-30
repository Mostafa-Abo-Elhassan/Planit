using Microsoft.AspNetCore.Identity;

namespace PlaniT.Models
{
    public class User : IdentityUser
    {
        public string JobTitle { get; set; }
        public virtual ICollection<DayCard> DayCards { get; set; }
        public virtual ICollection<DayTask> DayTasks { get; set; }
        public virtual ICollection<TodayTemplateItem> TodayTemplateItems { get; set; }
        public virtual ICollection<FutureVisionItem> FutureVisionItems { get; set; }

    }
}
