using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Api.Data.Configurations;

public class CustomerConfiguration : BaseEntityConfiguration<Entities.Customer>
{
    public override void Configure(EntityTypeBuilder<Entities.Customer> builder)
    {
        builder.Property(x => x.FirstName)
                .IsRequired();

        builder.Property(x => x.LastName)
                .IsRequired();

        builder.Property(x => x.Email)
                .IsRequired();

        builder.Property(x => x.Password)
                .IsRequired();

        base.Configure(builder);
    }
}
