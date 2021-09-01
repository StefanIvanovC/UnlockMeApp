namespace UnlockMe.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UnlockMe.Data.Models;

    public class PostsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Posts.Any())
            {
                return;
            }

            await dbContext.Posts.AddAsync(new Post
            {
                TagId = 2,
                Title = "Seeder Name",
                Description = "Seerder Description",
            });

            await dbContext.Posts.AddAsync(new Post
            {
                TagId = 3,
                Title = "Seeder Name",
                Description = "Seerder Description",
            });

            await dbContext.Posts.AddAsync(new Post
            {
                TagId = 4,
                Title = "Seeder Name",
                Description = "Seerder Description",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
