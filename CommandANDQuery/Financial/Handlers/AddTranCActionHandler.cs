using CommandANDQuery.Financial.Commands;
using DAL.Repository;
using Share;
using Share.Messages;

namespace CommandANDQuery.Financial.Handlers;

public class AddTranCActionHandler : IRequestHandler<AddTranCActionCommand, CustomResponse>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public AddTranCActionHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<CustomResponse> Handle(AddTranCActionCommand request, CancellationToken cancellationToken)
    {

        DateTime backDate = DateTime.Now.AddDays(request.remainingDay);

        await RepositoryManager.FinancialRepository.AddAction(request.PersonId, backDate, request.Amount, request.Type);

        CustomResponse response = new CustomResponse().Success().SetMessage(new SuccessMessage());

        return response;
    }

}
