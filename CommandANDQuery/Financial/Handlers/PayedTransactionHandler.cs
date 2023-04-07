using CommandANDQuery.Financial.Commands;
using DAL.Repository;
using Share;
using Share.Messages;

namespace CommandANDQuery.Financial.Handlers;

public class PayedTranCActionHandler : IRequestHandler<PayedTranCActionCommand, CustomResponse>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public PayedTranCActionHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<CustomResponse> Handle(PayedTranCActionCommand request, CancellationToken cancellationToken)
    {
        var action = await RepositoryManager.FinancialRepository.GetAction(request.Id);

        var person = await RepositoryManager.PersonRepository.GetPerson(action.PersonId);

        bool result = await new PayedTranCActionQuestionMessage(person.Name, action.Amount).Show();

        if (!result) return new CustomResponse().Success();

        await RepositoryManager.FinancialRepository.PayedAction(request.Id);

        return new CustomResponse().Success().SetMessage(new SuccessMessage());
    }

}