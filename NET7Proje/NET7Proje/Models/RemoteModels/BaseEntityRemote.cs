namespace NET7Proje.Models.RemoteModels
{
    public class BaseEntityRemote
    {
        public BaseEntityRemote()
        {
            CreatedDate = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
