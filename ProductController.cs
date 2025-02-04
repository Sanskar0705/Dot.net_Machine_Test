using System.Web.Mvc;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var products = _repository.GetAll(page, pageSize);
            return View(products);
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id) => View(_repository.GetById(id));

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id) => View(_repository.GetById(id));

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
