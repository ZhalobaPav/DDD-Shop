namespace Application.CatalogItems.Commands.CreateCatalogItem
{
    public class CreateCatalogItemValidator:AbstractValidator<CreateCatalogItemCommand>
    {
        public CreateCatalogItemValidator()
        {
            RuleFor(v=>v.Name)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(v => v.Name)
                .MaximumLength(600)
                .NotEmpty();

            RuleFor(v => v.Price)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(v => v.CatalogBrandId).GreaterThan(-1);
            RuleFor(v => v.CategoryId).GreaterThan(-1);
        }
    }
}
