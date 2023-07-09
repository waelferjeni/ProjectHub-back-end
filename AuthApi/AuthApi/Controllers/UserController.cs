using AuthApi.Context;
using AuthApi.Helpers;
using AuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if(userObj == null)
                return BadRequest();
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName);
            if(user ==null)
                return NotFound(new {Message = "User not Found!"});
            if(!PasswordHasher.VerifyPassword(userObj.Password,user.Password))
            {
                return BadRequest(new
                {
                    Message = "Password is Incorrect"
                });
            }
            user.Token= CreateJwt(user);
            return Ok(new
            {
                Token=user.Token,
                Message="Login Success!"
            });
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody ] User userObj)
        {
            
            if(userObj==null)
                return BadRequest();
            //Check username
            if(await checkUserNameExistAsync(userObj.UserName))
                return BadRequest(new
                {
                    Message = "userName Already Exist!"
                });


            //Check Email
            if (await checkEmailExistAsync(userObj.Email))
                return BadRequest(new
                {
                    Message = "Email Already Exist!"
                });

            //Check password Strength
            var pass=checkPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(pass))
                return BadRequest(new { Message = pass.ToString() });


            userObj.Password=PasswordHasher.HashPassword(userObj.Password);
            await _authContext.Users.AddAsync(userObj);
            await _authContext.SaveChangesAsync();
            
            return Ok(new{
                Message = "User Registered!"
            });
        }
        [Authorize]
        [HttpGet("token")]
        public async Task<IActionResult> tokenExpries()
        {
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _authContext.Users.ToListAsync());
        }
        
        [HttpGet("getUser")]
        public async Task<User> GetUserByID(Guid id)
        {
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        [HttpGet("getServiceLeaderByServiceId/{serviceId}")]
        public async Task<Boolean> getServiceLeaderByServiceId([FromRoute] Guid serviceId)
        {
            var user = await _authContext.Users.FirstOrDefaultAsync(x =>x.ServiceId== serviceId && x.Role == "serviceLeader");
            if (user== null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet("getUsersByServiceId/{serviceId}")]
        public async Task<ActionResult<User>> getUsersByServiceId([FromRoute] Guid serviceId)
        {
            return Ok(await _authContext.Users.Where(u => u.ServiceId == serviceId).ToListAsync());
        }
        [HttpDelete("Delete/{id}")]
        public async Task<string> DeleteUser([FromRoute] Guid id)
        {
            if (id == null)
            {
                return "Id null";
            }

            try
            {
                User user = _authContext.Set<User>().Find(id);
                _authContext.Set<User>().Remove(user);
                await _authContext.SaveChangesAsync();
                return "Delete Done";
            }
            catch (Exception ex)
            {
                return "Delete error";


            }
        }
        [HttpPut("edit")]
        public async Task<IActionResult> editUser([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();
            _authContext.Users.Update(userObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Edited!"
            });
        }
        private  Task<bool> checkUserNameExistAsync(string userName)
        =>
            _authContext.Users.AnyAsync(x => x.UserName == userName);
        private Task<bool> checkEmailExistAsync(string email)
       =>
           _authContext.Users.AnyAsync(x => x.Email == email);
        private string checkPasswordStrength(string password)
        {
            StringBuilder stringBuilder= new StringBuilder();
            if (password.Length < 8)
                stringBuilder.Append("Minimum password length should be 8"+Environment.NewLine);
            if(!(Regex.IsMatch(password,"[a-z]")
                &&Regex.IsMatch(password,"[A-Z]")
                && Regex.IsMatch(password,"[0-9]")))
                stringBuilder.Append("Password should be Alphanumeric"+Environment.NewLine);
            if (!Regex.IsMatch(password, "[<,>,@,!,#,$,%,^,&,*,(,),-,_,+,/,=,.,?]"))
                stringBuilder.Append("Password should contain special chars" + Environment.NewLine);
            return stringBuilder.ToString();
        }

        private string CreateJwt(User user)
        {
            string id = user.Id.ToString();
            string serviceId = user.ServiceId.ToString();
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var Identity = new ClaimsIdentity(new Claim[]
            {
              new Claim(ClaimTypes.Role, user.Role),
              new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}"),
              new Claim(ClaimTypes.NameIdentifier,id),
              new Claim(ClaimTypes.GroupSid,serviceId),
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256);

            var tokenDescripter = new SecurityTokenDescriptor { 
            Subject= Identity,
            Expires= DateTime.Now.AddHours(8),
            SigningCredentials=credentials
            };
            var token= jwtTokenHandler.CreateToken(tokenDescripter);
            return jwtTokenHandler.WriteToken(token);
        }
        
    }
}
