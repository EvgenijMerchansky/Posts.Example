using MediatR;
using Microsoft.AspNetCore.Mvc;
using Posts.Example.CommandService.Commands;
using Posts.Example.Models.Dtos.Posts;
using Posts.Example.QueryService.Queries;

namespace Posts.Example.CommandApi.Site.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController(ILogger<PostsController> logger, IServiceProvider serviceProvider, IMediator mediator) : BaseController(logger, serviceProvider)
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var posts = await mediator.Send(new GetPostsQuery());
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var post = await mediator.Send(new GetPostQuery(id));
        if (post is not null) return Ok(post);

        logger.LogInformation("Method {caller}; post with id {id} - was not found.", nameof(Get), id);
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostDto createPostDto)
    {
        var errors = ValidateSingle(createPostDto);
        if (errors.Count > 0)
        {
            logger.LogInformation("Method {caller}; validation errors: {errors}.", nameof(Create), string.Join(",", errors));
            return BadRequest(errors);
        }

        await mediator.Send(new CreatePostCommand(createPostDto));
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdatePostDto updatePostDto)
    {
        var errors = ValidateSingle(updatePostDto);
        if (errors.Count > 0)
        {
            logger.LogInformation("Method {caller}; validation errors: {errors}.", nameof(Put), string.Join(",", errors));
            return BadRequest(errors);
        }

        await mediator.Send(new UpdatePostCommand(updatePostDto));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeletePostCommand(id));
        return Ok();
    }
}
