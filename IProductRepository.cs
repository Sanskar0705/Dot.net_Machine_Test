using System.Collections.Generic;
using Project.Models;

namespace Project.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(int page, int pageSize);
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
