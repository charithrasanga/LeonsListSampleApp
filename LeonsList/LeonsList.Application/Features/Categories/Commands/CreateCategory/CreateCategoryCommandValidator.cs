
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using LeonsList.Application.Interfaces.Repositories;

namespace LeonsList.Application.Features.Categories.Commands.CreateCategory
{
   

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepositoryAsync categoryRepository;

        public CreateCategoryCommandValidator(ICategoryRepositoryAsync categoryRepository)
        {
            this.categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueCategory).WithMessage("{PropertyName} already exists.");


        }

        private async Task<bool> IsUniqueCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await categoryRepository.IsUniqueCategoryNameAsync(categoryName);
        }
    }




}
