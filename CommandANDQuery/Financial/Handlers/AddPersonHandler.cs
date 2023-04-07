using CommandANDQuery.Financial.Commands;
using DAL.Repository;
using Share;
using Share.Messages;
using System.Collections.Generic;

namespace CommandANDQuery.Financial.Handlers;

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
