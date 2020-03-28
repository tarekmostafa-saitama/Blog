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
    public class CategoryRepository : Repository<Category,int>, ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
