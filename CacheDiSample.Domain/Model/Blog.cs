using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheDiSample.Domain.Model
{
    public class Blog : EntityBase
    {
        public Blog()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
