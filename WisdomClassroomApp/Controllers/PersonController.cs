using System.Data.Entity.Validation;
using System.Web.Mvc;
using WisdomClassroomApp.Models.Viewmodels;
using WisdomClassroomApp.Services;

namespace WisdomClassroomApp.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            var ps = new PersonServices();

            return View(ps.GetAll());
        }

        [HttpPost]
        public ActionResult Index(string criteria)
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var ps = new PersonServices();

            return View(ps.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id, Birthday, Name, LastName, Email, Role")] PersonViewModel model)
        {
            try
            {
                var ps = new PersonServices();

                ps.Create(model);

                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                return View(model);
            }
        }

        public ActionResult Edit(int id)
        {
            var ps = new PersonServices();

            return View(ps.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Birthday, Name, LastName, Email, Role")] PersonViewModel model)
        {
            try
            {
                var ps = new PersonServices();

                ps.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            var ps = new PersonServices();

            return View(ps.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Id, Birthday, Name, LastName, Email, Role")] PersonViewModel model)
        {
            try
            {
                var ps = new PersonServices();

                ps.Delete(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

/* CODIGO PARA PODER OBTENER ERRORES DE ENTIDADES Y BD
 * 
 * foreach (var item in e.EntityValidationErrors)
{
    foreach (var error in item.ValidationErrors)
    {
        var property = error.PropertyName; 
        var myError  = error.ErrorMessage;
    }
}*/
