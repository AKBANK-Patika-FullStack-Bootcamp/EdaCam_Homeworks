using DAL.Models;
using Entities;

namespace HomeworkServicesAPI6.Controllers
{
    public class DBOperations
    {
        private ProductContext _context = new ProductContext();
        #region PRODUCT FONKSİYONLARI

        /// <summary>
        /// Veri tabanına yeni bir ürün ekler.
        /// </summary>
        /// <param name="_product"></param>
        /// <returns>Ürün ekleme işleminin başarı durumunu döner</returns>
        public bool AddModel(Product _product)
        {
            try
            {
                _context.Product.Add(_product); //Content içerisine yeni bir ürün eklenir.
                _context.SaveChanges();         // Ekleme işlemi veri tabanında değişikliklere neden olduğu için değişiklikler kaydedilir.
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Veri tabanından olarak verilen id'ye sahip ürünü siler.
        /// <param name="productId"></param>
        /// </summary>
        /// <returns>Ürün silme işleminin başarı durumunu döner/returns>
        public bool DeleteModel(int Id)
        {
            try
            {
                _context.Product.Remove(GetProduct("","",Id)); //GetProduct metodu ile getirilen ilgili id'ye sahip ürünü siler.
                _context.SaveChanges();// Silme işlemi veri tabanında değişikliklere neden olduğu için değişiklikler kaydedilir.
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Veritabanında kayıtlı olan ürünün bilgilerini, parametre olarak verilen product bilgileri ile günceller.
        /// <param name="product"></param>
        /// </summary>
        /// <returns>Güncelleme işleminin başarı durumunu döner/returns>
        public bool UpdateModel(Product _product)
        {
            try
            {
                Product exist = _context.Product.Find(_product.Id); //Ürünün veritabanında bulunma durumu kontrol edilir.
                _context.Entry(exist).CurrentValues.SetValues(_product); //Bulunan ürün bilgileri yenileri ile güncellenir.
                _context.SaveChanges();// Güncelleme işlemi veri tabanında değişikliklere neden olduğu için değişiklikler kaydedilir.
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Veritabanındaki ürün bilgilerini listeler
        /// </summary>
        /// <returns>Ürün listesini döner</returns>
        public List<Product> GetProducts()
        {
            return _context.Product.OrderBy(p=>p.Id).ToList(); //Id bilgisinie göre ürünler sıralanır ve getirilir.
        }
        /// <summary>
        /// Parametre olarak verilen id değerine sahip ürünü getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ürün döner</returns>
        public Product GetProduct(string Name="", string Barcode="",int Id=0)
        {
            Product? product = new Product();
            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Barcode))
            {
                product= _context.Product.FirstOrDefault(p => p.Name == Name && p.Barcode == Barcode);
            }
            else if(Id>0)
            {
                product= _context.Product.FirstOrDefault(p => p.Id == Id);
            }
            return product;
           
        }
        /// <summary>
        /// Veritabanındaki ürün ve marka tablolarını Join ederek oluşan detay bilgilerini getirir.
        /// </summary>
        /// <returns>Ürün detay listesini döner</returns>
        public List<ProductDetail> GetProductDetails()
        {
            return _context.Product.Join(_context.Brand, p => p.BrandId,
                b => b.Id,
                (product, brand) => new ProductDetail { Name = product.Name, Barcode = product.Barcode, BrandName = brand.Name, }).ToList();
        }
        #endregion
        #region TOKEN FONKSİYONLARI
        /// <summary>
        /// Parametre olarak verilen user bilgileri ile siteme kayıt yapılır.
        /// </summary>
        /// <param name="loginUser"></param>
        public void CreateLogin(APIAuthority loginUser)
        {
            try
            {
                _context.APIAuthority.Add(loginUser);
                _context.SaveChanges(); // Kullanıcı kayıt işlemi veri tabanında değişikliklere neden olduğu için değişiklikler kaydedilir.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        /// <summary>
        /// Parametre olarak verilen user bilgileri ile sitemde kullanıcı adı ve parola ile eşleşen kullanıcı olup olmadığı kontrol edilir.
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns>Kullanıcı adı ve parola ile eşleşen kullanıcı bilgisini döner</returns>
        public APIAuthority GetLogin(APIAuthority loginUser)
        {
            if(!string.IsNullOrWhiteSpace(loginUser.Username) && !string.IsNullOrWhiteSpace(loginUser.Password))
            {
                try
                {
                    return _context.APIAuthority.First(u => u.Username == loginUser.Username && u.Password == loginUser.Password); //Username ve Password bilgileri eşleşiyorsa kullanıcı giriş işlemi başarılı olur.
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
            return null;
        }
        #endregion

    }
}
