using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }

        public ICollection<Tag> Tags { get; set;}
    }
}
