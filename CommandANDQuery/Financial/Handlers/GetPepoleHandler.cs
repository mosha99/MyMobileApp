using CommandANDQuery.Financial.Commands;
using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;
using Share;
using Share.Messages;

namespace CommandANDQuery.Financial.Handlers;

public class DeletePepoleHandler : IRequestHandler<DeletePersonCommand, CustomResponse>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public DeletePepoleHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }
    public async Task<CustomResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {     
        var person = await RepositoryManager.PersonRepository.GetPerson(request.id);

        bool result = await new DeletePersonQuestionMessage(person.Name).Show();

        if(!result) return new CustomResponse().Success();

        await RepositoryManager.PersonRepository.DeletePerson(request.id);

        return  new CustomResponse().SetMessage(new SuccessMessage());
    }

}
public class GetPepoleHandler : IRequestHandler<GetPepoleCommand, CustomResponse<List<Person>>>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetPepoleHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }
    public async Task<CustomResponse<List<Person>>> Handle(GetPepoleCommand request, CancellationToken cancellationToken)
    {

        List<Person> person = await RepositoryManager.PersonRepository.GetPeople();

        foreach (var x in person)
        {
            var actions = await RepositoryManager.FinancialRepository.GetActions(x.Id);
            x.Amount = actions.Where(a => a.Payed == (int)TranCActionState.NotPayed).Sum(a => a.Amount);
        }



        CustomResponse<List<Person>> response = new CustomResponse<List<Person>>().SetResult(person);

        return response;
    }

}
