namespace NET7Proje.Models.LocalModels
{
    public class BaseEntityLocal
    {
        public BaseEntityLocal()
        {
               CreatedDate= DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
