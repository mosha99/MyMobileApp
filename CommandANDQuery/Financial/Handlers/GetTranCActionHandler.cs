using CommandANDQuery.Financial.Commands;
using DAL.Repository;
using Models;
using Share;

namespace CommandANDQuery.Financial.Handlers;

public class GetTranCActionHandler : IRequestHandler<GetTranCActionCommand, CustomResponse<List<TranCAction>>>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public GetTranCActionHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<CustomResponse<List<TranCAction>>> Handle(GetTranCActionCommand request, CancellationToken cancellationToken)
    {

        List<TranCAction> Data = await RepositoryManager.FinancialRepository.GetActions(request.PersonId);

        CustomResponse < List < TranCAction >> response = new CustomResponse<List<TranCAction>>().SetResult(Data);

        return response;
    }

}