using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.DTOs
{
    public class GetAllHouseholdDTO
    {
        public string HousingType { get; set; }
        public List<GetFamilyMembersDTO> familyMembers { get; set; }
    }
}
