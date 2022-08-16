using LeonsList.Application.Interfaces.Repositories;
using LeonsList.Domain.Entities;
using LeonsList.Infrastructure.Persistence.Contexts;
using LeonsList.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LeonsList.Infrastructure.Persistence.Repositories
{
    public class PictureRepositoryAsync : GenericRepositoryAsync<Picture>, IPictureRepositoryAsync
    {
        private readonly DbSet<Picture> _pictures;

        public PictureRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _pictures = dbContext.Set<Picture>();

        }

        public List<int> getListingImages(int listingId)
        {
         return _pictures.Where(x=>x.Listing.Id == listingId && x.IsDeleted==false).Select(x=>x.Id).ToList();   
           
        }
    }
}
