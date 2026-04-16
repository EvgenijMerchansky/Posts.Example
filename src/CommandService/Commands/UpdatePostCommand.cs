using MediatR;
using Posts.Example.Models.Dtos.Posts;

namespace Posts.Example.CommandService.Commands
{
    public class UpdatePostCommand(UpdatePostDto updatePostDto) : IRequest
    {
        public UpdatePostDto Post { get; set; } = updatePostDto;
    }
}
