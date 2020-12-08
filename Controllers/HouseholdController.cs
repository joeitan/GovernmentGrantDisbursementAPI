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
        public async Task<IActionResult> GetHouseHold(int id)
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
        public async Task<ActionResult> CreateHousehold(AddHouseholdDTO household)
        {
            return Ok(await _householdService.CreateHousehold(household));
        }

        //Add a family member to household
        [HttpPost("AddFamilyMemberToHousehold")]
        public async Task<ActionResult> AddFamilyMemberToHousehold(AddFamilyMemberDTO familyMember)
        {
            return Ok(await _familyMemberService.AddFamilyMember(familyMember));
        }

        //List households and qualifying family members for Student Encouragement Bonus
        [HttpGet("GetHouseholdForSEB")]
        public async Task<ActionResult> GetHouseholdForSEB([FromQuery] int age, [FromQuery] int income)
        {
            return Ok(_householdService.SearchSEB(age, income));
        }
        [HttpGet("GetHouseholdForFTS")]
        public async Task<ActionResult> GetHouseholdForFTS([FromQuery] int age)
        {
            return Ok(_householdService.SearchFTS(age));
        }

        [HttpGet("GetHouseholdForEB")]
        public async Task<ActionResult> GetHouseholdForEB([FromQuery] int age)
        {
            return Ok(_householdService.SearchEB(age));
        }

        [HttpGet("GetHouseholdForYGG")]
        public async Task<ActionResult> GetHouseholdForYGG([FromQuery] int income)
        {
            return Ok(_householdService.SearchYGG(income));
        }

        [HttpGet("GetHouseholdForBSG")]
        public async Task<ActionResult> GetHouseholdForBSG([FromQuery] int age)
        {
            return Ok(_householdService.SearchBSG(age));
        }
    }
}
