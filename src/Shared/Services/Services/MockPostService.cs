using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.Services.Services;

public class MockPostService : IMockPostService
{
    private readonly PostDto _mockedPost = new()
    {
        UserId = 1,
        Id = 1,
        Title = "test title",
        Body = "test body"
    };

    public async Task<IEnumerable<PostDto>> GetAll(CancellationToken ct)
    {
        return new List<PostDto> { _mockedPost };
    }

    public async Task<PostDto> Get(int id, CancellationToken ct)
    {
        return _mockedPost;
    }

    public async Task Create(PostDto postDto, CancellationToken ct)
    {
        return;
    }

    public async Task Update(int id, PostDto postDto, CancellationToken ct)
    {
        return;
    }

    public async Task Delete(int id, CancellationToken ct)
    {
        return;
    }
}

public interface IMockPostService
{
    Task<IEnumerable<PostDto>> GetAll(CancellationToken ct = default);
    Task<PostDto> Get(int id, CancellationToken ct = default);
    Task Create(PostDto postDto, CancellationToken ct = default);
    Task Update(int id, PostDto postDto, CancellationToken ct = default);
    Task Delete(int id, CancellationToken ct = default);
}
