using MediatorDesignPattern.Dal;
using Microsoft.EntityFrameworkCore;


namespace UrunYonetim.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public void SeedData()
        {
            // Eğer veri yoksa başlangıç verilerini ekle
            if (!Products.Any())
            {
                Products.AddRange(
                    new Product
                    {
                        ProductName = "Laptop",
                        ProductStock = 50,
                        ProductSTockType = "Adet",
                        ProductPrice = 15000.50M,
                        ProductCategory = "Elektronik"
                    },
                    new Product
                    {
                        ProductName = "Mouse",
                        ProductStock = 150,
                        ProductSTockType = "Adet",
                        ProductPrice = 200.99M,
                        ProductCategory = "Bilgisayar Aksesuarı"
                    },
                    new Product
                    {
                        ProductName = "Klavye",
                        ProductStock = 50,
                        ProductSTockType = "Adet",
                        ProductPrice = 350.00M,
                        ProductCategory = "Bilgisayar Aksesuarı"
                    },
                    new Product
                    {
                        ProductName = "Monitör",
                        ProductStock = 20,
                        ProductSTockType = "Adet",
                        ProductPrice = 2500.99M,
                        ProductCategory = "Elektronik"
                    },
                    new Product
                    {
                        ProductName = "Telefon",
                        ProductStock = 100,
                        ProductSTockType = "Adet",
                        ProductPrice = 8500.00M,
                        ProductCategory = "Elektronik"
                    },
                    new Product
                    {
                        ProductName = "Kulaklık",
                        ProductStock = 200,
                        ProductSTockType = "Adet",
                        ProductPrice = 250.25M,
                        ProductCategory = "Ses Sistemleri"
                    },
                    new Product
                    {
                        ProductName = "SSD",
                        ProductStock = 120,
                        ProductSTockType = "Adet",
                        ProductPrice = 1200.00M,
                        ProductCategory = "Depolama"
                    },
                    new Product
                    {
                        ProductName = "Çanta",
                        ProductStock = 70,
                        ProductSTockType = "Adet",
                        ProductPrice = 200.99M,
                        ProductCategory = "Aksesuar"
                    },
                    new Product
                    {
                        ProductName = "Hoparlör",
                        ProductStock = 90,
                        ProductSTockType = "Adet",
                        ProductPrice = 500.00M,
                        ProductCategory = "Ses Sistemleri"
                    },
                    new Product
                    {
                        ProductName = "Webcam",
                        ProductStock = 60,
                        ProductSTockType = "Adet",
                        ProductPrice = 400.00M,
                        ProductCategory = "Bilgisayar Aksesuarı"
                    }
                );

                SaveChanges(); // Değişiklikleri kaydet
            }
        }
    }
}