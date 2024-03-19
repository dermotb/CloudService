using AzureService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AzureService.Controllers
{
    public class CloudServiceController : Controller
    {
        // GET: CloudServiceController
        public ActionResult Calculate()
        {
            ViewBag.InstanceSize = new SelectList(CloudService.InstanceSizeDescriptions);
            return View(new CloudService() { NoInstances=2});
        }

        [HttpPost]
        public ActionResult Calculate(CloudService svc)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Confirm", svc);
            }
            else
            {
                ViewBag.InstanceSize = new SelectList(CloudService.InstanceSizeDescriptions);
                return View(svc);
            }
        }

        // GET: CloudServiceController/Create
        public ActionResult Confirm(CloudService service)
        {
            return View(service);
        }


    }
}
