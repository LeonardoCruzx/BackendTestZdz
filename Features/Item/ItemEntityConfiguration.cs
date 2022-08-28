using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTest.Features.Item;

public class ItemEntityConfiguration : IEntityTypeConfiguration<ItemEntity>
{
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.ToTable("Items");
        
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(i => i.ItemCategory)
            .WithMany(ic => ic.Items)
            .HasForeignKey(i => i.ItemCategoryId);
    }
}
