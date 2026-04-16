using MediatR;

namespace Posts.Example.CommandService.Commands;

public class DeletePostCommand(int postId) : IRequest
{
    public int PostId { get; set; } = postId;
}
