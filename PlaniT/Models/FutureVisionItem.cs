namespace PlaniT.Models
{
    public class FutureVisionItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public string UserId { get; set; }         // ✅ FK واضح

        public virtual User User { get; set; }



    }
}
