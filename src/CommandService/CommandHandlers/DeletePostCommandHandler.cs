using MediatR;
using Posts.Example.CommandService.Commands;
using Posts.Example.Services.Services;

namespace Posts.Example.CommandService.CommandHandlers;

public class DeletePostCommandHandler(IPostService postService) : IRequestHandler<DeletePostCommand>
{
    public async Task Handle(DeletePostCommand command, CancellationToken ct = default)
    {
        await postService.Delete(command.PostId, ct);
    }
}
