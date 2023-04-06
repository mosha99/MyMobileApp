using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record AddTransActionCommand(int PersonId, decimal Amount,TransActionType Type , int remainingDay) : IRequest<CustomResponse>;
