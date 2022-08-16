using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Domain.Entities;
using LeonsList.Infrastructure.Persistence.Contexts;
using LeonsList.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LeonsList.Infrastructure.Persistence.Repositories
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>, ICategoryRepositoryAsync
    {
        private readonly DbSet<Category> _categories;

        public CategoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Set<Category>();
           
        }

     

        public Task<bool> IsUniqueCategoryNameAsync(string categoryName)
        { return _categories.AllAsync(p => p.Name != categoryName);
           
        }
    }
}
