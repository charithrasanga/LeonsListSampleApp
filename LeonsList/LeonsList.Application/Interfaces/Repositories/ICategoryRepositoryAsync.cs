using LeonsList.Domain.Entities;
using System.Threading.Tasks;

namespace LeonsList.Application.Interfaces.Repositories
{
    public interface ICategoryRepositoryAsync : IGenericRepositoryAsync<Category>
    {
        Task<bool> IsUniqueCategoryNameAsync(string categoryName);
    }
}
