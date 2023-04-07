using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record AddTranCActionCommand(int PersonId, decimal Amount,TranCActionType Type , int remainingDay) : IRequest<CustomResponse>;
