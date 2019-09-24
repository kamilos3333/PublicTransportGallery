using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.Model_Builder.VehicleBuilder
{
    public class DeleteVehicleBuilder : IModelCommand<TblVehicle>
    {
        private readonly IVehicleService vehicleService;

        public DeleteVehicleBuilder(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        public void Execute(TblVehicle model)
        {
            vehicleService.Delete(model);
            vehicleService.Save();
        }
    }
}