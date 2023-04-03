
global using Resources;
using CommandANDQuery.Games.Commands;
using DAL.Repository;
using Models;

namespace CommandANDQuery.Games.Handlers;

public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public DeleteGameHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {

        string message = string.Format(LangResource.GameDeleteQuestion, request?.Game?.Name);

        bool res = await request.ShowMessage.Invoke(new MessageInfo(MessageType.Question, message));

        if (res)
        {
            bool gameId = await RepositoryManager.GameRepository.DeleteGame(request.Game.Id);

            request.ShowMessage(new MessageInfo(MessageType.Sucsses, string.Format(LangResource.GameDeleted, request?.Game?.Name)));

            return gameId;
        }
        else
        {
            return false;
        }
    }
}
public class DeleteGameMemberHandler : IRequestHandler<DeleteGameMemberCommand, bool>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public DeleteGameMemberHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<bool> Handle(DeleteGameMemberCommand request, CancellationToken cancellationToken)
    {

        string message = string.Format(LangResource.GameMemberDeleteQuestion, request?.GameMember?.Name);

        bool res = await request.ShowMessage.Invoke(new MessageInfo(MessageType.Question, message));

        if (res)
        {
            bool gameMemberId = await RepositoryManager.GameRepository.DeleteGameMember(request.GameMember.Id);

            request.ShowMessage(new MessageInfo(MessageType.Sucsses, string.Format(LangResource.GameMemberDeleted, request?.GameMember?.Name)));

            return gameMemberId;
        }
        else
        {
            return false;
        }
    }
}

public class ChangeWinCountGameMemberHandler : IRequestHandler<ChangeWinCountGameMemberCommand, int>
{
    public IRepositoryManager RepositoryManager { get; set; }

    public ChangeWinCountGameMemberHandler(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
    }

    public async Task<int> Handle(ChangeWinCountGameMemberCommand request, CancellationToken cancellationToken)
    {

        string message = string.Format(LangResource.GameMemberDeleteQuestion, request?.GameMember?.Name);

        int gameMemberId = await RepositoryManager.GameRepository.ChangeWinCountGameMember(request.GameMember.Id, request.Count);

        request.ShowMessage(new MessageInfo(MessageType.Sucsses, string.Format(LangResource.GameMemberChangeWinCount, request?.GameMember?.Name)));

        return gameMemberId;

    }
}
