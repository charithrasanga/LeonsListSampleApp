using LeonsList.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeonsList.Application.Interfaces.Repositories
{
    public interface IPictureRepositoryAsync : IGenericRepositoryAsync<Picture>
    {
        List<int> getListingImages(int listingId);
    }
}
