using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Domain.Entities;
using LeonsList.Infrastructure.Persistence.Contexts;
using LeonsList.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LeonsList.Infrastructure.Persistence.Repositories
{
    public class ListingRepositoryAsync : GenericRepositoryAsync<Listing>, IListingRepositoryAsync
    {
        private readonly DbSet<Listing> _listings;

        public ListingRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _listings = dbContext.Set<Listing>();

        }

    }
}
