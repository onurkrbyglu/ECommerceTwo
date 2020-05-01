using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        GurhanDbEntities db = new GurhanDbEntities();

        // GET: Admin/Category
        public ActionResult List()
        {

            List<Customer> cat = db.Customers.ToList();
            return View(cat);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Customer model)
        {
            model.CreatedOnUtc = DateTime.Now;
            db.Customers.Add(model);
            db.SaveChanges();

            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {
            Customer cus = db.Customers.SingleOrDefault(x => x.Id == id);
            return View(cus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer model)
        {
            Customer customer = db.Customers.SingleOrDefault(x => x.Id == model.Id);
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Password = model.Password;
            customer.Email = model.Email;
            customer.Active = model.Active;
            db.SaveChanges();


            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            Customer deleted = db.Customers.SingleOrDefault(x => x.Id == id);
            db.Customers.Remove(deleted);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}