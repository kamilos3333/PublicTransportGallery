using PublicTransportGallery.Services.ModelVehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService modelService;

        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        public JsonResult getModel(int id)
        {
            var model = modelService.getModelJoinProducent(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}