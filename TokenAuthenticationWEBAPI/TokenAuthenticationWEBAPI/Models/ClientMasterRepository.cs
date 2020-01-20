using System;
using System.Linq;
using TokenAuthenticationWEBAPI.Models;
public class ClientMasterRepository : IDisposable
{
    // SECURITY_DBEntities it is your context class
    doantestEntities context = new doantestEntities();

    //This method is used to check and validate the Client credentials
    public ClientMaster ValidateClient(string ClientID, string ClientSecret)
    {
        return context.ClientMaster.FirstOrDefault(user =>
         user.ClientId == ClientID
        && user.ClientSecret == ClientSecret);
    }
    public void Dispose()
    {
        context.Dispose();
    }

}