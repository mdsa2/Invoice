
 
using Invoice.Domain.Entites;
using Microsoft.EntityFrameworkCore;
 

 
namespace Invoice.Infstracture.DataInvoice;

public class DataDbContext : DbContext
{


    public DbSet<Invoices> invoices { get; set; }
    public DbSet<InvoiceItem> invoiceItems { get; set; }
    public DbSet<ProductDiscounts> ProductDiscounts { get; set; }
    public DbSet<Products> Products { get; set; }
    //note this is for single thread if i will need 
    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries<FullAuditedEntity<int>>()
            .Where(e => e.State == EntityState.Modified);
         
        foreach (var entry in entries)
        {
            entry.Entity.Updated = DateTime.UtcNow;
        }

        return base.SaveChanges();
    }
    //note this is for multi thread it have references for all repositry
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<FullAuditedEntity<int>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.Updated = DateTime.UtcNow;
            }
            if (entry.State == EntityState.Deleted)
            {
                entry.Entity.IsDeleted = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.Property(e => e.DiscountValue)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount)
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(ii => ii.Product)
                .WithMany(p => p.InvoiceItems)
                .HasForeignKey(ii => ii.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ii => ii.Invoices)
                .WithMany(i => i.InvoiceItems)
                .HasForeignKey(ii => ii.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(ii => ii.ProductDiscounts)
                .WithMany(pd => pd.InvoiceItems)
                .HasForeignKey(ii => ii.ProductDiscountsId)
                .OnDelete(DeleteBehavior.Restrict); // Configure according to your needs
        });

        modelBuilder.Entity<ProductDiscounts>(entity =>
        {
            entity.Property(e => e.DiscountValue)
                .HasColumnType("decimal(18, 2)");

            // Configure other properties as needed
        });





    }

}
