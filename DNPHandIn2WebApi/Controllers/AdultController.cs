using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPHandIn2WebApi.Model;
using HandIn1.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace DNPHandIn2WebApi.Controllers
{
    [ApiController]
    [Route("Adult")]
    public class AdultsController : ControllerBase
    {
         private IAdultAdapter iadultAdapter;
         private IUserSecurity iuserSecurity;
         
        public AdultsController(IAdultAdapter iadultAdapter, IUserSecurity iuserSecurity)
        {
            this.iadultAdapter = iadultAdapter;
            this.iuserSecurity = iuserSecurity;

        }

       [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>>
            GetAdults()
        {
            try
            {
                IList<Adult> Adults = await iadultAdapter.getAllAdults();
                return Ok(Adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdult([FromBody] Adult adult)
        {
            Console.WriteLine("we are here 1");
            try
            {
                await iadultAdapter.Delete(adult);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult Adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
               await iadultAdapter.Add(Adult);
                return Created($"/{Adult.FirstName}", Adult); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<User>> VerifyLogin([FromBody] User user)
        {
          
              User usertoreturn =await iuserSecurity.ValidateUser(user.Username, user.Password);

              if (usertoreturn==null)
              {
                  return NotFound("User does not exist");
              }
              return Ok(usertoreturn);
           
           
        }
        

        
    }
}