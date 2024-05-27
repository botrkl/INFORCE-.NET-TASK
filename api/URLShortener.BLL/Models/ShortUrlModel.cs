namespace URLShortener.BLL.Models
{
    public class ShortUrlModel
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public bool canBeDeleted { get; set; }
    }
}
