using System.Web.Mvc;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index() => View(_repository.GetAll());

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Edit(int id) => View(_repository.GetById(id));

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
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
