namespace URLShortener.DAL.Entities
{
    public class UrlAdress : BaseEntity
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
