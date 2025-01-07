using AutoMapper;
using DataLayer.Entities;
using TutorLinkAPI.ViewModel;
#pragma warning disable CS8603, CS8602
namespace TutorLinkAPI.BusinessLogics.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Tutor
        CreateMap<TutorViewModel, Tutor>()
            .ForMember(dest => dest.Qualifications, opt => opt.MapFrom(src => src.Qualifications))
            .ReverseMap();


        CreateMap<AddTutorViewModel, Tutor>()
            //.ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.Fullname))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForAllOtherMembers(opt => opt.Ignore());

        CreateMap<UpdateTutorViewModel, Tutor>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom((src, dest) => src.Gender != 0 ? src.Gender : dest.Gender))
            .ForMember(dest => dest.Fullname, opt => opt.Condition(src => src.Fullname != null && src.Fullname != "string"))
            .ForMember(dest => dest.Email, opt => opt.Condition(src => src.Email != null && src.Email != "string"))
            .ForMember(dest => dest.Phone, opt => opt.Condition(src => src.Phone != null && src.Phone != "string"))
            .ForMember(dest => dest.Address, opt => opt.Condition(src => src.Address != null && src.Address != "string"))
            .ForMember(dest => dest.AvatarUrl, opt => opt.Condition(src => src.AvatarUrl != null && src.AvatarUrl != "string"))
            .ReverseMap();

        //Account
        CreateMap<AddAccountViewModel, Account>().ReverseMap();
        CreateMap<AccountViewModel, Account>().ReverseMap();
        CreateMap<Account, AccountGoogleViewModel>()
             .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId));
        CreateMap<AccountGoogleViewModel, Account>()
            .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId));

        //Qualification
        CreateMap<QualificationViewModel, Qualification>().ReverseMap();
        CreateMap<AddQualificationViewModel, Qualification>().ReverseMap();
        CreateMap<UpdateQualificationViewModel, Qualification>()
            .ForMember(dest => dest.QualificationName, opt => opt.Condition(src => src.QualificationName != null && src.QualificationName != "string"))
            .ForMember(dest => dest.InstitutionName, opt => opt.Condition(src => src.InstitutionName != null && src.InstitutionName != "string"))
            .ForMember(dest => dest.YearObtained, opt => opt.MapFrom(src => src.YearObtained))
            .ForMember(dest => dest.SkillId, opt => opt.Condition(src => src.SkillId != null && src.SkillId != 0))
            .ForMember(dest => dest.ProficiencyId, opt => opt.Condition(src => src.ProficiencyId != null && src.ProficiencyId != 0))
            .ReverseMap();

        //PostRequest
        CreateMap<PostRequestViewModel, PostRequest>()
            .ForMember(dest => dest.Applies, opt => opt.Ignore());

        CreateMap<PostRequest, PostRequestViewModel>()
            .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Account.AvatarUrl));

        CreateMap<AddPostRequestViewModel, PostRequest>()
            .ForMember(dest => dest.PostId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.Description, opt => opt.Condition((src, dest, srcMember) => srcMember != "string"))
            .ForMember(dest => dest.Location, opt => opt.Condition((src, dest, srcMember) => srcMember != "string"))
            .ForMember(dest => dest.Schedule, opt => opt.Condition((src, dest, srcMember) => srcMember != "string"))
            .ForMember(dest => dest.PreferredTime, opt => opt.Condition((src, dest, srcMember) => srcMember != "string"))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender != 0 ? src.Gender : default(RequestGender)))  
            .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.Mode != 0 ? src.Mode : default(RequestMode)))
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.RequestSkill, opt => opt.Condition((src, dest, srcMember) => srcMember != "string"))
            .ReverseMap();


        // Apply
        CreateMap<Apply, ApplyViewModel>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.Tutor.Fullname))
            .ReverseMap();
        CreateMap<AddApplyViewModel, Apply>()
            .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.PostId))
            .ForMember(dest => dest.TutorId, opt => opt.MapFrom(src => src.TutorId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        CreateMap<UpdateApplyViewModel, Apply>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ReverseMap();

        //AppointmentFeedback
        CreateMap<AppointmentFeedback, AppointmentFeedbackViewModel>()
           .ForMember(dest => dest.AccountUsername, opt => opt.MapFrom(src => src.Account.Username))
           .ForMember(dest => dest.AccountAvatarUrl, opt => opt.MapFrom(src => src.Account.AvatarUrl))
           .ForMember(dest => dest.TutorUsername, opt => opt.MapFrom(src => src.Tutor.Username))
           .ForMember(dest => dest.TutorAvatarUrl, opt => opt.MapFrom(src => src.Tutor.AvatarUrl));
    }
}