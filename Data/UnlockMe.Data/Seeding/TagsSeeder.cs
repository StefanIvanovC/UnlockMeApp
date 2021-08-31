namespace UnlockMe.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UnlockMe.Data.Models;

    public class TagsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tags.Any())
            {
                return;
            }

            await dbContext.Tags.AddAsync(new Tag()
            {
                Id = 0,
                Name = "+18",
            });

            await dbContext.Tags.AddAsync(new Tag()
            {
                Id = 1,
                Name = "Sexy",
            });

            await dbContext.Tags.AddAsync(new Tag()
            {
                Id = 2,
                Name = "Erotic",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
