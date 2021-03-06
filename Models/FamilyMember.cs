﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.Models
{
    public class FamilyMember
    {
        [Key]
        public int HouseholdId { get; set; }
        [StringLength(50)]
        public string MemberName { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(10)]
        public string MaritalStatus { get; set; }
        [StringLength(50)]
        public string Spouse { get; set; } = "Not Applicable";
        public int OccupationType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AnnualIncome { get; set; }
        [StringLength(50)]
        public DateTime DOB { get; set; }

    }
}
