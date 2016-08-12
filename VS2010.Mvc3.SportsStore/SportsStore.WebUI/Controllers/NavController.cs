using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    /// <summary>
    /// /把它理解为像webform中的带有后台代码的用户控件
    /// </summary>
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        /// <summary>
        /// 这里改为呈现视图ViewResult和呈现子视图一样的，没有区别，这里的动作的参数会自动由路由提供！这里不理解如何提供的，我擦
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}
