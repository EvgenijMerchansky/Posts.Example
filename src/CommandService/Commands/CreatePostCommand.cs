using MediatR;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.CommandService.Commands;

public class CreatePostCommand(CreatePostDto createPostDto) : IRequest
{
    public CreatePostDto Post { get; set; } = createPostDto;
}
