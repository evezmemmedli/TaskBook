using FluentValidation;

namespace TaskBook.DTOs.Category
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }
    public class CategoryPostValidation : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostValidation()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage("Please fill the field").MaximumLength(30).WithMessage("Maximum length must be 30 character");
        }
    }
}
