namespace Application.CatalogItems.Commands.UpdateCatalogItem
{
    public class UpdateCatalogItemCommandValidator:AbstractValidator<UpdateCatalogItemCommand>
    {
        public UpdateCatalogItemCommandValidator()
        {
            RuleFor(v=>v.Name).NotEmpty().MaximumLength(50);

            RuleFor(v=>v.Description).NotEmpty().MaximumLength(500);

            RuleFor(v=>v.Price).NotEmpty().GreaterThan(0);

            RuleFor(v=>v.CategoryId).NotEmpty().GreaterThan(-1);

            RuleFor(v=>v.CatalogBrandId).NotEmpty().GreaterThan(-1);
        }
    }
}
