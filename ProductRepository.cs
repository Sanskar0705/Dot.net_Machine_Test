using System.Collections.Generic;
using System.Linq;
using Project.DbContext;
using Project.Models;

namespace Project.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll(int page, int pageSize) =>
            _context.Products.OrderBy(p => p.ProductId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        public Product GetById(int id) => _context.Products.Find(id);

        public void Add(Product product)
        {
            if (!_context.Products.Any(p => p.ProductName == product.ProductName))
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            var existing = _context.Products.Find(product.ProductId);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.CategoryId = product.CategoryId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
