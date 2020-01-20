using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenAuthenticationWEBAPI.DTOs
{
    public class UserDTO
    {
        public string username { get; set; }
        public string password { get; set; }

    }

    public class ClientDTO
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }

    public class ClientRequestDTO
    {
        public string clientName { get; set; }


    }
}