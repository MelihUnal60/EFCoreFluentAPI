using Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCorePersistLayer
{
    public class FluentAPIDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = FluentAPIDb;user id=sa;Password=123456!a;TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //FluentAPI
        {
            base.OnModelCreating(modelBuilder);

            #region Product Configurations
            modelBuilder.Entity<Product>().Ignore(p => p.IncludeTax);  //Dbye tabloları oluştururken product tablosuna includetax alanı oluşturma
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(9,2)").IsRequired(); //product tablosu price alanı decimal(9,2) oluşsun.
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(128).IsRequired(); //product name alanı zorunlu ve max 128 karakter
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).IsRequired(false); //product tablosu categoryid alanı null olabilir dedik
            modelBuilder.Entity<Product>().Property(p => p.TAX).HasColumnType("decimal(9,2)");

            modelBuilder.Entity<Product>()
                .HasOne<Category>(p => p.Category)//bir kategoriden birden çok ürün olabilir ve her ürünün categoryid foreign keyi
                .WithMany(c => c.Products)//Bire çok ilişki kurduk
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull); //product categoryid silinirse null olarak ayarla dedik 
            #endregion

            #region One To One relations
            modelBuilder.Entity<Customer>() //customer ile customer address bire bir ilişkide
                    .HasOne(c => c.Address)
                    .WithOne(ca => ca.Customer)
                    .HasForeignKey<CustomerAddress>(ad => ad.AddressOfCustomerId);

            #endregion

            #region Many To Many relations
            modelBuilder.Entity<Post>()
                    .HasMany(p => p.Tags)  //many to many
                    .WithMany(t => t.Posts); 
            #endregion


        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerAddress> CustomersAddresses { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}