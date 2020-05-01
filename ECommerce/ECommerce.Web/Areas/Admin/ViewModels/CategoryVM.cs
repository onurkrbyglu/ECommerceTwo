using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Web.Areas.Admin.ViewModels
{
    public class CategoryVM
    {
        public List<Category> Category { get; set; }
        public Category Edit { get; set; }
    }
}