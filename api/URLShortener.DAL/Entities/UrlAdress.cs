namespace URLShortener.DAL.Entities
{
    public class UrlAdress : BaseEntity
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Guid UserId { get; set; }
        public User CreatedBy { get; set; }
    }
}
