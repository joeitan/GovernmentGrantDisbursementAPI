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
    public class HouseholdServices : IHouseholdServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public HouseholdServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<string>> CreateHousehold(AddHouseholdDTO household)
        {
            Response<string> response = new Response<string>();
            try
            {
                
                Household dbHousehold = _mapper.Map<Household>(household);

                var exist = await _context.Households.FirstOrDefaultAsync(u => u.Id == dbHousehold.Id);

                if (exist == null)
                {
                    await _context.Households.AddAsync(dbHousehold);
                    await _context.SaveChangesAsync();
                    response.Data = "Success";
                    response.Message = dbHousehold.Id + " has been successfully created";

                    return response;
                }

                response.Data = "Fail";
                response.Success = false;
                response.Message = "This household ID exists in the database.";
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

        public async Task<Response<List<GetHouseholdDTO>>> GetAllHouseholds()
        {
            Response<List<GetHouseholdDTO>> response = new Response<List<GetHouseholdDTO>>();
            try
            {
                List<Household> dbhouseholds = await _context.Households.ToListAsync();
                var households = PopulateHousehold(dbhouseholds);
                response.Data = households;
                if(households.Count == 0)
                {
                    response.Message = "The result is empty.";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Data = new List<GetHouseholdDTO>();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }

        public Response<GetHouseholdDTO> GetHouseHold(int id)
        {
            Response<GetHouseholdDTO> response = new Response<GetHouseholdDTO>();
            try
            {
                GetHouseholdDTO household = new GetHouseholdDTO();
                household.HousingType = _context.Households.Where(x => x.Id == id).Select(x => x.HousingType).FirstOrDefault();
                if(household.HousingType == null)
                {
                    response.Data = new GetHouseholdDTO();
                    response.Success = false;
                    response.Message = "The Id entered does not exist in our database. ";
                    return response;
                }
                List<FamilyMember> familyMembers = _context.FamilyMembers.AsNoTracking().Where(x => x.HouseholdId == id).ToList();
                household.familyMembers = _mapper.Map<List<GetFamilyMembersDTO>>(familyMembers);
                
                response.Data = household;
                return response;
            }
            catch (Exception ex)
            {
                response.Data = new GetHouseholdDTO();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }

        }

        public Response<List<GetHouseholdDTO>> SearchSEB(int age, int income)
        {
            Response<List<GetHouseholdDTO>> response = new Response<List<GetHouseholdDTO>>();
            try
            {
                List<Household> dbhouseholds = _context.Households.FromSqlRaw($"SP_ListHouseholdIdForStudentEncouragementBonus {age}, {income}").ToList();
                var households = PopulateHousehold(dbhouseholds);
                response.Data = households;
                if (households.Count == 0)
                {
                    response.Message = "The result is empty.";
                }
                return response;
            }
            catch (Exception ex)
             {
                response.Data = new List<GetHouseholdDTO>();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }

        public Response<List<GetHouseholdDTO>> SearchFTS(int age) 
        {
            Response<List<GetHouseholdDTO>> response = new Response<List<GetHouseholdDTO>>();
            try
            {
                List<Household> dbhouseholds = _context.Households.FromSqlRaw($"SP_ListHouseholdIdForFamilyTogethernessScheme {age}").ToList();
                var households = PopulateHousehold(dbhouseholds);
                response.Data = households;
                if (households.Count == 0)
                {
                    response.Message = "The result is empty.";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Data = new List<GetHouseholdDTO>();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }

        public Response<List<GetHouseholdDTO>> SearchEB(int age)
        {
            Response<List<GetHouseholdDTO>> response = new Response<List<GetHouseholdDTO>>();
            try
            {
                List<Household> dbhouseholds = _context.Households.FromSqlRaw($"SP_ListHouseholdIdForElderBonus {age}").ToList();
                var households = PopulateHousehold(dbhouseholds);
                response.Data = households;
                if (households.Count == 0)
                {
                    response.Message = "The result is empty.";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Data = new List<GetHouseholdDTO>();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }

        public Response<List<GetHouseholdDTO>> SearchBSG(int age)
        {
            Response<List<GetHouseholdDTO>> response = new Response<List<GetHouseholdDTO>>();
            try
            {
                List<Household> dbhouseholds = _context.Households.FromSqlRaw($"SP_ListHouseholdIdForBabySunshineGrant {age}").ToList();
                var households = PopulateHousehold(dbhouseholds);
                response.Data = households;
                if (households.Count == 0)
                {
                    response.Message = "The result is empty.";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Data = new List<GetHouseholdDTO>();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }

        public Response<List<GetHouseholdDTO>> SearchYGG(int income)
        {
            Response<List<GetHouseholdDTO>> response = new Response<List<GetHouseholdDTO>>();
            try
            {
                List<Household> dbhouseholds = _context.Households.FromSqlRaw($"SP_ListHouseholdIdForYOLOGSTGrant {income}").ToList();
                var households = PopulateHousehold(dbhouseholds);
                response.Data = households;
                if (households.Count == 0)
                {
                    response.Message = "The result is empty.";
                } 
                return response;
            }
            catch (Exception ex)
            {
                response.Data = new List<GetHouseholdDTO>();
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
            
        }

        private List<GetHouseholdDTO> PopulateHousehold(List<Household> households)
        {
            List<GetHouseholdDTO> result = new List<GetHouseholdDTO>();
            List<OccupationType> occupationList = _context.OccupationTypes.ToList();
            foreach (var h in households)
            {
                GetHouseholdDTO household = new GetHouseholdDTO();
                household.HousingType = h.HousingType;
                household.familyMembers = _mapper.Map<List<GetFamilyMembersDTO>>(_context.FamilyMembers.AsNoTracking().Where(x => x.HouseholdId == h.Id).ToList());
                household.familyMembers.ForEach(x => x.OccupationType = occupationList.Where(y => y.Id.ToString() == x.OccupationType).Select(y => y.Occupation).SingleOrDefault());
                result.Add(household);
            }
            return result;
        }
    }
}
