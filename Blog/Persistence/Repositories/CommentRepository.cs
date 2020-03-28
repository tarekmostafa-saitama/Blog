using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.DbEntities;
using Blog.Core.Repositories;
using Blog.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repositories
{
    public class CommentRepository : Repository<Comment, int>, ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
