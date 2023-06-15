using Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCorePersistLayer
{
    public class FluentAPIDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = FluentAPIDb;Integrated Security = true;TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //FluentAPI
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Ignore(p => p.IncludeTax);  //Dbye tabloları oluştururken product tablosuna includetax alanı oluşturma
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(9,2)").IsRequired(); //product tablosu price alanı decimal(9,2) oluşsun.
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(128).IsRequired(); //product name alanı zorunlu ve max 128 karakter

            modelBuilder.Entity<Product>()
                .HasOne<Category>(p => p.Category)//bir kategoriden birden çok ürün olabilir ve her ürünün categoryid foreign keyi
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);  //Bire çok ilişki kurduk
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}