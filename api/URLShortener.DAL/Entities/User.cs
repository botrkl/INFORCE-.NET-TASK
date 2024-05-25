namespace URLShortener.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<UrlAdress>? UrlAdresses { get; set; }
    }
}
