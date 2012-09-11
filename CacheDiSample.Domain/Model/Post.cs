using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheDiSample.Domain.Model
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
