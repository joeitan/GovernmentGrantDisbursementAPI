using GovernmentGrantDisbursementAPI.DTOs;
using GovernmentGrantDisbursementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.Services
{
    public interface IHouseholdServices
    {
        Task<Response<List<GetHouseholdDTO>>> GetAllHouseholds() ;
        Response<GetHouseholdDTO> GetHouseHold(int id);
        Task<Response<string>> CreateHousehold(AddHouseholdDTO household);
        Response<List<GetHouseholdDTO>> SearchSEB(int age, int income);
        Response<List<GetHouseholdDTO>> SearchFTS(int age);
        Response<List<GetHouseholdDTO>> SearchEB(int age);
        Response<List<GetHouseholdDTO>> SearchYGG(int income);
        Response<List<GetHouseholdDTO>> SearchBSG(int age);
    }
}
