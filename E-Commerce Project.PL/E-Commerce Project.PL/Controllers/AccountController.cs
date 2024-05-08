
using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UnitOfWorks _unitOfWork;

        public AccountController(UnitOfWorks unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpPost("Register")]

        public ActionResult Register(RegisterDTO userDto)
        {
            if (ModelState.IsValid)
            {

                User appuser = new User()
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Address = userDto.Address,
                    FullName = userDto.FullName,
                    Mobile = userDto.Mobile,
                    CreatedDate = DateTime.Now,
                    RoleId = 2
                };
                _unitOfWork.UsersRepository.add(appuser);
                _unitOfWork.savechanges();
                return Created();
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public ActionResult signin(LoginDTO userData)
        {
            var user = _unitOfWork.UsersRepository.FindName(userData.UserName);

            if (user != null && user.Password == userData.Password)
            {
                
                    List<Claim> Data = new List<Claim>();
                    Data.Add(new Claim("name", userData.UserName));
                    Data.Add(new Claim(ClaimTypes.MobilePhone, "0112874"));
                    Data.Add(new Claim("UserId", user.UserId.ToString()));




                    if (user.Role.RoleName == "Admin")
                    {
                        Data.Add(new Claim("isAdmin", "true"));
                        Data.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }
                    else if (user.Role.RoleName == "Customer")
                    {
                        Data.Add(new Claim("isCustomer", "true"));
                        Data.Add(new Claim(ClaimTypes.Role, "Customer"));

                    }

                    string seckey = "Welcome to our First Api Website for online shooping E-commerce project";
                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(seckey));
                    var Signcer = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                            claims: Data,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: Signcer
                        );
                    var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(stringToken);
                }
                else
                {
                    return Unauthorized();
                }
            }

        }
    }



