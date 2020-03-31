using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Blog.Core.DbEntities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }


    }
}
