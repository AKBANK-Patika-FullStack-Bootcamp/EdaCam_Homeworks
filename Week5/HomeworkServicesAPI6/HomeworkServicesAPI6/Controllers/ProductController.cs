using DAL.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeworkServicesAPI6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        Result result = new Result();
        ProductContext productOperation = new ProductContext();
        DBOperations dBOperations=new DBOperations();

        /// <summary>
        /// Sistemdeki ürün bilgilerini listeler
        /// </summary>
        /// <returns>Ürün listesini döner</returns>
        [Authorize] //Yalnızca Token'a sahip kullnıcılar bu istekte bulunabilir.
        [HttpGet]
        public List<Product> GetProduct()
        {
            return dBOperations.GetProducts();
        }

        /// <summary>
        /// Sistemdeki ürün detay bilgilerini listeler
        /// </summary>
        /// <returns>Ürün detay listesini döner</returns>
        [HttpGet("Detail")]
        public List<ProductDetail> GetProductDetail()
        {
            return dBOperations.GetProductDetails();
        }

        /// <summary>
        /// Parametre olarak verilen id değerine sahip ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ürün döner</returns>
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return  dBOperations.GetProduct("","",id);
        }

        /// <summary>
        /// Sisteme yeni ürün ekler.
        /// </summary>
        /// /// <param name="product"></param>
        /// <returns>Result objesini döner/returns>
        [HttpPost]
        public Result SaveProduct(Product product)
        {
            if(dBOperations.GetProduct(product.Name, product.Barcode)== null)
            {
                if (dBOperations.AddModel(product))
                {
                    result.Status = 1;
                    result.Message = "Yeni ürün eklendi.";
                    result.Products = GetProduct();
                }
                else
                {
                    result.Status = 0;
                    result.Message = "Hata! ürün eklenemedi.";
                    result.Products = GetProduct();
                }
            }
            else
            {
                result.Status = 0;
                result.Message = "Bu ürün zaten mevcut.";
                result.Products = GetProduct();
            }
            return result;
        }

        /// <summary>
        /// Parametre olarak verilen id'ye sahip ürünü parametre olarak verilen product bilgileri ile günceller.
        /// <param name="product"></param>
        /// </summary>
        /// <returns>Güncellenmiş result objesini döner/returns>
        [HttpPut]
        public Result UpdateProduct(Product product)
        {
            Product? oldProduct = dBOperations.GetProduct("","", product.Id);
            if(oldProduct !=null)
            {
                if(dBOperations.UpdateModel(product))
                {
                    result.Status = 1;
                    result.Message = "Ürün güncellendi.";
                    result.Products = GetProduct();
                }
                else
                {
                    result.Status = 0;
                    result.Message = "Hata! Ürün güncellenemedi.";
                    result.Products = GetProduct();
                }
            }
            else
            {
                result.Status = 0;
                result.Message = "Bu ürün mevcut değil.";
                result.Products = GetProduct();
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
          
            if (dBOperations.DeleteModel(productId))
            {

                result.Status = 1;
                result.Message = "Ürün silindi.";
                result.Products = GetProduct();
            }
            else
            {
                result.Status = 0;
                result.Message = "Ürün zaten silinmiş.";
                result.Products = GetProduct();
            }
            return result;
        }


        /// <summary>
        /// Sistemdeki ürün bilgilerini sayfalanmış şekilde listeler.
        /// </summary>
        /// <returns>Ürün listesini sayfalanmış yapıda döner</returns>
        [Authorize]
        [HttpGet("ProductPaging")]
        public IActionResult GetProductPaging([FromQuery] PagingParameters pagingParameters )
        {
            var pageableData=dBOperations.GetProducts() //Veri tabanındaki ürünlerin listesi
                .OrderBy(p=>p.Name) //Ürünleri isimlerine göre sıralar
                .Skip((pagingParameters.PageNumber-1)*pagingParameters.PageSize) //Yeni sayfadaki verilerin listedeki hangi indexdeki veriden itibaren devam edeceğini belirtir.
                .Take(pagingParameters.PageSize) //Sayfada listelenecek veri miktarını belirtir.
                .ToList();

            return Ok(pageableData);
          
        }
    }
}