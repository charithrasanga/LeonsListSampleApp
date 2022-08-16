
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using LeonsList.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LeonsList.Application.Features.Listings.Commands.CreateListing
{
    public class CreateAnonymousListingCommandValidator : AbstractValidator<CreateAnonymousListingCommand>
    {
        private readonly IListingRepositoryAsync _listingRepository;
        private readonly ICategoryRepositoryAsync _categoryRepository;
        public CreateAnonymousListingCommandValidator(IListingRepositoryAsync listingRepository, ICategoryRepositoryAsync categoryRepository)
        {
            this._listingRepository = listingRepository;
            _categoryRepository = categoryRepository;
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(5000).WithMessage("{PropertyName} must not exceed 5000 characters.");

            RuleFor(p => p.categoryId)
              .GreaterThanOrEqualTo(1).WithMessage("Please provide a valid category id.")
              .NotEmpty().WithMessage("Please provide a valid category id.")
              .MustAsync(IsValidCategory).WithMessage("Specified category is not valid or no longer exists.");

            RuleFor(p => p.Attachments)
                .MustAsync(IsValidFiles).WithMessage("You can only upload up to 10 files only");



        }



        private async Task<bool> IsValidCategory(int Id, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetAllAsync().Result.Where(x => x.Id == Id).Any();

        }

        private async Task<bool> IsValidFiles(IList<IFormFile> Attachments, CancellationToken cancellationToken)
        {
            if (Attachments.Count > 10)
            {
                return false;
            }
            else
            {
                return true;
            }


        }


    }




}
