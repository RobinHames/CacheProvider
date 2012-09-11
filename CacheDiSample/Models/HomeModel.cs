using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CacheDiSample.Domain.Model;

namespace CacheDiSample.Models
{
    public class HomeModel
    {
        public IList<Blog> Blogs { get; set; }
    }
}