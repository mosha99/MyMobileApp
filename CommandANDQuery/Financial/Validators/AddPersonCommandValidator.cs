using CommandANDQuery.Financial.Commands;
using FluentValidation;

namespace CommandANDQuery.Financial.Validators;

public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
{
    public AddPersonCommandValidator()
    {
        RuleFor(x => x.Name).Configure(x => x.PropertyName = LangResource.Name)
          .NotEmpty().WithMessage(LangResource.RequierdName);
    }
}