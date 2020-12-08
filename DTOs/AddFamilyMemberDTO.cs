using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.DTOs
{
    public class AddFamilyMemberDTO
    {
        [Required]
        public int HouseholdId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string Spouse { get; set; }
        [Required]
        public int OccupationType { get; set; }
        [Required]
        public decimal AnnualIncome { get; set; }
        [Required]
        public DateTime DOB { get; set; }

    }
}
