using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record PayedTranCActionCommand(int Id) : IRequest<CustomResponse>;
