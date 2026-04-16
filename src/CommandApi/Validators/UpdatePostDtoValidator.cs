using FluentValidation;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.CommandApi.Site.Validators;

public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDto>
{
    public UpdatePostDtoValidator()
    {
        RuleFor(model => model.Id)
            .GreaterThan(0).WithMessage("Post id should be greater than 0.");

        RuleFor(model => model.UserId)
            .GreaterThan(0).WithMessage("UserId should be greater than 0.");

        RuleFor(model => model.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(500).WithMessage("Title must not exceed 500 characters.");

        RuleFor(model => model.Body)
            .NotEmpty().WithMessage("Body is required.")
            .MaximumLength(8000).WithMessage("Body must not exceed 8000 characters.");
    }
}
