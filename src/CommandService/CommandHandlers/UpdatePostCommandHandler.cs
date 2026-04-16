using MediatR;
using Posts.Example.CommandService.Commands;
using Posts.Example.Services.Services;

namespace Posts.Example.CommandService.CommandHandlers;

public class UpdatePostCommandHandler(IPostService postService) : IRequestHandler<UpdatePostCommand>
{
    public async Task Handle(UpdatePostCommand command, CancellationToken ct = default)
    {
        await postService.Update(command.Post, ct);
    }
}
