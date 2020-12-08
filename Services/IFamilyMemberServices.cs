using GovernmentGrantDisbursementAPI.DTOs;
using GovernmentGrantDisbursementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.Services
{
    public interface IFamilyMemberServices
    {
        Task<Response<string>> AddFamilyMember(AddFamilyMemberDTO familyMembers);
    }
}
