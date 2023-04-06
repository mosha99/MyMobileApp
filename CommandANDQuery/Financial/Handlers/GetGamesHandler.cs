using CommandANDQuery.Financial.Commands;
using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;
using Share;
using Share.Messages;

namespace CommandANDQuery.Financial.Handlers;

public class GetPersonHandler : IRequestHandler<GetPersonCommand, CustomResponse<List<Person>>>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetPersonHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<CustomResponse<List<Person>>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
    {

        List<Person> person = await RepositoryManager.PersonRepository.GetPeople();

        CustomResponse<List<Person>> response = new CustomResponse<List<Person>>().SetResult(person);

        return response;
    }
}
public class AddPersonHandler : IRequestHandler<AddPersonCommand, CustomResponse>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public AddPersonHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<CustomResponse> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {

        await RepositoryManager.PersonRepository.AddPerson(request.Name);

        CustomResponse response = new CustomResponse().Success().SetMessage(new SuccessMessage());

        return response;
    }

}
