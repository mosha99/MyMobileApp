using CommandANDQuery.Financial.Commands;
using DAL.Repository;
using FluentValidation;
using Models;

namespace CommandANDQuery.Financial.Validators;

public class EditPersonCommandValidator : AbstractValidator<EditPersonCommand>
{
    IRepositoryManager RepositoryManager { get; set; }
    public EditPersonCommandValidator(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;

        RuleFor(x => x.Name).Configure(x => x.PropertyName = LangResource.Name)
          .NotEmpty().WithMessage(x => LangResource.RequierdName)
          .Length(3, 50).WithMessage(x => string.Format(LangResource.LenthError, LangResource.Name, 3, 5))
          .MustAsync(cheackName).WithMessage(x => string.Format(LangResource.NameUniqError, x.Name));

    }

    public async Task<bool> cheackName(EditPersonCommand command, string Name, CancellationToken cancellation)
    {
        bool exist = await RepositoryManager.Exist<Person>(x => x.Name == Name && x.Id != command.id);
        return !exist;
    }
}


