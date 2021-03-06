using PublicTransportGallery.Controllers;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Infrastructure.Model_Builder.CommentBuilder;
using PublicTransportGallery.Infrastructure.Model_Builder.Interface;
using PublicTransportGallery.Infrastructure.Model_Builder.PassengerTransportBuilder;
using PublicTransportGallery.Infrastructure.Model_Builder.SearchBuilder;
using PublicTransportGallery.Infrastructure.Model_Builder.VehicleBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilder.SearchBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Log;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.City;
using PublicTransportGallery.Services.Services.PassengerTransport;
using PublicTransportGallery.Services.Services.Search;
using PublicTransportGallery.Services.Services.Vehicle;
using PublicTransportGallery.Services.Services.Voivodeship;
using PublicTransportGallery.Services.Validation;
using PublicTransportGallery.ViewModels;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace PublicTransportGallery
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IModelBuilderExecuteReturnModel<ImageDetailsViewModels>, DetailImageBuilder>();
            container.RegisterType<IModelBuilderImage<UploadImageViewModels>, UploadImageBuilder>();
            container.RegisterType<IModelBuilderImage<ImageEditViewModels>, EditImageBuilder>();
            container.RegisterType<IModelBuilderExecuteReturnModel<HomeViewModel>, HomeBuilder>();
            container.RegisterType<IModelCommand<TblImage>, DeleteImageBuilder>();
            container.RegisterType<IModelBuilderExecuteRebuild<SearchByModelViewModels>, SearchByModelBuilder>();
            container.RegisterType<IModelBuilderExecuteRebuild<SearchByCityViewModels>, SearchByCityBuilder>();
            container.RegisterType<IModelInsertBuilder<CreateVehicleViewModels>, CreateVehicleBuilder>();
            container.RegisterType<IModelBuilderExecuteReturnModel<PassengerTransportViewModels>, DetailsBuilder>();
            container.RegisterType<IModelInsertBuilder<EditVehiceViewModels>, EditVehicleBuilder>();
            container.RegisterType<IModelCommand<TblVehicle>, DeleteVehicleBuilder>();
            container.RegisterType<IModelBuilderExecuteReturnModel<CommentViewModels>, DetailCommentBuilder>();
            container.RegisterType<IProducentService, ProducentService>();
            container.RegisterType<IModelService, ModelService>();
            container.RegisterType<IImageService, ImageService>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<ICityService, CityService>();
            container.RegisterType<IVoivodeshipService, VoivodeshipService>();
            container.RegisterType<ILogVisitorImageService, LogVisitorImageService>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<IPassengerTransportService, PassengerTransportService>();
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<IValidationService, ValidationService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}