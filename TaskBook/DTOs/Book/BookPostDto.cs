using FluentValidation;

namespace TaskBook.DTOs.Book
{
    public class BookPostDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Page { get; set; }
        public int CategoryId { get; set; }
    }
    public class BookPostValidation : AbstractValidator<BookPostDto>
    {
        public BookPostValidation()
        {
            RuleFor(b=>b.Name).NotEmpty().WithMessage("Please fill the field").MaximumLength(30).WithMessage("Maximum length must be 30 character");
            RuleFor(b => b.Author).NotEmpty().WithMessage("Please fill the field").MaximumLength(20).WithMessage("Maximum length must be 20 character");
            RuleFor(b => b.Price).NotEmpty().WithMessage("Please fill the field").GreaterThanOrEqualTo((int)1);
            RuleFor(b=>b.Page).NotEmpty().WithMessage("Please fill the field").GreaterThanOrEqualTo((int)20);
        }
    }
}
