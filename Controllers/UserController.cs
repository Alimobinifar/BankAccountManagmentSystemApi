using Azure.Core;
using BankAccountManagmentSystemApi.Services.BankAccountServices;
using BankAccountManagmentSystemApi.Services.Interfaces;
using BankAccountManagmentSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagmentSystemApi.Controllers
{
    [ApiController]
    [Route("Api/User")]
    public class UserController : Controller
    {
        private protected UserSerivce _UserService;
        public UserController(UserSerivce userSerivce)
        {
            _UserService = userSerivce;
        }

        [HttpPost]
        [Route("Create")]
        public async Task <IActionResult> CreateUser([FromBody] CreateUserAccount createUserAccount)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _UserService.CreateUser(createUserAccount);

            if (!result)
                return BadRequest("User creation failed");

            return Ok("User has been created successfully");
        }

        [HttpPost]
        [Route("Update")]
        public async Task <IActionResult> UpdateUser([FromBody] UpdateUserAccount updateUserAccount)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _UserService.UpdateUser(updateUserAccount);

            if (!result)
                return BadRequest("Account update failed");

            return Ok("Account has been updated successfully");
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _UserService.GetAllUsers();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("No record found ... ");
        }

        [HttpGet]
        [Route("GetNationalityCodeAsync")]
        public async Task<IActionResult> GetNationalityCodeAsync([FromQuery] string NationalityCode)
        {
            var response = await _UserService.GetNationalityCodeAsync(NationalityCode);

            if (response != null && !response.Error)
                return Ok(response);

            return BadRequest(response?.Msg ?? "No record found ...");
        }
    }
}