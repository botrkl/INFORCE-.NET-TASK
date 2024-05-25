namespace URLShortener.BLL.Models.AddModels
{
    public class AddUrlAdressModel
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
    }
}
