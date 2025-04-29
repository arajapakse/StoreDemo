using FluentValidation;
using StoreDemo.Application.Contracts.Persistence;

namespace StoreDemo.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    private ICategoryRepository _categoryRepository;

    public UpdateProductCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        this.CreateProductCommandRules();

    }

    public void CreateProductCommandRules()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be a valid category id.");
        RuleFor(p => p.StockQuantity)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(p => p.CategoryId)
        .MustAsync(CategoryExists).WithMessage("{PropertyName} does not exist.");

    }

    private async Task<bool> CategoryExists(int categoryId, CancellationToken cancellationToken)
    {
        var catalog = await _categoryRepository.GetByIdAsync(categoryId);

        if (catalog != null)
        {
            return true;
        }

        return false;
    }

}