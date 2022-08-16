using FluentValidation;
using LeonsList.Application.Interfaces.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeonsList.Application.Features.Listings.Commands.UpdateListing
{
    public class UpdateListingCommandValidator : AbstractValidator<UpdateListingCommand>
    {

        private readonly ICategoryRepositoryAsync _categoryRepository;
        public UpdateListingCommandValidator(IListingRepositoryAsync listingRepository, ICategoryRepositoryAsync categoryRepository)
        {

            _categoryRepository = categoryRepository;
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(5000).WithMessage("{PropertyName} must not exceed 5000 characters.");

            RuleFor(p => p.CategoryId)
              .GreaterThanOrEqualTo(1).WithMessage("Please provide a valid category id.")
              .NotEmpty().WithMessage("Please provide a valid category id.")
              .MustAsync(IsValidCategory).WithMessage("Specified category is not valid or no longer exists.");


        }



        private async Task<bool> IsValidCategory(int Id, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetAllAsync().Result.Where(x => x.Id == Id).Any();

        }


    }
}
