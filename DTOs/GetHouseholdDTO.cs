using GovernmentGrantDisbursementAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.DTOs
{
    public class GetHouseholdDTO
    {
        public string HousingType { get; set; }
        public List<GetFamilyMembersDTO> familyMembers { get; set; }
    }
}
