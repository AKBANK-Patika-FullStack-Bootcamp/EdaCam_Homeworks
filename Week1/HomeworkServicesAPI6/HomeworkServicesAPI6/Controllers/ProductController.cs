using Microsoft.AspNetCore.Mvc;
using HomeworkServicesAPI6.Models;

namespace HomeworkServicesAPI6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Çikolatalı Gofret", Price = 2, Brand = "Ülker", Barcode = "10000", Weight = "20 gr", ExpiryDate = new DateTime(2022,08,08) },
                new Product { Id = 2, Name = "Çubuk Kraker", Price = 2.5, Brand = "Ülker", Barcode = "10001", Weight = "35 gr", ExpiryDate = new DateTime(2022,06,20) },
                new Product { Id = 3, Name = "Ayran", Price = 4, Brand = "Sütaş", Barcode = "10002", Weight = "200 ml", ExpiryDate = new DateTime(2023,08,30) }
            };

        Result result = new Result();

        /// <summary>
        /// Sistemdeki ürün bilgilerini listeler
        /// </summary>
        /// <returns>Ürün listesini döner</returns>
        [HttpGet]
        public List<Product> GetProduct()
        {
            products.OrderBy(x => x.Price).ToList();
            return products;
        }

        /// <summary>
        /// Parametre olarak verilen id değerine sahip ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ürün döner</returns>
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Sisteme yeni ürün ekler.
        /// </summary>
        /// /// <param name="product"></param>
        /// <returns>Result objesini döner/returns>
        [HttpPost]
        public Result SaveProduct(Product product)
        {
            bool productCheck = products.Select(x => x.Id == product.Id || x.Barcode == product.Barcode).FirstOrDefault();
            if (!productCheck)
            {
                products.Add(product);
                result.Status = 1;
                result.Message = "Yeni ürün eklendi.";
                result.Products= products;
            }
            else
            {
                result.Status = 0;
                result.Message = "Bu ürün zaten mevcut.";
                result.Products = products;
            }
            return result;
        }

        /// <summary>
        /// Parametre olarak verilen id'ye sahip ürünü parametre olarak verilen product bilgileri ile günceller.
        /// <param name="productId"></param>
        /// <param name="product"></param>
        /// </summary>
        /// <returns>Güncellenmiş result objesini döner/returns>
        [HttpPut("{productId}")]
        public Result UpdateProduct(int productId,Product product)
        {
            Product? oldProduct = products.Find(x => x.Id == productId);
            if(oldProduct !=null)
            {
                products.Add(product);
                products.Remove(oldProduct);

                result.Status = 1;
                result.Message = "Ürün güncellendi.";
                result.Products = products;
            }
            else
            {
                result.Status = 0;
                result.Message = "Ürün güncellenemedi.";
                result.Products = products;
            }
            return result;
        }

        /// <summary>
        /// Parametre olarak verilen id'ye sahip ürünü siler.
        /// <param name="productId"></param>
        /// </summary>
        /// <returns>Result objesini döner/returns>
        [HttpDelete("{productId}")]
        public Result DeleteProduct(int productId)
        {
            Product? product = products.Find(x => x.Id == productId);
            if (product != null)
            {
                products.Remove(product);
                result.Status = 1;
                result.Message = "Ürün silindi.";
                result.Products = products;
            }
            else
            {
                result.Status = 0;
                result.Message = "Ürün zaten silinmiş.";
                result.Products = products;
            }
            return result;
        }
    }
}