using System.Linq;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Http;
using TokenAuthenticationWEBAPI.DTOs;
using TokenAuthenticationWEBAPI.Services;

namespace TokenAuthenticationInWebAPI.Controllers
{
    //[EnableCors(origins: "http://localhost:8080/Login", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public UserService Service { get; set; }
        public UserController()
        {
            Service = new UserService();
        }

        //This resource is For all types of role
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/user/resource1")]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var clientID = identity.Claims.FirstOrDefault(c => c.Type == "ClientID").Value;
            var clientName = identity.Claims.FirstOrDefault(c => c.Type == "ClientName").Value;
            var clientSecret = identity.Claims.FirstOrDefault(c => c.Type == "ClientSecret").Value;

            return Ok("Hello: " + identity.Name);
        }
        //This resource is only For Admin and SuperAdmin role
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        [Route("api/user/resource2")]
        public IHttpActionResult GetResource2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                .FirstOrDefault(c => c.Type == "Email").Value;
            var UserName = identity.Name;

            return Ok("Hello " + UserName + ", Your Email ID is :" + Email);
        }
        //This resource is only For SuperAdmin role
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Route("api/user/resource3")]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }

        //[Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpPost]
        [Route("api/user/GetClientIdentity")]
        public ClientDTO GetClientIdentity([FromBody] ClientRequestDTO clientRequest)
        {

            return Service.GetClientIdentity(clientRequest.clientName);
        }



    
    }
}