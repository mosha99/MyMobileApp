using CommandANDQuery.Financial.Commands;
using DAL.Repository;
using Models;
using Share;

namespace CommandANDQuery.Financial.Handlers;

public class GetPersonHandler : IRequestHandler<GetPersonCommand, CustomResponse<Person>>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetPersonHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }
    public async Task<CustomResponse<Person>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
    {

        Person person = await RepositoryManager.PersonRepository.GetPerson(request.id);

        CustomResponse<Person> response = new CustomResponse<Person>().SetResult(person);

        return response;
    }

}
