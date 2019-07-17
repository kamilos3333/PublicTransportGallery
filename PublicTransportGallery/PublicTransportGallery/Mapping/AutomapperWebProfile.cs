using PublicTransportGallery.Data.Model;
using PublicTransportGallery.ViewModels;

namespace PublicTransportGallery.Mapping
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<ImageDetailsViewModels, TblImage>();
            CreateMap<TblImage, ImageDetailsViewModels>()
                .ForMember(d => d.Model, o => o.MapFrom(s => s.TblModel.NameModel))
                .ForMember(d => d.Producent, o => o.MapFrom(s => s.TblModel.TblProducent.Name))
                .ForMember(d => d.ImageName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.YearProduction, o => o.MapFrom(s => s.TblModel.YearProduction))
                .ForMember(d => d.YearEndProduction, o => o.MapFrom(s => s.TblModel.YearProductionEnd))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.users.UserName));

            //CreateMap<TblImage, UploadImageViewModels>();
            CreateMap<UploadImageViewModels, TblImage>();
            CreateMap<TblComment, CommentListViewModels>()
                .ForMember(d => d.Username, o => o.MapFrom(s => s.users.UserName));
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();
            });
        }
    }
}