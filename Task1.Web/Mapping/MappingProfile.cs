namespace Task1.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Client Mapping
            CreateMap<ClientViewModel, Client>()
           .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
           .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientId))
           .ReverseMap();

            //Product Mapping
            CreateMap<ProductViewModel, Product>().ReverseMap();

            //Client Product
            CreateMap<ClientProducts, EditClientProductViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ReverseMap();


        }
    }
}
