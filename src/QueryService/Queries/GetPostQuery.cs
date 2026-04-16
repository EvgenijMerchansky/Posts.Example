using MediatR;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.QueryService.Queries;

public class GetPostQuery(int postId) : IRequest<PostDto>
{
    public int PostId { get; set; } = postId;
}
