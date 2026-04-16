using MediatR;
using Posts.Example.Models.Dtos.Posts;
using Posts.Example.QueryService.Queries;
using Posts.Example.Services.Services;

namespace Posts.Example.QueryService.QueryHandlers;

public class GetPostsQueryHadnler(IPostService postService) : IRequestHandler<GetPostsQuery, IEnumerable<PostDto>>
{
    public Task<IEnumerable<PostDto>> Handle(GetPostsQuery query, CancellationToken ct = default)
    {
        return postService.GetAll(ct);
    }
}
