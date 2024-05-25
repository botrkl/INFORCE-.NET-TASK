namespace URLShortener.BLL.Models
{
    public class UrlAdressModel
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Guid UserId { get; set; }
    }
}
