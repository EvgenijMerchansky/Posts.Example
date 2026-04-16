using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Posts.Example.DBLayer.Models;
using Posts.Example.DBLayer.Repositories.Interfaces;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.Services.Services;

public class PostService(IMapper mapper, IPostRepository postRepository) : IPostService
{
    public async Task<IEnumerable<PostDto>> GetAll(CancellationToken ct)
    {
        var posts = await postRepository.GetAll(ct);
        return mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public async Task<PostDto> Get(int id, CancellationToken ct)
    {
        var post = await postRepository.Get(id, ct);
        return mapper.Map<PostDto>(post);
    }

    public async Task Create(CreatePostDto createPostDto, CancellationToken ct)
    {
        await postRepository.Create(mapper.Map<Post>(createPostDto), ct);
        await postRepository.CommitAsync(ct);
    }

    public async Task Update(UpdatePostDto updatePostDto, CancellationToken ct)
    {
        await postRepository.Update(updatePostDto.Id, mapper.Map<Post>(updatePostDto), ct);
        await postRepository.CommitAsync(ct);
    }

    public async Task Delete(int id, CancellationToken ct)
    {
        await postRepository.Delete(id, ct);
        await postRepository.CommitAsync(ct);
    }
}

public interface IPostService
{
    Task<IEnumerable<PostDto>> GetAll(CancellationToken ct = default);
    Task<PostDto> Get(int id, CancellationToken ct = default);
    Task Create(CreatePostDto createPostDto, CancellationToken ct = default);
    Task Update(UpdatePostDto updatePostDto, CancellationToken ct = default);
    Task Delete(int id, CancellationToken ct = default);
}
