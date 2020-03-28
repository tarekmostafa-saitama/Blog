using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.DbEntities;

namespace Blog.Core.Repositories
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        
    }
}
