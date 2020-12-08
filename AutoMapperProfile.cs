using AutoMapper;
using GovernmentGrantDisbursementAPI.DTOs;
using GovernmentGrantDisbursementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Household, GetHouseholdDTO>();
            CreateMap<AddHouseholdDTO, Household>();
            CreateMap<FamilyMember, GetFamilyMembersDTO>().ForMember(dest => dest.OccupationType, opt => opt.MapFrom(src => src.OccupationType.ToString()));
            CreateMap<AddFamilyMemberDTO, FamilyMember>().ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.Name));
        }        
    }
}
