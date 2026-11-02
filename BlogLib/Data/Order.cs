
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

public class Order
{
    public int Id { get; set; }
    public int OrderId { get; set; } // Alternate key as target of the BlogHeader.BlogId foreign key
}

// To generate alternate or custom identifiers for your entities in EF Core instead of relying on standard database-generated identity columns, 
// you can implement a custom ValueGenerator<T>. 
// This approach generates IDs on the client side right before the entity is tracked and saved to the database.

public class OrderIdGenerator : ValueGenerator<string>
{
    // Return false if you want EF to generate a new value every time an entity is added
    public override bool GeneratesTemporaryValues => false;

    public override string Next(EntityEntry entry)
    {
        string timestamp = DateTime.UtcNow.ToString("yyyyMMdd");
        string uniqueSuffix = Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper();
        
        return $"ORD-{timestamp}-{uniqueSuffix}";
    }
}


// 2. Register the Generator in the DbContext

// Bind your custom generator to your entity property in your OnModelCreating method:


// protected override void OnModelCreating(ModelBuilder modelBuilder)
// {
//     modelBuilder.Entity<Order>(entity =>
//     {
//         entity.Property(e => e.Id)
//             .HasValueGenerator<OrderIdGenerator>()
//             .ValueGeneratedOnAdd(); // Informs EF that the value is populated when added
//     });
// }