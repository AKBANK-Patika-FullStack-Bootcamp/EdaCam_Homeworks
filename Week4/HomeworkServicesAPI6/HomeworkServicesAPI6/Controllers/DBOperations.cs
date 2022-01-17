using DAL.Models;
using Entities;

namespace HomeworkServicesAPI6.Controllers
{
    public class DBOperations
    {
        private ProductContext _context = new ProductContext();
        public bool AddModel(Product _product)
        {
            try
            {
                _context.Product.Add(_product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteModel(int Id)
        {
            try
            {
                _context.Product.Remove(GetProduct("","",Id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateModel(Product _product)
        {
            try
            {
                Product exist = _context.Product.Find(_product.Id);
                _context.Entry(exist).CurrentValues.SetValues(_product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Product> GetProducts()
        {
            return _context.Product.OrderBy(p=>p.Id).ToList();
        }
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
        public List<ProductDetail> GetProductDetails()
        {
            return _context.Product.Join(_context.Brand, p => p.BrandId,
                b => b.Id,
                (product, brand) => new ProductDetail { Name = product.Name, Barcode = product.Barcode, BrandName = brand.Name, }).ToList();
        }

    }
}
