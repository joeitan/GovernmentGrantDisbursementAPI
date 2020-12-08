using GovernmentGrantDisbursementAPI.DTOs;
using GovernmentGrantDisbursementAPI.Models;
using GovernmentGrantDisbursementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GovernmentGrantDisbursementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseholdController : ControllerBase
    {
        private readonly IHouseholdServices _householdService;
        private readonly IFamilyMemberServices _familyMemberService;
        public HouseholdController(IHouseholdServices householdService, IFamilyMemberServices familyMemberService)
        {
            _householdService = householdService;
            _familyMemberService = familyMemberService;
        }
        private static List<Household> households = new List<Household>();

        //Show household
        [HttpGet("GetHouseHold/{id}")]
        public IActionResult GetHouseHold(int id)
        {
            return Ok(_householdService.GetHouseHold(id));
        }

        //List households
        [HttpGet("GetAllHouseHolds")]
        public async Task<IActionResult> GetAllHouseHolds()
        {
            return Ok(await _householdService.GetAllHouseholds());
        }

        //Create Household
        [HttpPost("CreateHousehold")]
        public async Task<IActionResult> CreateHousehold(AddHouseholdDTO household)
        {
            return Ok(await _householdService.CreateHousehold(household));
        }

        //Add a family member to household
        [HttpPost("AddFamilyMemberToHousehold")]
        public async Task<IActionResult> AddFamilyMemberToHousehold(AddFamilyMemberDTO familyMember)
        {
            return Ok(await _familyMemberService.AddFamilyMember(familyMember));
        }

        //List households and qualifying family members for Student Encouragement Bonus
        [HttpGet("GetHouseholdForSEB")]
        public IActionResult GetHouseholdForSEB([FromQuery] int age, [FromQuery] int income)
        {
            return Ok(_householdService.SearchSEB(age, income));
        }
        [HttpGet("GetHouseholdForFTS")]
        public IActionResult GetHouseholdForFTS([FromQuery] int age)
        {
            return Ok(_householdService.SearchFTS(age));
        }

        [HttpGet("GetHouseholdForEB")]
        public IActionResult GetHouseholdForEB([FromQuery] int age)
        {
            return Ok(_householdService.SearchEB(age));
        }

        [HttpGet("GetHouseholdForYGG")]
        public IActionResult GetHouseholdForYGG([FromQuery] int income)
        {
            return Ok(_householdService.SearchYGG(income));
        }

        [HttpGet("GetHouseholdForBSG")]
        public IActionResult GetHouseholdForBSG([FromQuery] int age)
        {
            return Ok(_householdService.SearchBSG(age));
        }
    }
}
