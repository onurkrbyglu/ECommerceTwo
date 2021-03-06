﻿using ECommerce.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private GurhanDbEntities db = new GurhanDbEntities();
       
        // GET: Admin/Category
        public ActionResult List()
        {
            CategoryVM category = new CategoryVM();
            category.Category = db.Categories.ToList();
            return View(category);
        }

        public ActionResult Add()
        {
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            Category cat = new Category();
            cat.Name = model.Name;
            cat.Published = model.Published;
            cat.CreatedOnUtc = DateTime.Now;

            db.Categories.Add(cat);
            db.SaveChanges();

            return RedirectToAction("List");
        }


        public ActionResult Edit(int id)
        {
            CategoryVM category = new CategoryVM();
            category.Edit = db.Categories.SingleOrDefault(x => x.Id == id);
            return View(category.Edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            Category Category = db.Categories.SingleOrDefault(x => x.Id == model.Id);
            Category.Name = model.Name;
            Category.Published = model.Published;
            Category.UpdatedOnUtc = DateTime.Now;
            db.SaveChanges();
           

            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            Category deleted = db.Categories.SingleOrDefault(x => x.Id == id);
            db.Categories.Remove(deleted);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}