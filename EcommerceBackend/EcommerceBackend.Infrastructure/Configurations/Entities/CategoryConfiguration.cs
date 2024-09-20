using EcommerceBackend.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceBackend.Infrastructure.Configurations.Entities
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category()
                {
                    Id = 1,
                    Name = "All"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Books"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Deals"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Amazon"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Fashion"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Computers"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Home"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Mobiles"
                }
            );
        }
    }

}
