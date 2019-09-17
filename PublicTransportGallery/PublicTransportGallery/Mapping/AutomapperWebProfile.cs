using AutoMapper;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.ViewModels;

namespace PublicTransportGallery.Mapping
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<ImageDetailsViewModels, TblImage>();
            CreateMap<TblImage, ImageDetailsViewModels>()
                .ForMember(d => d.Model, o => o.MapFrom(s => s.TblVehicles.TblModel.NameModel))
                .ForMember(d => d.Producent, o => o.MapFrom(s => s.TblVehicles.TblModel.TblProducent.Name))
                .ForMember(d => d.ImageName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.YearProduction, o => o.MapFrom(s => s.TblVehicles.TblModel.YearProduction))
                .ForMember(d => d.YearEndProduction, o => o.MapFrom(s => s.TblVehicles.TblModel.YearProductionEnd))
                .ForMember(d => d.VoivodeshipName, o => o.MapFrom(s => s.TblVehicles.TblPassengerTransport.TblCity.TblVoivodeship.NAZWA))
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.TblVehicles.TblPassengerTransport.TblCity.NAZWA))
                .ForMember(d => d.PassangerTransportId, o => o.MapFrom(s => s.TblVehicles.PassengerTransId))
                .ForMember(d => d.PassangerTransportName, o => o.MapFrom(s => s.TblVehicles.TblPassengerTransport.Name))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.users.UserName));

            //CreateMap<TblImage, UploadImageViewModels>();
            CreateMap<UploadImageViewModels, TblImage>();
            CreateMap<TblComment, CommentListViewModels>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.users.UserName));

            CreateMap<TblImage, EditImageViewModels>()
                .ForMember(d => d.ProducentId, o => o.MapFrom(s => s.TblVehicles.TblModel.TblProducent.ProducentId));
            CreateMap<EditImageViewModels, TblImage>();
            CreateMap<CommentInsertViewModels, TblComment>();
            CreateMap<CreateVehicleViewModels, TblVehicle>()
                .ForMember(d => d.YearOfGet, o => o.MapFrom(s => s.YearOfGet))
                .ForMember(d => d.YearOfRemove, o => o.MapFrom(s => s.YearOfRemove));
            CreateMap<TblPassengerTransport, PassengerTransportViewModels>()
                .ForMember(d => d.CityName, o => o.MapFrom(s => s.TblCity.NAZWA));
        }

        //public static void Run()
        //{
        //    AutoMapper.Mapper.Initialize(a =>
        //    {
        //        a.AddProfile<AutomapperWebProfile>();
        //    });
        //}
    }
}