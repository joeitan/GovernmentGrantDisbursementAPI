﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GovernmentGrantDisbursementAPI.Models
{
    public class Household
    {
        [Key]
        public int Id { get; set; }
        public string HousingType { get; set; }
    }
}
