using AutoMapper;
using GovernmentGrantDisbursementAPI.Data;
using GovernmentGrantDisbursementAPI.DTOs;
using GovernmentGrantDisbursementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.Services
{
    public class FamilyMemberServices : IFamilyMemberServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public FamilyMemberServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<string>> AddFamilyMember(AddFamilyMemberDTO familyMembers)
        {
            Response<string> response = new Response<string>();
            try
            {
                
                FamilyMember familyMember = _mapper.Map<FamilyMember>(familyMembers);

                var exist = await _context.Households.SingleOrDefaultAsync(u => u.Id == familyMember.HouseholdId);

                if (exist != null)
                {
                    await _context.FamilyMembers.AddAsync(familyMember);
                    await _context.SaveChangesAsync();
                    response.Data = "Success";
                    response.Message = familyMember.MemberName + " has been successfully added into the household";

                    return response;
                }

                response.Data = "Fail";
                response.Success = false;
                response.Message = "This household ID does not exist in the database. Please create a new household with the same ID before adding family members";
                return response;
            }
            catch (Exception ex)
            {
                response.Data = "Fail";
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }

        
    }
}
