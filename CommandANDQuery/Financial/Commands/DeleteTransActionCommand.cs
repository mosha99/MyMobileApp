using Share;

namespace CommandANDQuery.Financial.Commands;

public sealed record DeleteTranCActionCommand(int id): IRequest<CustomResponse>;
