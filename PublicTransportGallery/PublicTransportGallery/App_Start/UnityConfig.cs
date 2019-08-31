using PublicTransportGallery.Controllers;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Infrastructure.ModelBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Log;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
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
            container.RegisterType<IModelBuilderImage<EditImageViewModels>, EditImageBuilder>();
            container.RegisterType<IModelBuilderExecuteReturnModel<HomeViewModel>, HomeBuilder>();
            container.RegisterType<IModelCommand<TblImage>, DeleteImageBuilder>();
            container.RegisterType<IProducentService, ProducentService>();
            container.RegisterType<IModelService, ModelService>();
            container.RegisterType<IImageService, ImageService>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<ILogVisitorImageService, LogVisitorImageService>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}