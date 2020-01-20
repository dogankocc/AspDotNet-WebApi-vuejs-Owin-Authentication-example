using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TokenAuthenticationWEBAPI.Models;

namespace TokenAuthenticationWEBAPI.Data
{
    public class ApplicationDbContext
    {
        doantestEntities entitiy;
        public ApplicationDbContext()
        {
            this.entitiy = new doantestEntities();
        }

        public doantestEntities GetEntity()
        {
            return this.entitiy;
        }
    }
}