using ApplicationDevelopment.WebMVC.Commons;
using ApplicationDevelopment.WebMVC.Models;
using FluentValidation;

namespace ApplicationDevelopment.WebMVC.Validators
{
    public class JobTypeValidator : AbstractValidator<JobTypeViewModel>
    {
        public JobTypeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(MaxLengths.Name)
                .WithMessage("Vượt quá " + MaxLengths.Name + " ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(MaxLengths.Description)
                .WithMessage("Vượt quá " + MaxLengths.Description + " ký tự");
        }
    }
}
