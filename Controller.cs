using Datalus.Web.Models.ViewModels;
using Datalus.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Datalus.Web.Controllers
{
    [RoutePrefix("Employments")]
    public class EmploymentsController : BaseController
    {
        [Route("{userProfileId:int}/Create")]
        [Route("{userProfileId:int}/{id:int}/edit")]
        public ActionResult Create(int userProfileId = 0, int id = 0)
        {
            EmploymentsViewModel model = new EmploymentsViewModel();
            model = DecorateViewModel(model);
            model.Id = id;
            model.UserProfileId = userProfileId;
            return View(model);
        }

        [Route, HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
