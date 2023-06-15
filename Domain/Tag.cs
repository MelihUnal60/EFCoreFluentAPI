namespace Domain
{
    public class Tag:BaseEntity
    {
        public string TagName { get; set; }

        public ICollection<Post> Posts { get; set; }  //post ve tag çoka çoka ilişkili oluştu. posttag tablosu otomatik oluşur 
    }
}