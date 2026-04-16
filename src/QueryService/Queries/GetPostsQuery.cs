using MediatR;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.QueryService.Queries;

public class GetPostsQuery : IRequest<IEnumerable<PostDto>>
{
}
