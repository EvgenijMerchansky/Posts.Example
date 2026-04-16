using MediatR;
using Posts.Example.Models.Dtos.Posts;
using Posts.Example.QueryService.Queries;
using Posts.Example.Services.Services;

namespace Posts.Example.QueryService.QueryHandlers;

public class GetPostQueryHandler(IPostService postService) : IRequestHandler<GetPostQuery, PostDto>
{
    public Task<PostDto> Handle(GetPostQuery query, CancellationToken ct = default)
    {
        return postService.Get(query.PostId, ct);
    }
}
