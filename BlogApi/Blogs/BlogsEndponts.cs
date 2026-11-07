using BlogLib.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogLib.Blogs;

public static class BlogsEndpoints
{
    public static void RegisterBLogsEndpoints(this WebApplication app)
    {
        _ = app.MapGet("/blogs", static async (BlogContext db) =>
                    await db.Blogs.ToListAsync());

        app.MapGet("/blogs/complete", async (BlogContext db) =>
            await db.Blogs.Where(b => b.IsComplete).ToListAsync());

        app.MapGet("/todoitems/{id}", async (int id, BlogContext db) =>
            await db.Blogs.FindAsync(id)
                is Blog blog
                    ? Results.Ok(blog)
                    : Results.NotFound());
    }
}