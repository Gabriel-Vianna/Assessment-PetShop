using AT_PetShop.Web.RestClientSchedule;
using Infrastructure.ScheduleModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT_PetShop.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleClient restClient;

        public ScheduleController()
        {
            this.restClient = new ScheduleClient();
        }

        public ActionResult Index()
        {
            var model = this.restClient.GetAll();
            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            var model = this.restClient.GetById(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScheduleModel model)
        {
            try
            {
                this.restClient.Save(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var model = this.restClient.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ScheduleModel model)
        {
            try
            {
                this.restClient.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var model = this.restClient.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, ScheduleModel model)
        {
            try
            {
                this.restClient.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
