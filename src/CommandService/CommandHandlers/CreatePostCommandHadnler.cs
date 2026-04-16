using MediatR;
using Posts.Example.CommandService.Commands;
using Posts.Example.Services.Services;

namespace Posts.Example.CommandService.CommandHandlers;

public class CreatePostCommandHadnler(IPostService postService) : IRequestHandler<CreatePostCommand>
{
    public async Task Handle(CreatePostCommand command, CancellationToken ct = default)
    {
        await postService.Create(command.Post, ct);
    }
}
