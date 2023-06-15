using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Category:BaseEntity
    {
        //[MaxLength(64)]

       public string Name { get; set; }

       public ICollection<Product> Products { get; set; }
    }
}