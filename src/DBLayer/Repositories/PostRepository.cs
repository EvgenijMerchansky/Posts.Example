namespace Posts.Example.DBLayer.Repositories;

using Posts.Example.DBLayer.EntityFramework;
using Posts.Example.DBLayer.Models;
using Posts.Example.DBLayer.Repositories.Interfaces;

public class PostRepository(PostsDbContext context) : BaseRepository<int, Post, PostsDbContext>(context), IPostRepository { }
