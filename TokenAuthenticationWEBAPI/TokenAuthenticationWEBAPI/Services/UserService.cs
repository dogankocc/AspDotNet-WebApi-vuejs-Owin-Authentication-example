using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenAuthenticationWEBAPI.DTOs;
using TokenAuthenticationWEBAPI.Data;
using TokenAuthenticationWEBAPI.Models;

namespace TokenAuthenticationWEBAPI.Services
{
    public class UserService
    {
        private  doantestEntities entity ;
        public UserService()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            entity = dbContext.GetEntity();
        }
        public ClientDTO GetClientIdentity(string clientName)
        {
            ICollection<ClientDTO> client = entity.ClientMaster.Where(e => e.ClientName == clientName).Select(e => new ClientDTO { ClientId = e.ClientId, ClientSecret= e.ClientSecret }).ToList();
            string clientID = client.ElementAt(0).ClientId;
            return client.ElementAt(0);
        }
    }
}