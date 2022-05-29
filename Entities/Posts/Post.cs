using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public User CreatedBy { get; set; }
        public int CreatedByID { get; set; }

    }
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).IsRequired();
            builder.HasOne(p=>p.Category).WithMany(p=>p.Posts).HasForeignKey(p=>p.CategoryID);  
            builder.HasOne(p=>p.CreatedBy).WithMany(p=>p.Posts).HasForeignKey(p=>p.CreatedByID);
        }
    }
}
